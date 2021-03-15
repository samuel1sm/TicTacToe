using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int[,] _gameMatrix;
    private bool _playerTurn = false;
    public event Action<Vector2, bool> UpdatePosition = delegate { };
    
    private void Awake()
    {
        _gameMatrix = new int[3, 3];
    }

    private int VerifyWinningCondition()
    {
 
        int sumOne = 0;
        int sumTwo = 0;

        for (int i = 0; i < _gameMatrix.GetLength(0); i++)
        {
            sumOne = 0;
            sumTwo = 0;
            
            for (int j = 0; j < _gameMatrix.GetLength(0); j++)
            {
                sumOne += _gameMatrix[j,i];
                sumTwo +=  _gameMatrix[i,j];
            }
            
            if (sumOne != 3 && sumOne != -3 && sumTwo != 3 && sumTwo != -3) continue;
            
            if (sumOne == 3 || sumTwo == 3) return 1;
            
            return -1;
        }
        
        sumOne = 0;
        sumTwo = 0;
        
        for (int i = 0; i < _gameMatrix.GetLength(0); i++)
        {
            sumOne += _gameMatrix[i, i];
            sumTwo += _gameMatrix[i, _gameMatrix.GetLength(0) - 1  - i];

        }
        
        if (sumOne != 3 && sumOne != -3 && sumTwo != 3 && sumTwo != -3)  return 0;
        
        if (sumOne == 3 || sumTwo == 3) return 1;
            
        return -1;

    }
    
    public void SelectPosition(string a)
    {
        var values = a.Split(',');
        var position = new Vector2Int(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
        if (_gameMatrix[position.x, position.y] != 0) return;

        _gameMatrix[position.x, position.y] = _playerTurn ? 1 : -1;
    
        print(VerifyWinningCondition());
        
        UpdatePosition(position, _playerTurn);
        _playerTurn = !_playerTurn;
    }
}
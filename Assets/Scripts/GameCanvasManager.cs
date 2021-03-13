using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameCanvasManager : Singleton<GameCanvasManager>
{
    private int[,] _gameMatrix;
    private bool _playerTurn = false;
    public event Action<Vector2, bool> UpdatePosition = delegate {  }; 
    
    private void Awake()
    {
        _gameMatrix = new int[3, 3];
    }

    void Start()
    {
        
    }

    public void SelectPosition(string a)
    {
        var values = a.Split(',');
        var position = new Vector2Int(Convert.ToInt32(values[0]),Convert.ToInt32(values[1]));
        if(_gameMatrix[position.x, position.y] != 0) return;

        _gameMatrix[position.x, position.y] = _playerTurn ? 1 : -1;
    
        UpdatePosition(position, _playerTurn);
        _playerTurn = !_playerTurn;

    }
}

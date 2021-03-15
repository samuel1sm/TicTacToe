using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] private EndMenuController gameEndMenu;

    private GameManager _gameManager;
    private GameSetupHandler _gameSetupHandler;
    
    private string _firstName;
    private string _secondName;

    private const string DrawText = "It was a Draw !"; 
    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
        _gameSetupHandler = GetComponent<GameSetupHandler>();
        
        _gameSetupHandler.UpdatePlayersNames += UpdateNames;
    }
    
    void Start()
    {
        _gameManager.EndGame += StartEndGame;
    }

    private void StartEndGame(int obj)
    {
        string resultText;

        if (obj != 0)
        {
            var s = obj == -1 ? _firstName : _secondName;
            resultText = $"{s} Win !!";
        }
        else
        {
            resultText = DrawText;
        }
        
        gameEndMenu.gameObject.SetActive(true);
        gameEndMenu.UpdateEndMenu(resultText, _firstName, _secondName);

    }

    private void UpdateNames(string arg1, string arg2)
    {
        _firstName = arg1;
        _secondName = arg2;
       
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}

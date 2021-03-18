using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationalMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI playerOneNameSpace;
    [SerializeField] private TextMeshProUGUI playerTwoNameSpace;

    [SerializeField] private Image playerOneImage;
    [SerializeField] private Image playerTwoImage;
    
    [SerializeField] private GameSetupHandler setupHandler;

    [SerializeField] private GameObject firstPlayerTurnIcon;
    [SerializeField] private GameObject secondPlayerTurnIcon;

    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    
    }

    private void UpdateNames(string arg1, string arg2)
    {
        
        
        playerOneNameSpace.text = arg1;
        playerTwoNameSpace.text = arg2;
    }

    private void UpdateImages(GameMarkersSo arg1, GameMarkersSo arg2)
    {
        playerOneImage.sprite = arg1.itemImage;
        playerOneImage.color = arg1.itemColor;
        
        playerTwoImage.sprite = arg2.itemImage;
        playerTwoImage.color = arg2.itemColor;
    }

    private void Start()
    {
        setupHandler.UpdatePlayersImages += UpdateImages;
        setupHandler.UpdatePlayersNames += UpdateNames;
        _gameManager.UpdatePosition += UpdatePlayer;
        UpdatePlayer(Vector2.down, !_gameManager.isActiveAndEnabled);
        
    }

    private void UpdatePlayer(Vector2 arg1, bool arg2)
    {
        if (arg2)
        {
            firstPlayerTurnIcon.SetActive(false);
            secondPlayerTurnIcon.SetActive(true);
        }
        else
        {
            firstPlayerTurnIcon.SetActive(true);
            secondPlayerTurnIcon.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

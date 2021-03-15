using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInformations : MonoBehaviour
{
    [SerializeField] private Vector2Int buttonPosition;
    [SerializeField] private Image playerOneImage;
    [SerializeField] private Image playerTwoImage;
    private GameSetupHandler _setupHandler;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GetComponentInParent<GameManager>();
        _setupHandler = GetComponentInParent<GameSetupHandler>();
    }

    void Start()
    {
        _setupHandler.UpdatePlayersImages += UpdateImages;
        _gameManager.UpdatePosition += VerifyIfPositionUpdated;
    }

    private void VerifyIfPositionUpdated(Vector2 selectedPosition, bool player)
    {
        if(selectedPosition != buttonPosition) return;

        if (player)
            playerTwoImage.gameObject.SetActive(true);
        else
            playerOneImage.gameObject.SetActive(true);
        
    }
    
    private void UpdateImages(GameMarkersSo arg1, GameMarkersSo arg2)
    {
        playerOneImage.sprite = arg1.itemImage;
        playerOneImage.color = arg1.itemColor;
        
        playerTwoImage.sprite = arg2.itemImage;
        playerTwoImage.color = arg2.itemColor;
    }


}

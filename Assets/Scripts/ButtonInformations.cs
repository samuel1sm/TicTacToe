using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInformations : MonoBehaviour
{
    [SerializeField] private Vector2Int buttonPosition;
    [SerializeField] private Image[] selectionImg;
    private GameCanvasManager _gameCanvasManager;

    private void Awake()
    {
        _gameCanvasManager = GetComponentInParent<GameCanvasManager>();
    }

    void Start()
    {
        _gameCanvasManager.UpdatePosition += VerifyIfPositionUpdated;
    }

    private void VerifyIfPositionUpdated(Vector2 selectedPosition, bool player)
    {
        if(selectedPosition != buttonPosition) return;
        
        selectionImg[player ? 1 : 0].gameObject.SetActive(true);
    }


}

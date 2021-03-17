using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardBarController : MonoBehaviour
{
    [SerializeField] private ParticleSystem newItemFx;
    [SerializeField] private Button selectItemButton;
    [SerializeField] private Image barImage;
    [SerializeField] private Image nextItemImage;
    // [SerializeField] private int maxWinnCount = 3;
    [SerializeField] private float increaseAmount = 0.2f;
    private PlayerData _playerData;
    
    private GameMarkersSo _gameMarkersSo;

    private void Awake()
    {
        _playerData = FindObjectOfType<PlayerData>();
    }

    private void Start()
    {
        UpdateNextImage();
    }

    private void UpdateNextImage()
    {
        if (_playerData.IsListEmpty()) return;
        _gameMarkersSo = _playerData.GetFirstItem();
        nextItemImage.sprite = _gameMarkersSo.itemImage;
        nextItemImage.color = _gameMarkersSo.itemColor;
    }

    public void IncreaseBar()
    {
        barImage.fillAmount += increaseAmount;

        if (barImage.fillAmount == 1f)
        {
            selectItemButton.enabled = true;
            newItemFx.Play();
        }
        
        
    }

    public void CollectItem()
    {
        selectItemButton.enabled = false;
        barImage.fillAmount -= 1f;
        
        _playerData.RemoveFirstItem();
        newItemFx.Stop();
        UpdateNextImage();

    }
}
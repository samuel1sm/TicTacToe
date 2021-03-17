using System;
using System.Collections;
using System.Collections.Generic;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine;
using UnityEngine.Serialization;

public class RewardMenuController : MonoBehaviour
{
    [SerializeField] private Transform firstIconContent;
    [SerializeField] private Transform secondIconContent;

    [SerializeField] private DynamicContentController firstDynamicContentController;
    [SerializeField] private DynamicContentController secondDynamicContentController;

    private MainMenuManager _mainMenuManager;
    private SimpleScrollSnap _firstScrollSnap;
    private SimpleScrollSnap _secondScrollSnap;

    [SerializeField] private List<GameMarkersSo> _gameMarkersSo;

    private int _secondPreviousItem;
    private int _firstPreviousItem;

    private PlayerData _playerData;
    private ViewportItem[] _firstPanels;
    private ViewportItem[] _secondPanels;

    private void Awake()
    {
        _firstScrollSnap = firstDynamicContentController.GetComponent<SimpleScrollSnap>();
        _secondScrollSnap = secondDynamicContentController.GetComponent<SimpleScrollSnap>();
        _playerData = FindObjectOfType<PlayerData>();
        var positions = _playerData.GetStartIndexes();
        _secondPreviousItem = positions.y;
        _firstPreviousItem = positions.x;
        
        _mainMenuManager = GetComponentInParent<MainMenuManager>();
        _gameMarkersSo = _playerData.GetOwnedMarkers();
        UpdateContent();
    }

    private void OnEnable()
    {
        
        VerifyMarkers();
        _firstScrollSnap.startingPanel = _firstPreviousItem;
        _secondScrollSnap.startingPanel = _secondPreviousItem;
        
        _secondScrollSnap.Panels[_firstPreviousItem].GetComponent<ViewportItem>().WasSelected(true);
        _firstScrollSnap.Panels[_secondPreviousItem].GetComponent<ViewportItem>().WasSelected(true);



    }

    private void VerifyMarkers()
    {
        if (_secondScrollSnap.Panels.Length != _gameMarkersSo.Count)
        {
            UpdateContent();
        }
    }


    private void UpdateContent()
    {
        for (int i = firstIconContent.childCount; i < _gameMarkersSo.Count; i++)
        {
            firstDynamicContentController.AddToBack();
            secondDynamicContentController.AddToBack();
        }

        _firstPanels  = firstIconContent.GetComponentsInChildren<ViewportItem>();
        _secondPanels  = secondIconContent.GetComponentsInChildren<ViewportItem>();

        for (int i = 0; i < firstIconContent.childCount; i++)
        {
            _firstPanels[i].UpdateItemIcon(_gameMarkersSo[i]);
            _secondPanels[i].UpdateItemIcon(_gameMarkersSo[i]);
        }
    }

    public void ChangedSelectedItem(bool isFirstView)
    {
        
        // var panels = isFirstView ? _secondScrollSnap.Panels : _firstScrollSnap.Panels;
        if (isFirstView)
        {
            _secondPanels[_firstPreviousItem].WasSelected(false);
             _firstPreviousItem = _firstScrollSnap.CurrentPanel;

             _secondPanels[_firstPreviousItem].WasSelected(true);
        }
        else
        {
            _firstPanels[_secondPreviousItem].WasSelected(false);
            _secondPreviousItem = _secondScrollSnap.CurrentPanel;
            _firstPanels[_secondPreviousItem].WasSelected(true);
        }
        
    }

    public void BackToMainMenu()
    {
        if(_firstPreviousItem == _secondPreviousItem)
            _mainMenuManager.ActivateErrorTab(true);
        else
        {
            _playerData.SecondMarkerSo = _firstPanels[_firstPreviousItem].GetMarkersSo();
            _playerData.PrimaryMarkerSo = _secondPanels[_secondPreviousItem].GetMarkersSo();

            _mainMenuManager.OpenMainTab();
        }
    }
}
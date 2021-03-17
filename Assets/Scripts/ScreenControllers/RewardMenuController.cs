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

        var firstPanels = firstIconContent.GetComponentsInChildren<ViewportItem>();
        var secondPanels = secondIconContent.GetComponentsInChildren<ViewportItem>();

        for (int i = 0; i < firstIconContent.childCount; i++)
        {
            firstPanels[i].UpdateItemIcon(_gameMarkersSo[i]);
            secondPanels[i].UpdateItemIcon(_gameMarkersSo[i]);
        }
    }

    public void ChangedSelectedItem(bool isFirstView)
    {
        // var panels = isFirstView ? _secondScrollSnap.Panels : _firstScrollSnap.Panels;
        if (isFirstView)
        {
            _firstPreviousItem = _firstScrollSnap.CurrentPanel;
        }
        else
        {
            _secondPreviousItem = _secondScrollSnap.CurrentPanel;
        }
    }

    public void BackToMainMenu()
    {
        if (_firstPreviousItem == _secondPreviousItem)
            _mainMenuManager.ActivateErrorTab(true);
        else
        {
            var icons = _firstScrollSnap.Panels;
            _playerData.SecondMarkerSo = icons[_firstPreviousItem].GetComponent<ViewportItem>().GetMarkersSo();
            _playerData.PrimaryMarkerSo =  icons[_secondPreviousItem].GetComponent<ViewportItem>().GetMarkersSo();

            _mainMenuManager.OpenMainTab();
        }
    }
}
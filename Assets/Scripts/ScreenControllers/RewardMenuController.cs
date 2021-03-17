using System;
using System.Collections;
using System.Collections.Generic;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine;

public class RewardMenuController : MonoBehaviour
{
    [SerializeField] private Transform firstIconContent;
    [SerializeField] private Transform secondIconContent;
    [SerializeField] private GameObject contentItem;
    [SerializeField] private DynamicContentController simpleScrollSnap;
    private List<GameMarkersSo> _gameMarkersSo;
    private void OnEnable()
    {
        var list = FindObjectOfType<PlayerData>().GetOwnedMarkers();

        if (_gameMarkersSo == null)
        {
            _gameMarkersSo = list;
            UpdateContent();
            GetComponentInChildren<SimpleScrollSnap>().startingPanel = _gameMarkersSo.Count;
            return;
        }
        
        if (list.Count == _gameMarkersSo.Count) return;
        _gameMarkersSo = list;

        UpdateContent();
    }

    private void UpdateContent()
    {
        foreach (var marker in _gameMarkersSo)
        {
            simpleScrollSnap.AddToFront();
            // var viewportItem = Instantiate(contentItem, firstIconContent).GetComponent<ViewportItem>() ;
            // viewportItem.UpdateItemIcon(marker);
        }
    }


}

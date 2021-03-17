using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewportItem : MonoBehaviour
{

    [SerializeField] private Image itemIcon;
    private GameMarkersSo _gameMarkersSo;
    public void UpdateItemIcon(GameMarkersSo gameMarkersSo)
    {
        itemIcon.sprite= gameMarkersSo.itemImage;
        itemIcon.color = gameMarkersSo.itemColor;
        _gameMarkersSo = gameMarkersSo;
    }

    public void WasSelected(bool isSelected)
    {
        itemIcon.color =  isSelected ? Color.black : _gameMarkersSo.itemColor;
    }

    public GameMarkersSo GetMarkersSo()
    {
        return _gameMarkersSo;
    }
    // Start is called before the first frame update
    
}

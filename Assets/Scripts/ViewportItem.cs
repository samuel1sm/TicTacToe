using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewportItem : MonoBehaviour
{

    [SerializeField] private Image itemIcon;

    public void UpdateItemIcon(GameMarkersSo gameMarkersSo)
    {
        itemIcon.sprite= gameMarkersSo.itemImage;
        itemIcon.color = gameMarkersSo.itemColor;
    }
    // Start is called before the first frame update
    
}

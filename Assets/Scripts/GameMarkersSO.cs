using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Icon Skin", menuName = "Player Skins/Icon Skin")]
public class GameMarkersSo : ScriptableObject
{
    public Color itemColor = Color.white;
    public Sprite itemImage;
    public int value = 0;
}

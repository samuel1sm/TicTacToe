using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "IconSkin", menuName = "Player Skins/IconSkin")]
public class GameMarkersSo : ScriptableObject
{
    public Color itemColor = Color.white;
    public Sprite itemImage;
    public int value = 0;
}

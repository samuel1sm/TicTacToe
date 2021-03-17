using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameMarkersSo secondMarkerSo;
    [SerializeField] private GameMarkersSo primaryMarkerSo;
    [SerializeField] public List<GameMarkersSo> playerOwnedMarkers;
    [SerializeField] public List<GameMarkersSo> notOwnedIconsList;
    [SerializeField] private string playerName;

    public static PlayerData Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public string PlayerName
    {
        get => playerName;
        set => playerName = value;
    }

    public List<GameMarkersSo> GetOwnedMarkers()
    {
        return playerOwnedMarkers;
    }

    public GameMarkersSo PrimaryMarkerSo
    {
        get => primaryMarkerSo;
        set => primaryMarkerSo = value;
    }

    public GameMarkersSo SecondMarkerSo
    {
        get => secondMarkerSo;
        set => secondMarkerSo = value;
    }
    
    public void AddOwnedMarkers(GameMarkersSo newGameMarkersSo)
    {
        playerOwnedMarkers.Add(newGameMarkersSo);
    }
    
    public bool IsListEmpty()
    {
        return notOwnedIconsList.Count == 0;
    }
    
    public void RemoveFirstItem()
    {
        notOwnedIconsList.RemoveAt(0);
    }

    public GameMarkersSo GetFirstItem()
    {
        return notOwnedIconsList[0];
    }

    public Vector2Int GetStartIndexes()
    {
        var i = playerOwnedMarkers.FindIndex(a => a == secondMarkerSo);
        var j = playerOwnedMarkers.FindIndex(a => a == primaryMarkerSo);
        
        return new Vector2Int(i, j);
    }
}
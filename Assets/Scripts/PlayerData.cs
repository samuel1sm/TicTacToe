using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerData : MonoBehaviour
{
    
    [SerializeField] private GameMarkersSo primaryMarkerSo;
    [SerializeField] private GameMarkersSo secondMarkerSo;
    [SerializeField] private List<GameMarkersSo> playerOwnedMarkers;
    [SerializeField] private string playerName;
    public static PlayerData Instance;
    

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }else
        {
            Destroy(gameObject);
        }

        playerOwnedMarkers = new List<GameMarkersSo>();
        
    }

    public string PlayerName
    {
        get => playerName;
        set => playerName = value;
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
    
    
}

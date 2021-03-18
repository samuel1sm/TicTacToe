using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class PlayerSave
{
    public int itensCollected;
    public int startItensX;
    public int startItensY;

    public PlayerSave(PlayerData playerData)
    {
        itensCollected = playerData.GetOwnedMarkers().Count - 4;
        startItensX = playerData.GetStartIndexes().x;
        startItensY = playerData.GetStartIndexes().y;
    }
}

public class PlayerData : MonoBehaviour
{
    [SerializeField] private GameMarkersSo secondMarkerSo;
    [SerializeField] private GameMarkersSo primaryMarkerSo;
    [SerializeField] public List<GameMarkersSo> playerOwnedMarkers;
    [SerializeField] public List<GameMarkersSo> notOwnedIconsList;
    [SerializeField] private string playerName;

    public static int playedGames = 0;
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

        PlayerSave save = SaveSystem.LoadPlayers();
        if (save == null) return;
        LoadIconsList(save.itensCollected);
        LoadSelectedIcons(save.startItensX, save.startItensY);
    }

    private void LoadSelectedIcons(int positionX ,int positionY )
    {
        secondMarkerSo = playerOwnedMarkers[positionX];
        primaryMarkerSo = playerOwnedMarkers[positionY];
    }

    private void LoadIconsList(int qtd)
    {
        for (int i = 0; i < qtd; i++)
        {
            var item = GetFirstItem();
            AddOwnedMarkers(item);
            RemoveFirstItem();
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
        set => 
            secondMarkerSo = value;
    }

    public void AddOwnedMarkers(GameMarkersSo newGameMarkersSo)
    {
        playerOwnedMarkers.Add(newGameMarkersSo);
        SaveSystem.SavePlayer(this);
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
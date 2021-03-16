using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameSetupHandler : Singleton<GameSetupHandler>
{
    [SerializeField] private GameObject optionsMenu;
    public event Action<GameMarkersSo, GameMarkersSo> UpdatePlayersImages = delegate {  };
    public event Action<string, string> UpdatePlayersNames = delegate {  };
    private PlayerData _playerData;

    private void Awake()
    {
        _playerData = FindObjectOfType<PlayerData>();

    }

    // Start is called before the first frame update
    void Start()
    {
        var playerName = _playerData.PlayerName;
        UpdatePlayersNames(playerName, playerName + "_2");
        UpdatePlayersImages(_playerData.PrimaryMarkerSo, _playerData.SecondMarkerSo);
    }

    public void OpenConfigurationMenu()
    {
        optionsMenu.SetActive(true);
    }


}

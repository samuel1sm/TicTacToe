using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameSetupHandler : Singleton<GameSetupHandler>
{
    public event Action<GameMarkersSo, GameMarkersSo> UpdatePlayersImages = delegate {  };
    public event Action<string, string> UpdatePlayersNames = delegate {  };
    
    private PlayerData _playerData;

    private void Awake()
    {
        _playerData = PlayerData.Instance;

    }

    // Start is called before the first frame update
    void Start()
    {
        var playerName = _playerData.PlayerName;
        UpdatePlayersNames(playerName, playerName + "_2");
        UpdatePlayersImages(_playerData.PrimaryMarkerSo, _playerData.SecondMarkerSo);
    }


}

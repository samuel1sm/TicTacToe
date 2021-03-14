using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationalMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI playerOneNameSpace;
    [SerializeField] private TextMeshProUGUI playerTwoNameSpace;

    [SerializeField] private Image playerOneImage;
    [SerializeField] private Image playerTwoImage;

    private GameSetupHandler _setupHandler;

    private void Awake()
    {
        _setupHandler = GameSetupHandler.Instance;
        _setupHandler.UpdatePlayersImages += UpdateImages;
        _setupHandler.UpdatePlayersNames += UpdateNames;
    }

    private void UpdateNames(string arg1, string arg2)
    {
        playerOneNameSpace.text = arg1;
        playerTwoNameSpace.text = arg2;
    }

    private void UpdateImages(GameMarkersSo arg1, GameMarkersSo arg2)
    {
        playerOneImage.sprite = arg1.itemImage;
        playerOneImage.color = arg1.itemColor;
        
        playerTwoImage.sprite = arg2.itemImage;
        playerTwoImage.color = arg2.itemColor;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

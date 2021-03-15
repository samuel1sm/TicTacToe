using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMenuController : MonoBehaviour
{
    [SerializeField] private GameObject resetArea;
    [SerializeField] private GameObject endingArea;
    [SerializeField] private TextMeshProUGUI endTextMeshProUGUI;
    [SerializeField] private TextMeshProUGUI startTextFirstPlayer;
    [SerializeField] private TextMeshProUGUI endTextSecondPlayer;
    // Start is called before the first frame update

    public void UpdateEndMenu(string endText, string firstPlayerName, string secondPlayerName)
    {
        endTextMeshProUGUI.text = endText;
        startTextFirstPlayer.text = firstPlayerName;
        endTextSecondPlayer.text = secondPlayerName;
    }



    public void BackToMenu()
    {
        SceneController.LoadGameMainMenu();
    }

    public void OpenResetGameArea()
    {
        endingArea.SetActive(false);
        resetArea.SetActive(true);
    }

    public void OpenEndArea()
    {
        endingArea.SetActive(true);
        resetArea.SetActive(false);
    }
    
    
}

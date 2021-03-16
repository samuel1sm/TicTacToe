using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EndMenuController : MonoBehaviour
{
    [SerializeField] private GameObject gameArea;
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
        SceneController.LoadMainMenu();
    }

    public void OpenResetGameArea()
    {
        resetArea.SetActive(true);
        endingArea.SetActive(false);
    }

    public void OpenEndArea()
    {
        resetArea.SetActive(false);
        endingArea.SetActive(true);
    }

    public void ChoseStartPlayer(bool isTheSecond)
    {
        GameManager.IsSecondPlayerTurn = isTheSecond;
        ReloadGame();
    }
    
    public void ChoseRandomPlayer()
    {
        GameManager.IsSecondPlayerTurn = Random.Range(0f, 1f) > 0.5f;
        ReloadGame();
    }


    private void ReloadGame()
    {
        SceneController.LoadGameScene();
    }

    private void OnEnable()
    {
        gameArea.SetActive(false);
            
    }
}

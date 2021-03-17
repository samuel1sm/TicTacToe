using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject errorTab;
    [SerializeField] private GameObject rewardTab;
    [SerializeField] private GameObject mainTab;
    public void StartGame()
    {
        SceneController.LoadGameScene();
    }

    public void OpenRewardScreen()
    {
        mainTab.SetActive(false);
        rewardTab.SetActive(true);
    }
    
    public void OpenMainTab()
    {
        mainTab.SetActive(true);
        rewardTab.SetActive(false);
    }
    
    public void ActivateErrorTab(bool activate)
    {
        errorTab.SetActive(activate);
    }
}

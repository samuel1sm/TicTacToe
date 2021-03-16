using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class OptionsMenuController : MonoBehaviour
{
    [SerializeField] [CanBeNull] private GameObject optionsButton;

    private void OnEnable()
    {
        optionsButton?.SetActive(false);
    }

    private void OnDisable()
    {
        optionsButton?.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneController.LoadMainMenu();
    }

    public void CloseScreen()
    {
        gameObject.SetActive(false);
    }
}

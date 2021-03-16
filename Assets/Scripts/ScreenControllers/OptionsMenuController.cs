﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuController : MonoBehaviour
{
    [SerializeField] private GameObject optionsButton;

    private void OnEnable()
    {
        optionsButton.SetActive(false);
    }

    private void OnDisable()
    {
        optionsButton.SetActive(true);
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

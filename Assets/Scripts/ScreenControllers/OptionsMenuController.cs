using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    [SerializeField] private GameObject optionsButton;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectsSlider;

    // private AudioManager _audioManager;

    private void Awake()
    {
        // _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnEnable()
    {
        if(!optionsButton) return;
        optionsButton.SetActive(false);
    }

    private void OnDisable()
    {
        if(!optionsButton) return;
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

    public void UpdateMusicVolume()
    {
        AudioManager.Instance.UpdateMusicVolume(musicSlider.value);
        // _audioManager
    }
    
    public void UpdateEffectsVolume()
    {
        AudioManager.Instance.UpdateEffectsVolume(effectsSlider.value);

        // _audioManager.UpdateEffectsVolume(effectsSlider.value);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


[Serializable]
public class RewardData
{
    public string time;
    public int winCount;
    public float rewardValue;
    public RewardData(RewardBarController rewardBarController)
    {
        time = RewardBarController.InitiatedTime.ToString();
        winCount = rewardBarController.WinCount;
        rewardValue = rewardBarController.BarValue;
        // rewardValue = rewardBarController
    }
}


public class RewardBarController : MonoBehaviour
{
    [SerializeField] private ParticleSystem newItemFx;
    [SerializeField] private Button selectItemButton;
    [SerializeField] private Image barImage;
    [SerializeField] private GameObject itemBar;
    [SerializeField] private Image nextItemImage;
    [SerializeField] private TextMeshProUGUI rounds;
    [SerializeField] private int maxWinCount = 3;
    [SerializeField] private float increaseAmount = 0.2f;
    [SerializeField] private int minuteReset = 2;

    private float _barValue = 0;
    public static TimeSpan InitiatedTime;
    private int _winCount = 0;
    
    private PlayerData _playerData;
    private GameMarkersSo _gameMarkersSo;

    public int WinCount => _winCount;
    public float BarValue => _barValue;

    private void Awake()
    {
        _playerData = FindObjectOfType<PlayerData>();
        _winCount = maxWinCount;
        UpdateWinCountText();
        
        var result = SaveSystem.LoadRewards();
        if (result != null)
        {
            _winCount = result.winCount;
            InitiatedTime =TimeSpan.Parse(result.time);
            barImage.fillAmount = result.rewardValue;
            _barValue = result.rewardValue;
        }
        else
        {
            if(InitiatedTime != new TimeSpan()) return;
            InitiatedTime = System.DateTime.Now.TimeOfDay;
        }

        UpdateWinCountText();
    }

    private void UpdateWinCountText()
    {
        rounds.text = _winCount.ToString();
    }

    private void Start()
    {
        
        
        UpdateNextImage();
        if (PlayerData.playedGames > 0)
        {
            var loops = Mathf.Clamp(PlayerData.playedGames, 0, maxWinCount);
            for (int i = 0; i < loops; i++)
            {
                IncreaseBar();
            }
        }
        
    }

    private void UpdateNextImage()
    {
        if (_playerData.IsListEmpty())
        {
            itemBar.SetActive(false);
            return;
        }
        _gameMarkersSo = _playerData.GetFirstItem();
        nextItemImage.sprite = _gameMarkersSo.itemImage;
        nextItemImage.color = _gameMarkersSo.itemColor;
    }

    public void IncreaseBar()
    {   
        if(_winCount == 0) return;
        
        barImage.fillAmount += increaseAmount; 
        _barValue = barImage.fillAmount;
        if (barImage.fillAmount == 1f)
        {
            selectItemButton.enabled = true;
            // newItemFx.Play();
        }
        
        _winCount--;
        SaveSystem.SaveRewards(this);
        UpdateWinCountText();
        
        
        
    }

    private void Update()
    {
        if (_playerData.IsListEmpty() && itemBar.activeSelf)
        {
            itemBar.SetActive(false);
        }
        
        if ((System.DateTime.Now.TimeOfDay - InitiatedTime).Minutes >= minuteReset )
        {
            InitiatedTime= System.DateTime.Now.TimeOfDay;
            _winCount = maxWinCount;
            UpdateWinCountText();
            SaveSystem.SaveRewards(this);

        }

        if (!newItemFx.isPlaying && barImage.fillAmount == 1f)
        {
            PlayFx();
            selectItemButton.enabled = true;
        }

    }

    public void CollectItem()
    {
        selectItemButton.enabled = false;
        barImage.fillAmount -= 1f;
        _barValue = barImage.fillAmount;
        SaveSystem.SaveRewards(this);

        _playerData.AddOwnedMarkers(_playerData.GetFirstItem());
        _playerData.RemoveFirstItem();
        newItemFx.Stop();

        UpdateNextImage();

    }


    public void PlayFx()
    {
        newItemFx.Play();

    }
    
}
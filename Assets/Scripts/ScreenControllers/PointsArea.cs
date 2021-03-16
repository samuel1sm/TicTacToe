using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PointsArea : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI firstPlayerText;
    [SerializeField] private TextMeshProUGUI secondPlayerText;

    private static int _firstPlayerPoints = 0;
    private static int _secondPlayerPoints = 0;

    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        firstPlayerText.text = _firstPlayerPoints.ToString();
        secondPlayerText.text = _secondPlayerPoints.ToString();
    }

    private void Start()
    {
        gameManager.EndGame += IncreaseScore;
    }

    private void IncreaseScore(int obj)
    {
        switch (obj)
        {
            case -1:
                _firstPlayerPoints++;
                break;
            case 1:
                _secondPlayerPoints++;
                break;
        }

        print(obj);
        firstPlayerText.text = _firstPlayerPoints.ToString();
        secondPlayerText.text = _secondPlayerPoints.ToString();
    }
}

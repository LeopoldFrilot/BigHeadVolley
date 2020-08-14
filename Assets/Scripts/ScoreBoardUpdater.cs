﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoardUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI P1Score;
    [SerializeField] TextMeshProUGUI P2Score;
    [SerializeField] TextMeshProUGUI RoundTracker;
    [SerializeField] TextMeshProUGUI Timer;

    public void Start()
    {
        PopulatePoints();
        ShowRound();
    }
    public void Update()
    {
        ShowTime();
    }

    void ShowTime()
    {
        Timer.text = "Time " + Mathf.CeilToInt(Mathf.Clamp(FindObjectOfType<GameTimer>().GameTime, 0, 1000f));
    }

    void PopulatePoints()
    {
        P1Score.text = SceneStatics.P1Points.ToString();
        P2Score.text = SceneStatics.P2Points.ToString();
    }
    void ShowRound()
    {
        RoundTracker.text = "Round " + SceneStatics.RoundNum;
    }
}
using System.Collections;
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
        Timer.text = "Time " + Mathf.CeilToInt(Mathf.Clamp(FindObjectOfType<GameTimer>().gameTime, 0, 1000f));
    }

    void PopulatePoints()
    {
        P1Score.text = SceneStatics.p1Points.ToString();
        P2Score.text = SceneStatics.p2Points.ToString();
    }
    void ShowRound()
    {
        RoundTracker.text = "Round " + SceneStatics.GetRoundNum();
    }
}

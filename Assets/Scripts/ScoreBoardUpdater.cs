using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoardUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI P1Score;
    [SerializeField] TextMeshProUGUI P2Score;
    [SerializeField] TextMeshProUGUI P1Sets;
    [SerializeField] TextMeshProUGUI P2Sets;
    [SerializeField] TextMeshProUGUI Timer;

    public void Start()
    {
        PopulatePoints();
        ShowSets();
    }
    public void Update()
    {
        ShowTime();
    }

    void ShowTime()
    {
        Timer.text = Mathf.CeilToInt(Mathf.Clamp(FindObjectOfType<GameTimer>().gameTime, 0, 99f)).ToString();
    }

    void PopulatePoints()
    {
        P1Score.text = SceneStatics.p1Points.ToString();
        P2Score.text = SceneStatics.p2Points.ToString();
    }
    void ShowSets()
    {
        P1Sets.text = SceneStatics.p1SetWins.ToString();
        P2Sets.text = SceneStatics.p2SetWins.ToString();
    }
}

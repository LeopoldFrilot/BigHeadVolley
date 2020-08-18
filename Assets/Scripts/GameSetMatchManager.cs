using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BallComponents;

public class GameSetMatchManager : MonoBehaviour
{
    [SerializeField] int maxPointsPerSet;
    [SerializeField] int targetSetsPerMatch;
    bool awardedPoints = false;
    bool matchWon = false;

    public void EndPoint()
    {
        if (awardedPoints == true) return;
        FindObjectOfType<Ball>().gameObject.layer = 12;
        awardedPoints = true;
        StartCoroutine(AwardPoints());
    }
    IEnumerator AwardPoints()
    {
        if (FindObjectOfType<Net>().IsBallLeftOfNet() == true)
        {
            SceneStatics.p2Points++;
            if (SceneStatics.p2Points >= maxPointsPerSet)
            {
                SceneStatics.p2SetWins++;
                if (SceneStatics.p2SetWins >= targetSetsPerMatch)
                {
                    WinMatch();
                }
                else
                {
                    ResetSet();
                }
            }
        }
        else
        {
            SceneStatics.p1Points++;
            if (SceneStatics.p1Points >= maxPointsPerSet)
            {
                SceneStatics.p1SetWins++;
                if (SceneStatics.p1SetWins >= targetSetsPerMatch)
                {
                    WinMatch();
                }
                else
                {
                    ResetSet();
                }
            }
        }

        yield return new WaitForSeconds(1f);

        if (matchWon)
        {
            FindObjectOfType<SceneSwitcher>().LoadNextScene();
        }
        else
        {
            FindObjectOfType<SceneSwitcher>().ReloadScene(); // Reset game
        }
    }
    public void ResetSet()
    {
        SceneStatics.p1Points = 0;
        SceneStatics.p2Points = 0;
    }
    public void WinMatch()
    {
        ResetSet();
        SceneStatics.p1SetWins = 0;
        SceneStatics.p2SetWins = 0;
        matchWon = true;
    }
}

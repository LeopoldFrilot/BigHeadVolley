using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerComponents.Abilities;
using BallComponents;

public class AIOpponent : MonoBehaviour
{
    [SerializeField] [Range(1f, 2f)] float distanceBuffer;
    [SerializeField] [Range(0, .5f)] float horizontalMovementLockTime;
    PlayerAbilities PA;
    Ball ball;
    float curLock = 0;
    public void Start()
    {
        PA = GetComponent<PlayerAbilities>();
        ball = FindObjectOfType<Ball>();
    }

    public void Update()
    {
        if (FindObjectOfType<Net>().IsBallLeftOfNet() == false)
        {
            Act();
        }
        else
        {
            PA.SetMove(0);
        }
        curLock -= Time.deltaTime;
    }
    void Act()
    {
        if (curLock <= Mathf.Epsilon)
        {
            if (transform.position.x - distanceBuffer < ball.transform.position.x)
            {
                PA.SetMove(1f);
            }
            else
            {
                PA.SetMove(-1f);
            }
            curLock = horizontalMovementLockTime;
        }
        if (CheckChances(5f))
        {
            SpecialAct();
        }
    }
    void SpecialAct()
    {
        if (CheckChances(5f))
        {
            PA.SetActiveHit();
        }
        if (CheckChances(10f))
        {
            PA.SetJump();
        }
    }
    bool CheckChances(float percentageChance)
    {
        if (Random.Range(0, 100f) <= percentageChance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

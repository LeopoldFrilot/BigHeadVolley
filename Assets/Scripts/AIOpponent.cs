using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerComponents.Abilities;

public class AIOpponent : MonoBehaviour
{
    [SerializeField] float distanceBuffer;
    PlayerAbilities PA;
    MiddleDetector MD;
    Ball ball;
    void Start()
    {
        PA = GetComponent<PlayerAbilities>();
        MD = FindObjectOfType<MiddleDetector>();
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        if (MD.IsBallLeftOfNet == false) Act();
        else PA.SetMove(0);
    }
    void Act()
    {
        if (transform.position.x - distanceBuffer < ball.transform.position.x)
        {
            PA.SetMove(1f);
        }
        else
        {
            PA.SetMove(-1f);
            if (Random.Range(0, 100) == 0)
            {
                PA.SetJump();
            }
        }
    }
}

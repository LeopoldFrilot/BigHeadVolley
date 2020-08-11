using UnityEngine;
using System.Collections;

public class MiddleDetector : MonoBehaviour
{
    GameObject ball;
    bool _isBallLeftOfNet;

    public void Start()
    {
        ball = FindObjectOfType<Ball>().gameObject;
    }
    public void Update()
    {
        IsBallLeftOfNet = ManageBallSideState();
    }
    bool ManageBallSideState()
    {
        if (ball.transform.position.x < transform.position.x) return true;
        else return false;
    }

    public bool IsBallLeftOfNet { get => _isBallLeftOfNet; set => _isBallLeftOfNet = value; }

}

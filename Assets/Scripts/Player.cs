using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    Ball ball;

    [SerializeField] bool _isGrounded;
    [SerializeField] int _playerNumber;
    [SerializeField] int _numHits;
    public void Start()
    {
        ball = FindObjectOfType<Ball>();
    }
    public Ball GetBall()
    {
        return ball;
    }
    public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
    public int PlayerNumber { get => _playerNumber; set => _playerNumber = value; }
    public int NumHits { get => _numHits; set => _numHits = value; }
}

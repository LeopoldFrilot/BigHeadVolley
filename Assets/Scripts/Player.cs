using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    GroundedDetector GD;

    [SerializeField] bool _isGrounded;
    [SerializeField] int _playerNumber;
    public void Start()
    {
        GD = GetComponent<GroundedDetector>();
    }
    public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
    public int PlayerNumber { get => _playerNumber; set => _playerNumber = value; }
}

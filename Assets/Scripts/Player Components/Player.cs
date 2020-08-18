using UnityEngine;
using System.Collections;

namespace PlayerComponents
{
    public class Player : MonoBehaviour
    {
        [SerializeField] PlayerCard card;
        [SerializeField] bool _isGrounded = false;
        [SerializeField] int _playerNumber = 0;
        [SerializeField] int _numHits = 0;
        public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
        public int PlayerNumber { get => _playerNumber; set => _playerNumber = value; }
        public int NumHits { get => _numHits; set => _numHits = value; }
        public PlayerCard Card { get => card; private set => card = value; }
    }
}

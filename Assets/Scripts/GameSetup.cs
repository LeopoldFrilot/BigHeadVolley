using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] Player _player1;
    [SerializeField] Player _player2;
    MiddleDetector middle;
    public void Awake()
    {
        middle = FindObjectOfType<MiddleDetector>();
        foreach (Player player in FindObjectsOfType<Player>())
        {
            if (player.transform.position.x < middle.transform.position.x)
            {
                Player1 = player;
                player.PlayerNumber = 1;
            }
            else
            {
                Player2 = player;
                player.PlayerNumber = 2;
            }
        }
    }
    public Player Player1 { get => _player1; private set => _player1 = value; }
    public Player Player2 { get => _player2; private set => _player2 = value; }

}
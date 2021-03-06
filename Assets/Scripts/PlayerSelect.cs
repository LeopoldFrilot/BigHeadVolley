﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerComponents;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] Player _player1;
    [SerializeField] Player _player2;
    Net net;
    public void Awake()
    {
        net = FindObjectOfType<Net>();
        foreach (Player player in FindObjectsOfType<Player>())
        {
            if (player.transform.position.x < net.transform.position.x)
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
    public Player GetOtherPlayer(Player player)
    {
        if (player == Player1) return Player2;
        else return Player1;
    }
    public Player Player1 { get => _player1; private set => _player1 = value; }
    public Player Player2 { get => _player2; private set => _player2 = value; }

}
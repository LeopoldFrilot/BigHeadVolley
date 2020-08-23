using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayWin : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public void Start()
    {
        if (SceneStatics.winner == 1)
        {
            text.text = "Player 1 Wins!\n\nPlay Again?";
        }
        else if (SceneStatics.winner == 2)
        {
            text.text = "Player 2 Wins!\n\nPlay Again?";
        }
        else
        {
            text.text = "Game Over!\n\nPlay Again?";
        }
    }
}

using PlayerComponents;
using PlayerComponents.Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownGraphicsManager : MonoBehaviour
{
    [SerializeField] Slider p1AHCDSlider;
    [SerializeField] Slider p2AHCDSlider;
    Player player1;
    Player player2;
    public void Start()
    {
        player1 = FindObjectOfType<PlayerSelect>().Player1;
        player2 = FindObjectOfType<PlayerSelect>().Player2;
    }
    public void Update()
    {
        p1AHCDSlider.value = player1.GetComponent<ActiveHit>().GetCooldownPercentage();
        p2AHCDSlider.value = player2.GetComponent<ActiveHit>().GetCooldownPercentage();
    }
}

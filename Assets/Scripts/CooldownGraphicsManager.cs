using PlayerComponents;
using PlayerComponents.Abilities;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownGraphicsManager : MonoBehaviour
{
    [SerializeField] Slider p1AHCDSlider;
    [SerializeField] Slider p2AHCDSlider;
    [SerializeField] Slider p1SACDSlider;
    [SerializeField] TextMeshProUGUI p1SAType;
    [SerializeField] Slider p2SACDSlider;
    [SerializeField] TextMeshProUGUI p2SAType;
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
        p1SACDSlider.value = player1.GetComponent<SpecialAbility>().GetCDPercent();
        p1SAType.text = player1.Card.specialAbility.ToString();
        p2SACDSlider.value = player2.GetComponent<SpecialAbility>().GetCDPercent();
        p2SAType.text = player2.Card.specialAbility.ToString();
    }
}

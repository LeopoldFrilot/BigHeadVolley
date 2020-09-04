using PlayerComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsSelector : MonoBehaviour
{
    // Head
    public void SetHeadColorRed()
    {
        Player player = FindObjectOfType<Player>();
        player.Card.headColor = Color.red;
        Reload();
    }
    public void SetHeadColorCyan()
    {
        Player player = FindObjectOfType<Player>();
        player.Card.headColor = Color.cyan;
        Reload();
    }
    public void SetHeadColorYellow()
    {
        Player player = FindObjectOfType<Player>();
        player.Card.headColor = Color.yellow;
        Reload();
    }

    // Body
    public void SetBodyColorBlue()
    {
        Player player = FindObjectOfType<Player>();
        player.Card.bodyColor = Color.blue;
        Reload();
    }
    public void SetBodyColorGreen()
    {
        Player player = FindObjectOfType<Player>();
        player.Card.bodyColor = Color.green;
        Reload();
    }
    public void SetBodyColorMagenta()
    {
        Player player = FindObjectOfType<Player>();
        player.Card.bodyColor = Color.magenta;
        Reload();
    }

    //Legs
    public void SetBodyColorGrey()
    {
        Player player = FindObjectOfType<Player>();
        player.Card.legsColor = Color.grey;
        Reload();
    }
    public void SetBodyColorWhite()
    {
        Player player = FindObjectOfType<Player>();
        player.Card.legsColor = Color.white;
        Reload();
    }
    public void SetBodyColorBlack()
    {
        Player player = FindObjectOfType<Player>();
        player.Card.legsColor = Color.black;
        Reload();
    }
    //Ability
    public void SetSpike()
    {
        Player player = FindObjectOfType<Player>();
        player.Card.specialAbility = PlayerCard.SpecialAbility.Spike;
    }
    public void SetGrowth()
    {
        Player player = FindObjectOfType<Player>();
        player.Card.specialAbility = PlayerCard.SpecialAbility.Growth;
    }
    public void SetWarpStrike()
    {
        Player player = FindObjectOfType<Player>();
        player.Card.specialAbility = PlayerCard.SpecialAbility.Warp;
    }

    void Reload()
    {
        Player player = FindObjectOfType<Player>();
        player.GetComponent<PartsManager>().LoadPlayerAttributes();
    }
}

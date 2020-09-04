using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCard", menuName = "New Player Card")]
public class PlayerCard : ScriptableObject
{
    public Color headColor;
    public Color bodyColor;
    public Color legsColor;
    public enum SpecialAbility { Spike, Warp, Growth};
    public SpecialAbility specialAbility;
}

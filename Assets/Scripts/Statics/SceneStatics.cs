using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStatics
{
    public static int p1Points;
    public static int p2Points;
    public static int p1SetWins;
    public static int p2SetWins;
    public static int winner;
    public static int GetRoundNum()
    {
        return p1SetWins + p2SetWins + 1;
    }
    // Audience
    public static int[,] audiencePresence;
    public static int seed;
    public static float threshold;
}

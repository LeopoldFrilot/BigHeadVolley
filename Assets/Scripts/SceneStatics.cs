using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStatics
{
    static int _p1Points;
    static int _p2Points;
    static int _p1Wins;
    static int _p2Wins;
    static int _roundNum;

    public static int P1Points { get => _p1Points; set => _p1Points = value; }
    public static int P2Points { get => _p2Points; set => _p2Points = value; }
    public static int P1Wins { get => _p1Wins; set => _p1Wins = value; }
    public static int P2Wins { get => _p2Wins; set => _p2Wins = value; }
    public static int RoundNum { get => _roundNum; set => _roundNum = value; }
}

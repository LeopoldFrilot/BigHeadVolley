using UnityEngine;
using System.Collections;
using BallComponents;

public class Net : MonoBehaviour
{
    public bool IsBallLeftOfNet()
    {
        if (FindObjectOfType<Ball>().transform.position.x < transform.position.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float maxTime;
    public float gameTime;
    bool ended = false;
    public void Start()
    {
        gameTime = maxTime;
    }
    void Update()
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= Mathf.Epsilon && ended == false)
        {
            ended = true;
            FindObjectOfType<GameSetMatchManager>().EndPoint();
        }
    }
}

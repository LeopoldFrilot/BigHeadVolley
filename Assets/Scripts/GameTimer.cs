using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float maxTime;
    float _time;
    bool ended = false;
    public void Start()
    {
        GameTime = maxTime;
    }
    void Update()
    {
        GameTime -= Time.deltaTime;
        if (GameTime <= Mathf.Epsilon && ended == false)
        {
            ended = true;
            FindObjectOfType<Ball>().EndPoint();
        }
    }
    public float GameTime { get => _time; set => _time = value; }
}

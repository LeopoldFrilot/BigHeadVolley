﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerComponents;

public class Ball : MonoBehaviour
{
    [SerializeField] [Range(0, 2)] float standardBounceDampening;
    [SerializeField] [Range(0, 2)] float groundBounceDampening;
    [SerializeField] [Range(6, 10)] float playerPassiveHitStrength;
    [SerializeField] [Range(0, 1)] float momentumScalar;
    [SerializeField] [Range(3, 8)] int maxNumHits;
    Rigidbody2D RB;
    List<Vector2> velocityList = new List<Vector2>();
    Vector2 curVel;
    [SerializeField] Vector2 _aveVelocity;
    [SerializeField] int _playerPossesion;
    Player player1, player2;


    public void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        player1 = FindObjectOfType<GameSetup>().Player1;
        player2 = FindObjectOfType<GameSetup>().Player2;
        if (FindObjectOfType<MiddleDetector>().IsBallLeftOfNet) PlayerPossesion = 1;
        else PlayerPossesion = 2;
    }
    public void FixedUpdate()
    {
        velocityList.Add(curVel);
        curVel = RB.velocity;
        UpdateVelocityList();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        var objectHit = collision.gameObject;
        if (objectHit.tag == "Player" && objectHit.GetComponent<Player>().NumHits < maxNumHits)  // The ball has collided with the player
        {
            objectHit.GetComponent<Player>().NumHits++;
            float magnitude = Mathf.Pow(CalculateVelocityMagnitude(), momentumScalar) + playerPassiveHitStrength;
            float angle = CalculateAngle(collision.transform);

            var resultX = magnitude * Mathf.Cos(angle);
            if (transform.position.x - collision.transform.position.x <= Mathf.Epsilon)
            {
                resultX *= -1f;
            }
            var resultY = magnitude * Mathf.Sin(angle);

            RB.velocity = new Vector2(resultX, resultY);
        }
        else if (objectHit.tag == "Horizontal Boundaries") // The ball has collided with forcefields
        {
            RB.velocity = new Vector2(AveVelocity.x * standardBounceDampening, AveVelocity.y * standardBounceDampening * -1);
        }
        else if (objectHit.tag == "Vertical Boundaries") // The ball has collided with the net or forcefields
        { 
            RB.velocity = new Vector2(AveVelocity.x * standardBounceDampening * -1, AveVelocity.y * standardBounceDampening);
        }
        else if (objectHit.tag == "Ground")
        {
            RB.velocity = new Vector2(AveVelocity.x * groundBounceDampening, AveVelocity.y * groundBounceDampening * -1);
            StartCoroutine(AwardPoints());
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MiddleDetector>())
        {
            if (collision.GetComponent<MiddleDetector>().IsBallLeftOfNet)
            {
                if (PlayerPossesion == 2) // Possesion switch, reset hits
                {
                    player2.NumHits = 0;
                }
                PlayerPossesion = 1;
            }
            else
            {
                if (PlayerPossesion == 1)
                {
                    player1.NumHits = 0;
                }
                PlayerPossesion = 2;
            }
        }
    }

    void UpdateVelocityList()
    {
        float maxItems = 5f;
        float xSum = 0;
        float ySum = 0;
        while (velocityList.Count > maxItems)
        {
            velocityList.RemoveAt(0);
        }
        foreach (Vector2 item in velocityList)
        {
            xSum += item.x;
            ySum += item.y;
        }
        AveVelocity = new Vector2(xSum / maxItems, ySum / maxItems);
    }
    float CalculateVelocityMagnitude()
    {
        return Mathf.Abs(Mathf.Sqrt(Mathf.Pow(AveVelocity.x, 2) + Mathf.Pow(AveVelocity.y, 2)));
    }
    float CalculateAngle(Transform collisionTrans)
    {
        float xDist = Mathf.Abs(transform.position.x - collisionTrans.position.x);
        float yDist = Mathf.Abs(transform.position.y - collisionTrans.position.y);
        return Mathf.Atan(yDist / xDist);
    }
    IEnumerator AwardPoints()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<SceneSwitcher>().ReloadScene();
    }
    public Vector2 AveVelocity { get => _aveVelocity; private set => _aveVelocity = value; }
    public int PlayerPossesion { get => _playerPossesion; set => _playerPossesion = value; }
}

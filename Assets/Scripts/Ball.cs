using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerComponents;
using PlayerComponents.Abilities;

public class Ball : MonoBehaviour
{
    [SerializeField] [Range(0, 2)] float standardBounceDampening;
    [SerializeField] [Range(0, 2)] float groundBounceDampening;
    [SerializeField] [Range(6, 10)] float playerPassiveHitStrength;
    [SerializeField] [Range(8, 15)] float playerActiveHitStrength;
    [SerializeField] [Range(0, 1)] float momentumScalar;
    [SerializeField] [Range(3, 8)] int maxNumHits;
    [SerializeField] int maxPointsPerRound;
    [SerializeField] int targetWinsPerRound;
    Rigidbody2D RB;
    List<Vector2> velocityList = new List<Vector2>();
    Vector2 curVel;
    [SerializeField] Vector2 _aveVelocity;
    Player player1, player2;
    bool awardedPoints = false;


    public void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        player1 = FindObjectOfType<GameSetup>().Player1;
        player2 = FindObjectOfType<GameSetup>().Player2;
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
        if (objectHit.tag == "Player")  // The ball has collided with the player
        {
            FindObjectOfType<GameSetup>().GetOtherPlayer(objectHit.GetComponent<Player>()).NumHits = 0;
            if (objectHit.GetComponent<Player>().NumHits >= maxNumHits)
            {
                EndPoint();
                return;
            }
            objectHit.GetComponent<Player>().NumHits++;
            float hitStrength;
            if (objectHit.GetComponent<ActiveHit>().IsActiveHitting == 1) hitStrength = playerActiveHitStrength;
            else hitStrength = playerPassiveHitStrength;
            float magnitude = Mathf.Pow(CalculateVelocityMagnitude(), momentumScalar) + hitStrength;
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
            if (awardedPoints == false) EndPoint();
        }
    }

    public void EndPoint()
    {
        awardedPoints = true;
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(AwardPoints());
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
        if (FindObjectOfType<MiddleDetector>().IsBallLeftOfNet == true)
        {
            SceneStatics.P2Points++;
            if (SceneStatics.P2Points >= maxPointsPerRound)
            {
                SceneStatics.P2Wins++;
                if (SceneStatics.P2Wins >= targetWinsPerRound)
                {
                    ResetGame();
                }
                else
                {
                    ResetRound();
                }
            }
        }
        else
        {
            SceneStatics.P1Points++;
            if (SceneStatics.P1Points >= maxPointsPerRound)
            {
                SceneStatics.P1Wins++;
                if (SceneStatics.P1Wins >= targetWinsPerRound)
                {
                    ResetGame();
                }
                else
                {
                    ResetRound();
                }
            }
        }
        yield return new WaitForSeconds(1f);
        FindObjectOfType<SceneSwitcher>().ReloadScene();
    }
    public void ResetRound()
    {
        SceneStatics.P1Points = 0;
        SceneStatics.P2Points = 0;
    }
    public void ResetGame()
    {
        ResetRound();
        SceneStatics.P1Wins = 0;
        SceneStatics.P2Wins = 0;
        FindObjectOfType<SceneSwitcher>().LoadNextScene();
    }
    public Vector2 AveVelocity { get => _aveVelocity; private set => _aveVelocity = value; }
}

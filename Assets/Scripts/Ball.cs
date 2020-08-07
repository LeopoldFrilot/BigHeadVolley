using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] float standardBounceDampening;
    [SerializeField] float groundBounceDampening;
    [SerializeField] float playerPassiveHitStrength;
    Rigidbody2D RB;
    List<Vector2> velocityList = new List<Vector2>();
    Vector2 curVel;
    [SerializeField] Vector2 _aveVelocity;


    public void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        velocityList.Add(curVel);
        curVel = RB.velocity;
        UpdateVelocityList();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<CircleCollider2D>())  // The ball has collided with the player
        {
            float magnitude = CalculateVelocityMagnitude() + playerPassiveHitStrength;
            float angle = CalculateAngle(collision.transform);

            var resultX = magnitude * Mathf.Cos(angle);
            if (transform.position.x - collision.transform.position.x <= Mathf.Epsilon)
            {
                resultX *= -1f;
            }
            var resultY = magnitude * Mathf.Sin(angle);

            RB.velocity = new Vector2(resultX, resultY);
        }
        else if (collision.tag == "Horizontal Boundaries") // The ball has collided with forcefields
        {
            RB.velocity = new Vector2(AveVelocity.x * standardBounceDampening, AveVelocity.y * standardBounceDampening * -1);
        }
        else if (collision.tag == "Vertical Boundaries") // The ball has collided with the net or forcefields
        {
            RB.velocity = new Vector2(AveVelocity.x * standardBounceDampening * -1, AveVelocity.y * standardBounceDampening);
        }
        else if (collision.tag == "Ground")
        {
            RB.velocity = new Vector2(AveVelocity.x * groundBounceDampening, AveVelocity.y * groundBounceDampening * -1);
            StartCoroutine(AwardPoints());
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
}

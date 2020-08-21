using UnityEngine;
using System.Collections;
using BallComponents;

namespace PlayerComponents.Abilities
{
    public class PassiveHit : MonoBehaviour
    {
        [SerializeField] [Range(6, 10)] float playerPassiveHitStrength;
        [SerializeField] [Range(8, 15)] float playerActiveHitStrength;
        [SerializeField] [Range(3, 8)] int maxNumHits;
        [SerializeField] [Range(0, 1)] float momentumScalar;
        Player player;

        public void Start()
        {
            player = GetComponent<Player>();
        }
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Ball>())  // The ball has collided with the player
            {
                var ballSpeed = collision.gameObject.GetComponent<BallSpeed>(); // The ball
                
                FindObjectOfType<PlayerSelect>().GetOtherPlayer(player).NumHits = 0;
                player.NumHits++;
                if (player.NumHits > maxNumHits)
                {
                    FindObjectOfType<GameSetMatchManager>().EndPoint();
                    return;
                }

                float hitStrength;
                if (GetComponent<ActiveHit>().isActiveHitting == 1)
                {
                    hitStrength = playerActiveHitStrength;
                    for (int i= 0; i < 5; i++)
                    {
                        FindObjectOfType<SoundPlayer>().PlayDesignatedClip("BallHit2", 1f);
                    }
                }
                else
                {
                    hitStrength = playerPassiveHitStrength;
                    for (int i = 0; i < 2; i++)
                    {
                        FindObjectOfType<SoundPlayer>().PlayDesignatedClip("BallHit2", 1f);
                    }
                }

                float magnitude = Mathf.Pow(ballSpeed.CalculateBallVelocityMagnitude(), momentumScalar) + hitStrength;
                float angle = CalculateAngle(ballSpeed.transform);

                var resultX = magnitude * Mathf.Cos(angle);
                if (transform.position.x - collision.transform.position.x >= Mathf.Epsilon)
                {
                    resultX *= -1f;
                }
                var resultY = magnitude * Mathf.Sin(angle);

                ballSpeed.GetComponent<Rigidbody2D>().velocity = new Vector2(resultX, resultY);
            }
        }
        
        float CalculateAngle(Transform collisionTrans)
        {
            Transform head = transform.GetChild(0);
            float xDist = Mathf.Abs(head.position.x - collisionTrans.position.x);
            float yDist = Mathf.Abs(head.position.y - collisionTrans.position.y);
            return Mathf.Atan(yDist / xDist);
        }
    }
}


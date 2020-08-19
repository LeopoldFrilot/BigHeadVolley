using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallComponents
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] [Range(0, 2)] float standardBounceDampening;
        [SerializeField] [Range(0, 2)] float groundBounceDampening;
        Rigidbody2D RB;

        public void Start()
        {
            gameObject.layer = 11;
            RB = GetComponent<Rigidbody2D>();
        }
        public void OnCollisionEnter2D(Collision2D collision)
        {
            var BS = GetComponent<BallSpeed>();
            var objectHit = collision.gameObject;
            if (objectHit.tag == "Horizontal Boundaries") // The ball has collided with forcefields
            {
                RB.velocity = new Vector2(BS.aveVelocity.x * standardBounceDampening, BS.aveVelocity.y * standardBounceDampening * -1);
                FindObjectOfType<SoundPlayer>().PlayDesignatedClip("BallHit3", .4f);
            }
            else if (objectHit.tag == "Vertical Boundaries" || objectHit.tag == "Net") // The ball has collided with the net or forcefields
            {
                RB.velocity = new Vector2(BS.aveVelocity.x * standardBounceDampening * -1, BS.aveVelocity.y * standardBounceDampening);
                FindObjectOfType<SoundPlayer>().PlayDesignatedClip("BallHit1", .6f);
            }
            else if (objectHit.tag == "Ground")
            {
                RB.velocity = new Vector2(BS.aveVelocity.x * groundBounceDampening, BS.aveVelocity.y * groundBounceDampening * -1);
                FindObjectOfType<SoundPlayer>().PlayDesignatedClip("BallHit3", .8f);
                FindObjectOfType<GameSetMatchManager>().EndPoint();
            }
        }
    }
}


using UnityEngine;
using System.Collections;
using BallComponents;
using System.Security.Cryptography;

namespace PlayerComponents.Abilities
{
    public class SpecialAbility : MonoBehaviour
    { 
        [Header("Spike")]
        [SerializeField] float spikeCD;
        [SerializeField] Vector2 spikeOffset;
        [SerializeField] AudioClip spikeSFX;
        [Header("Growth")]
        [SerializeField] float growthCD;
        [SerializeField] AudioClip growthSFX;
        [Header("Warp Strike")]
        [SerializeField] float warpStrikeCD;
        [SerializeField] AudioClip warpSFX;
        [SerializeField] AudioClip warpWindupSFX;
        float CD = 2f;
        float timeTillOffCooldown = 2f;
        Animator animator;
        Ball ball;
        Vector3 hang = Vector3.zero;

        public void Start()
        {
            animator = GetComponent<Animator>();
            ball = FindObjectOfType<Ball>();
        }

        public void Update()
        {
            if (timeTillOffCooldown > Mathf.Epsilon)
            {
                timeTillOffCooldown -= Time.deltaTime;
            }
            if (hang != Vector3.zero)
            {
                transform.position = hang;
            }
        }
        public void ActivateAbility()
        {
            if (timeTillOffCooldown > Mathf.Epsilon)
            {
                return;
            }
            var ability = GetComponent<Player>().Card.specialAbility;
            switch (ability)
            {
                case PlayerCard.SpecialAbility.Spike:
                    Spike();
                    break;
                case PlayerCard.SpecialAbility.Growth:
                    Growth();
                    break;
                case PlayerCard.SpecialAbility.Warp:
                    WarpStrike();
                    break;
            }
        }
        void Spike()
        {
            if (!ball.IsBallOnYourSide(GetComponent<Player>().PlayerNumber)) return;
            CD = spikeCD;
            timeTillOffCooldown = CD;

            if (GetComponent<Player>().PlayerNumber == 1)
            {
                transform.position = ball.transform.position + new Vector3(-spikeOffset.x, spikeOffset.y, 0);
                hang = transform.position;
            }
            else
            {
                transform.position = ball.transform.position + new Vector3(spikeOffset.x, spikeOffset.y, 0);
                hang = transform.position;
            }
            animator.SetTrigger("Spike");
            FindObjectOfType<SoundPlayer>().PlayClip(spikeSFX, 1f);
        }
        void Growth()
        {
            CD = growthCD;
            timeTillOffCooldown = CD;
            animator.SetTrigger("Growth");
            FindObjectOfType<SoundPlayer>().PlayClip(growthSFX, 1f);
        }
        void WarpStrike()
        {
            if (!ball.IsBallOnYourSide(GetComponent<Player>().PlayerNumber)) return;
            CD = warpStrikeCD;
            timeTillOffCooldown = CD;
            hang = transform.position;
            animator.SetTrigger("Warp");
            FindObjectOfType<SoundPlayer>().PlayClip(warpWindupSFX, 1f);
        }
        public void Warp()
        {
            FindObjectOfType<PlayerSelect>().GetOtherPlayer(GetComponent<Player>()).NumHits = 0;
            ball.transform.position = new Vector3(
                ball.transform.position.x * -1f, 
                ball.transform.position.y, 
                ball.transform.position.z);
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(-ball.GetComponent<Rigidbody2D>().velocity.x, ball.GetComponent<Rigidbody2D>().velocity.y);
            FindObjectOfType<SoundPlayer>().PlayClip(warpSFX, 1f);
        }
        public void PauseBall()
        {
            ball.SetBallPaused();
        }
        public void ResumeBall()
        {
            ball.SetBallResumed();
        }
        public float GetCDPercent()
        {
            return timeTillOffCooldown / CD;
        }
        public void ResumeMovement()
        {
            hang = Vector3.zero;
        }
    }
}


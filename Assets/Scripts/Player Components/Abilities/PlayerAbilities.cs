using UnityEngine;

namespace PlayerComponents.Abilities
{
    public class PlayerAbilities : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float jumpHeight;
        Player player;
        Net MD;
        float curDirection;
        Rigidbody2D RB;
        public void Start()
        {
            RB = GetComponent<Rigidbody2D>();
            player = GetComponent<Player>();
            MD = FindObjectOfType<Net>();
        }
        public void Update()
        {
            Move();
            Clamp();
        }
        void Jump()
        {
            if (!player.IsGrounded) return;
            RB.velocity = new Vector2(RB.velocity.x, jumpHeight);
        }
        void Move()
        {
            transform.position += Vector3.right * curDirection * speed * Time.deltaTime;
        }
        void Clamp()
        {
            if (player.PlayerNumber == 1)
            {
                if (transform.position.x >= MD.transform.position.x)
                {
                    transform.position = new Vector2(MD.transform.position.x - .1f, transform.position.y);
                }
            }
            else
            {
                if (transform.position.x <= MD.transform.position.x)
                {
                    transform.position = new Vector2(MD.transform.position.x + .1f, transform.position.y);
                }
            }
        }

        public void SetMove(float direction)
        {
            curDirection = direction;
        }
        public void SetJump()
        {
            Jump();
        }
        public void SetActiveHit()
        {
            GetComponent<ActiveHit>().SetActiveHit();
        }
        public void SetSpecialAbility()
        {
            GetComponent<SpecialAbility>().ActivateAbility();
        }
    }
}


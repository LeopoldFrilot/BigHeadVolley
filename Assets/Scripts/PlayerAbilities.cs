using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    float curDirection;
    Rigidbody2D RB;
    public void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        Move();
    }
    private void Jump()
    {
        RB.velocity = new Vector2(RB.velocity.x, jumpHeight);
    }
    private void Move()
    {
        transform.position += Vector3.right * curDirection * speed * Time.deltaTime;
    }


    public void SetMove(float direction)
    {
        curDirection = direction;
    }
    public void SetJump()
    {
        Jump();
    }
}

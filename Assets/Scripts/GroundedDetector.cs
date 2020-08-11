using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedDetector : MonoBehaviour
{
    Player player;
    public void Start()
    {
        player = GetComponent<Player>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") player.IsGrounded = true;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") player.IsGrounded = false;
    }
}

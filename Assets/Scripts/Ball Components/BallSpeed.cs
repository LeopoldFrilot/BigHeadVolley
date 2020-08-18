using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallComponents
{
    public class BallSpeed : MonoBehaviour
    {
        Rigidbody2D RB;
        List<Vector2> velocityList = new List<Vector2>();
        Vector2 curVel;
        public Vector2 aveVelocity;


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
        public float CalculateBallVelocityMagnitude()
        {
            return Mathf.Abs(Mathf.Sqrt(Mathf.Pow(aveVelocity.x, 2) + Mathf.Pow(aveVelocity.y, 2)));
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
            aveVelocity = new Vector2(xSum / maxItems, ySum / maxItems);
        }
    }
}


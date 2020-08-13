using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerComponents
{
    public class PartsManager : MonoBehaviour
    {
        [SerializeField] Color headColor;
        [SerializeField] Color bodyColor;
        [SerializeField] Color legsColor;
        [SerializeField] GameObject head;
        [SerializeField] GameObject body;
        [SerializeField] GameObject legs;
        public void Start()
        {
            LoadHead();
            LoadBody();
            LoadLegs();
        }
        void LoadHead()
        {
            head.GetComponent<SpriteRenderer>().color = headColor;
        }
        void LoadBody()
        {
            body.GetComponent<SpriteRenderer>().color = bodyColor;
        }
        void LoadLegs()
        {
            legs.GetComponent<SpriteRenderer>().color = legsColor;
        }
    }
}

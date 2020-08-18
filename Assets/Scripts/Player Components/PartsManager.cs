using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerComponents
{
    public class PartsManager : MonoBehaviour
    {
        [SerializeField] GameObject head;
        [SerializeField] GameObject body;
        [SerializeField] GameObject legs;
        Player player;
        public void Start()
        {
            player = GetComponent<Player>();
            LoadPlayerAttributes();
        }
        public void LoadPlayerAttributes()
        {
            LoadHead();
            LoadBody();
            LoadLegs();
        }
        void LoadHead()
        {
            head.GetComponent<SpriteRenderer>().color = player.Card.headColor;
        }
        void LoadBody()
        {
            body.GetComponent<SpriteRenderer>().color = player.Card.bodyColor;
        }
        void LoadLegs()
        {
            legs.GetComponent<SpriteRenderer>().color = player.Card.legsColor;
        }
    }
}

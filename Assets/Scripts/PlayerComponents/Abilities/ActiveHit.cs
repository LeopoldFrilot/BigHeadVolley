using UnityEngine;
using System.Collections;

namespace PlayerComponents.Abilities
{
    public class ActiveHit : MonoBehaviour
    {
        [SerializeField] int isActiveHitting = 0;
        [SerializeField] float cooldown;
        [SerializeField] float timeTillOffCooldown = 0;

        public void Update()
        {
            if (timeTillOffCooldown > Mathf.Epsilon) timeTillOffCooldown -= Time.deltaTime;
        }
        public void SetActiveHit()
        {
            if (timeTillOffCooldown > Mathf.Epsilon) return;
            GetComponent<Animator>().SetTrigger("ActiveHit");
            timeTillOffCooldown = cooldown;
        }
        public int IsActiveHitting { get => isActiveHitting; set => isActiveHitting = Mathf.Clamp(value, 0, 1); }

    }
}


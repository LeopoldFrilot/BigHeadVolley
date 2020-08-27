using UnityEngine;
using System.Collections;

namespace PlayerComponents.Abilities
{
    public class ActiveHit : MonoBehaviour
    {
        public int isActiveHitting = 0;
        [SerializeField] float cooldown;
        float timeTillOffCooldown = 0;

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
        public void AnimationSetActiveHit(int binaryVal)
        {
            isActiveHitting = Mathf.Clamp(binaryVal, 0, 1);
            // Lag here
        }
        public float GetCooldownPercentage()
        {
            return timeTillOffCooldown / cooldown;
        }
    }
}


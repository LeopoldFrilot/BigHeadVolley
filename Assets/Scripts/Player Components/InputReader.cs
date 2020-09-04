using UnityEngine;
using UnityEngine.InputSystem;
using PlayerComponents.Abilities;

namespace PlayerComponents
{
    public class InputReader : MonoBehaviour, Controls.IPlayerActions
    {
        Controls controls;
        PlayerAbilities PA;

        public void Awake()
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this); // This script will be able to use Player Action map
        }
        public void Start()
        {
            PA = GetComponent<PlayerAbilities>();
        }
        private void OnEnable()
        {
            controls.Player.Enable();
        }
        private void OnDisable()
        {
            controls.Player.Disable();
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                PA.SetJump();
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            float direction = context.ReadValue<float>();
            PA.SetMove(context.ReadValue<float>());
        }

        public void OnActiveHit(InputAction.CallbackContext context)
        {
            if (context.started) PA.SetActiveHit();
        }

        public void OnSpecialAbility(InputAction.CallbackContext context)
        {
            if (context.started) PA.SetSpecialAbility();
        }
    }
}

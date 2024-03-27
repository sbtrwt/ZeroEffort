using FPSShooter.InputSystem;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FPSShooter.InputSystem
{
    public class InputService
    {
        private PlayerInputAction playerInputActions;

        public static event Action<Vector2> OnMove;
        public static event Action OnSprint;
        public static event Action OnSprintCanceled;
        public InputService()
        {
            return;
            if (playerInputActions == null)
            {
                playerInputActions = new PlayerInputAction();
                playerInputActions.Player.Enable();
                playerInputActions.Player.Sprint.performed += Sprint_performed;
                playerInputActions.Player.Sprint.canceled += Sprint_canceled;
            }
        }

        private void Sprint_canceled(InputAction.CallbackContext obj)
        {
            return;
            OnSprintCanceled?.Invoke();
        }

        private void Sprint_performed(InputAction.CallbackContext obj)
        {
            return;
            OnSprint?.Invoke();
        }

        public void Update()
        {
            return;
            Vector2 moveData = playerInputActions.Player.Movement.ReadValue<Vector2>();

            OnMove?.Invoke(moveData);

            if (Mouse.current != null)
            {
                Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            }
        }

        ~InputService()
        {
            return;
            playerInputActions.Player.Sprint.performed -= Sprint_performed;
            playerInputActions.Player.Sprint.canceled -= Sprint_canceled;
        }
    }
}
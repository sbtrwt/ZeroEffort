using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FPSShooter.InputSystem
{
    public class InputService
    {
        private PlayerInputAction playerInputActions;

        private Action<Vector2> OnMove;

        public InputService()
        {
            if (playerInputActions == null)
            {
                playerInputActions = new PlayerInputAction();
                playerInputActions.Player.Enable();
            }
        }

        public void Update()
        {
            Vector2 moveData = playerInputActions.Player.Movement.ReadValue<Vector2>();
            OnMove?.Invoke(moveData);

            if (Mouse.current != null)
            {
                Vector2 mouseDelta = Mouse.current.delta.ReadValue();
                Debug.Log("Mouse Delta: " + mouseDelta);
            }
        }
        public void SetOnMove(Action<Vector2> onMove)
        {
            OnMove += onMove;
        }
    }
}

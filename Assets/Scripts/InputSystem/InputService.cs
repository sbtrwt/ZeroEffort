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

        public static event Action OnJump;
        public InputService()
        {
            if (playerInputActions == null)
            {
                playerInputActions = new PlayerInputAction();
                playerInputActions.Player.Enable();
                playerInputActions.Player.Jump.started += Jump_started; ;
            }
        }

        private void Jump_started(InputAction.CallbackContext obj)
        {
            OnJump?.Invoke();
        }

        public void Update()
        {
            Vector2 moveData = playerInputActions.Player.Movement.ReadValue<Vector2>();

            OnMove?.Invoke(moveData);

            if (Mouse.current != null)
            {
                Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            }
        }

        //public void SetOnMove(Action<Vector3> onMove)
        //{
        //    OnMove += onMove;
        //}

        //public void SetOnJump(Action OnJump)
        //{
        //    this.OnJump += OnJump;
        //}

        ~InputService()
        {
            playerInputActions.Player.Jump.started -= Jump_started;
        }
    }
}
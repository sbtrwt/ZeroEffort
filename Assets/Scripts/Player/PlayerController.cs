using FPSShooter.InputSystem;
using FPSShooter.Interfaces;
using UnityEngine;

namespace FPSShooter.Player
{
    public class PlayerController : IMovable
    {
        private PlayerView playerView;
        private PlayerModel playerModel;

        public PlayerController(PlayerModel model)
        {
            this.playerModel = model;
            InitView();

            InputService.OnJump += InputService_OnJump;
            InputService.OnMove += InputService_OnMove;
        }

        private void InputService_OnMove(Vector2 moveDelta)
        {
            OnMove(moveDelta);
        }

        private void InputService_OnJump()
        {
            OnJump();
        }

        public void InitView()
        {
            PlayerView playerPrefab = playerModel.PlayerSO.PlayerView;
            playerView = Object.Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
            playerView.SetController(this);
        }

        public void OnMove(Vector2 target)
        {
            playerView.Move(target, playerModel.PlayerSO.movementSpeed);
        }

        public void OnJump()
        {
            Debug.Log("calling Jump");
            playerView.Jump(Vector3.up * playerModel.PlayerSO.jumpForce);
        }

        ~PlayerController()
        {
            InputService.OnJump -= InputService_OnJump;
            InputService.OnMove -= InputService_OnMove;
        }
    }
}

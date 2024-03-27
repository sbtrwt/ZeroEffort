using FPSShooter.InputSystem;
using FPSShooter.Interfaces;
using UnityEngine;

namespace FPSShooter.Player
{
    public class PlayerController : IMovable
    {
        private PlayerView playerView;
        private PlayerModel playerModel;

        private float currSpeed;

        public PlayerController(PlayerModel model)
        {
            this.playerModel = model;
            InitView();

            currSpeed = playerModel.PlayerSO.walkSpeed;

            InputService.OnMove += InputService_OnMove;
            InputService.OnSprint += InputService_OnSprint;
            InputService.OnSprintCanceled += InputService_OnSprintCanceled;
        }

        private void InputService_OnSprintCanceled()
        {
            currSpeed = playerModel.PlayerSO.walkSpeed;
        }

        private void InputService_OnSprint()
        {
            currSpeed = playerModel.PlayerSO.runSpeed;
        }

        private void InputService_OnMove(Vector2 moveDelta)
        {
            OnMove(moveDelta);
        }


        public void InitView()
        {
            PlayerView playerPrefab = playerModel.PlayerSO.PlayerView;
            playerView = Object.Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
            //playerView.SetController(this);
        }

        public void OnMove(Vector2 target)
        {
            //playerView.Move(target, currSpeed);
        }

        public Transform GetCameraTargetTransform()
        {
            return null;
            //return playerView.GetCameraTarget();
        }

        ~PlayerController()
        {
            InputService.OnMove -= InputService_OnMove;
            InputService.OnSprint -= InputService_OnSprint;
            InputService.OnSprintCanceled -= InputService_OnSprintCanceled;
        }
    }
}

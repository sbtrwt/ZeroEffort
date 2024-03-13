using FPSShooter.Interfaces;
using FPSShooter.Player.Human;
using UnityEngine;

namespace FPSShooter.Player
{
    public class PlayerController: IMovable
    {
        private Player player;
        private PlayerView playerView;
        private PlayerModel playerModel;
        public PlayerController(PlayerModel model)
        {
            this.playerModel = model;
            player = new HumanPlayer();
            InitView();
        }
        public void InitView()
        {
            playerView = Object.Instantiate(playerModel.PlayerSO.PlayerView);
            playerView.SetController(this);
        }

        public void OnMove(Vector3 target)
        {
            player.OnMove(target);
            playerView.SetPosition(target);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPSShooter.Player.Human;

namespace FPSShooter.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        public PlayerService(PlayerModel playerModel)
        {
            playerController = new HumanPlayerController(playerModel);
        }
    }
}

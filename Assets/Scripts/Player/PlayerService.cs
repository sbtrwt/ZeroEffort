using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPSShooter.InputSystem;
using FPSShooter.Player.Human;

namespace FPSShooter.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private InputService inputService;

        public PlayerService(PlayerModel playerModel)
        {
            playerController = new HumanPlayerController(playerModel);
        }

        public void InjectDependencies(InputService inputService)
        {
            this.inputService = inputService;

        }

        public void Init()
        {
            //inputService.SetOnMove(playerController.OnMove);
            //inputService.SetOnJump(playerController.OnJump);
        }

        public PlayerController GetPlayerController()
        {
            return playerController;
        }


    }
}

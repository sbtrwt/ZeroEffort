using FPSShooter.InputSystem;
using FPSShooter.Player;
using System.Collections;
using System.Collections.Generic;

namespace FPSShooter.Main
{
    public class ServiceLocator 
    {
        private PlayerService playerService;
        private InputService inputService;

        private CameraService cameraService;
        public ServiceLocator(ServiceLocatorModel data)
        {
            InitializeServices(data);
            InjectDependencies();
        }

        private void InitializeServices(ServiceLocatorModel data)
        {
            cameraService = new CameraService(data.virtualCamera);
            playerService = new PlayerService(data.PlayerModel);
            inputService = new InputService();
        }

        private void InjectDependencies()
        {
            playerService.InjectDependencies(inputService);

            PlayerController playerController = playerService.GetPlayerController();

            cameraService.SetTarget(playerController.GetCameraTargetTransform());
        }

        public void Start()
        {
            playerService.Init();
        }

        public void Update()
        {
            inputService.Update();
        }
    }

}

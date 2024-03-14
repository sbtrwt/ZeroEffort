using FPSShooter.InputSystem;
using FPSShooter.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPSShooter.Main
{
    public class ServiceLocator 
    {
        private PlayerService playerService;
        private InputService inputService;
        public ServiceLocator(ServiceLocatorModel data)
        {
            InitializeServices(data);
            InjectDependencies();
        }
        private void InitializeServices(ServiceLocatorModel data)
        {
            playerService = new PlayerService(data.PlayerModel);
            inputService = new InputService();
        }

        private void InjectDependencies()
        {
            playerService.InjectDependencies(inputService);
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
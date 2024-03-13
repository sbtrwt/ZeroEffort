using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPSShooter.Main
{
    public class GameService : MonoBehaviour
    {
        private ServiceLocator serviceLocator;
        [SerializeField] private ServiceLocatorModel serviceLocatorData;

        private void Start()
        {
            serviceLocator = new ServiceLocator(serviceLocatorData);
            serviceLocator.Start();
        }
    }

}
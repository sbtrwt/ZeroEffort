using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPSShooter.Main
{
    public class ServiceLocator 
    {
        public ServiceLocator(ServiceLocatorModel data)
        {
            InitializeServices(data);
            InjectDependencies();
        }
        private void InitializeServices(ServiceLocatorModel data)
        {
         

        }

        private void InjectDependencies()
        {
           
        }
        public void Start()
        {
        }
        public void Update()
        {

        }
    }

}
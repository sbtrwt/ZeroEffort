using cowsins;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace FPSShooter.Enemy
{
    public class ZombieDisable : MonoBehaviour
    {
        [SerializeField] private List<GameObject> allZombies;

        private void Start()
        {
            PlayerStats.OnDead += PlayerStats_OnZombieDisable;
        }

        private void PlayerStats_OnZombieDisable()
        {
            foreach (var item in allZombies)
            {
                item.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            PlayerStats.OnDead -= PlayerStats_OnZombieDisable;
        }
    }
}





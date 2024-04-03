using cowsins;
using FPSShooter.Sound;
using System;
using UnityEngine;

namespace FPSShooter.Car
{
    public class CarParts : Interactable
    {
        public static event Action OnCarPartCollect;
        [SerializeField] private SoundSO soundSO;

        public override void Interact()
        {
            OnCarPartCollect?.Invoke();
            SoundManager.Instance.PlaySound(soundSO.interactionSound, 0, 0, false, 0, .8f);
            gameObject.SetActive(false);
        }
    }
}

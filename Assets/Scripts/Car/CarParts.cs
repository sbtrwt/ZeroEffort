using cowsins;
using System;
using UnityEngine;

namespace FPSShooter.Car
{
    public class CarParts : Interactable
    {
        public static event Action OnCarPartCollect;
        [SerializeField] private AudioClip audioClip;

        public override void Interact()
        {
            OnCarPartCollect?.Invoke();
            SoundManager.Instance.PlaySound(audioClip, 0, 0, false, 0, .5f);
            gameObject.SetActive(false);
        }
    }
}

using cowsins;
using FPSShooter.Sound;
using System;
using UnityEngine;
public class Keys : Interactable
{
    public static event Action<Keys> OnInteract;

    public int id;
    [SerializeField] private SoundSO soundSO;

    public override void Interact()
    {
        OnInteract?.Invoke(this);
        SoundManager.Instance.PlaySound(soundSO.interactionSound, 0, 0, false, 0, 1f);
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cowsins;
using System;
using FPSShooter.Sound;

public class Door : Interactable
{
    public static event Func<int, bool> OnInteract;

    private const string DOOR = "Door";

    [SerializeField] private Animator doorAnimator;
    [SerializeField] private int keyid;
    [SerializeField] private SoundSO soundSO;

    public override void Interact()
    {
        if (!(bool)OnInteract?.Invoke(keyid))
        {
            return;
        }
        SoundManager.Instance.PlaySound(soundSO.doorSound,0,0,false,0,1f);
        doorAnimator.Play(DOOR);
    }
}

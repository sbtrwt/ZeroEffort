using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cowsins;
using System;

public class Door : Interactable
{
    public static event Func<int, bool> OnInteract;

    private const string DOOR = "Door";

    [SerializeField] private Animator doorAnimator;
    [SerializeField] private int keyid;

    public override void Interact()
    {
        if (!(bool)OnInteract?.Invoke(keyid))
        {
            return;
        }
        doorAnimator.Play(DOOR);
    }
}

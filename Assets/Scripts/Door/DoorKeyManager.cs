using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class DoorKeyManager : MonoBehaviour
{
    private List<Keys> doorKeyIds = new List<Keys>();

    private void OnEnable()
    {
        Keys.OnInteract += Keys_OnInteract;
        Door.OnInteract += Door_OnInteract;
    }

    private bool Door_OnInteract(int doorKeyId)
    {
        foreach (Keys key in doorKeyIds)
        {
            if (key.id == doorKeyId)
            {
                doorKeyIds.Remove(key);
                return true;
            }
        }
        return false;
    }

    private void Keys_OnInteract(Keys obj)
    {
        doorKeyIds.Add(obj);
    }

    private void OnDisable()
    {
        Keys.OnInteract -= Keys_OnInteract;
        Door.OnInteract -= Door_OnInteract;
    }
}

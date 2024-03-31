using cowsins;
using System;

public class Keys : Interactable
{
    public static event Action<Keys> OnInteract;

    public int id;

    public override void Interact()
    {
        OnInteract?.Invoke(this);
        gameObject.SetActive(false);  
    }
}

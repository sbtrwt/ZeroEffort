using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedIn : MonoBehaviour
{
    [SerializeField] private string linkedInIdURL;

    public void OnClickLinkedIn()
    {
        Debug.Log("Working");
        Application.OpenURL(linkedInIdURL); 
    }
}

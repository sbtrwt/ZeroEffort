using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonService : MonoBehaviour
{
    public static GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

  
}

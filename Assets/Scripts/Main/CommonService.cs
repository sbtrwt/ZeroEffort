using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonService : MonoBehaviour
{
    public static CommonService Instance { get; private set; }
    public GameObject Player;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else { DontDestroyOnLoad(gameObject); }
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

  
}

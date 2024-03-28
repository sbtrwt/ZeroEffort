using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [SerializeField]private NavMeshAgent navmeshAgent;
    private Transform target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navmeshAgent.SetDestination(target.position);
    }
    private void Update()
    {
       
    }

    public void SetTarget(Vector3 target)
    {
        navmeshAgent.SetDestination(target);
    }
}

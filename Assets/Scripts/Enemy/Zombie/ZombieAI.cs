using FPSShooter.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace FPSShooter.Enemy
{
    public class ZombieAI : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navmeshAgent;
        [SerializeField] private Animator animator;
        private bool isChasing = false;
        private Transform target;
        private void Start()
        {
            target = CommonService.Player.transform;
            navmeshAgent.SetDestination(target.position);
        }
        private void Update()
        {
            if (isChasing)
                SetTarget(target.position);
        }

        public void SetTarget(Vector3 target)
        {
            navmeshAgent.SetDestination(target);
        }

        public void SetChasing(bool chasing)
        {
            isChasing = chasing;
        }

        public void UpdateChasing()
        {
            float distance = Vector2.Distance(target.position, transform.position);
            Debug.Log(distance);


            bool isNear = (distance > GlobalConstant.ZombieConst.AttackingDistance) && (distance <= GlobalConstant.ZombieConst.ChasingDistance);

            SetChasing(!isNear);
            animator.SetBool("IsChasing", !isNear);
            animator.SetBool("IsAttacking", (distance < GlobalConstant.ZombieConst.AttackingDistance));
            animator.SetBool("IsIdle", (distance > GlobalConstant.ZombieConst.ChasingDistance));
        }
        public void UpdateIdle()
        {
            float distance = Vector2.Distance(target.position, transform.position);
            Debug.Log(distance);
            bool isNear = (distance > GlobalConstant.ZombieConst.AttackingDistance) && (distance <= GlobalConstant.ZombieConst.ChasingDistance);

            SetChasing(!isNear);
            animator.SetBool("IsChasing", !isNear);
            animator.SetBool("IsAttacking", (distance < GlobalConstant.ZombieConst.AttackingDistance));

        }
    }

}
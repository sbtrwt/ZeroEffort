using cowsins;
using FPSShooter.StateMachine;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.AI;

namespace FPSShooter.Enemy
{
    public class Zombie : EnemyHealth
    {
        private GenericStateMachine<Zombie> stateMachine;
        [SerializeField] private List<Collider> ragDollCollider;
        [SerializeField] private List<Rigidbody> ragDollRigidbody;
        [Space()]
        [SerializeField] private float attackRadius;
        [SerializeField] private float chasingRadius;
        [Space()]
        [SerializeField] private float damageAnimationTime;
        [SerializeField] private int playerDamageAmount;
        [SerializeField] private float speed;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float rotationSpeed;
        [Space()]
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent navmeshAgent;
        private Transform target;
        public float DamageAnimationTime { get => damageAnimationTime; }
        private void Awake()
        {
            stateMachine = new ZombieStateMachine(this);
        }
        public override void Start()
        {
            base.Start();
            EnableRagdoll(false);
            target = CommonService.Instance.Player.transform;
            stateMachine.ChangeState(States.IDLE);
            SetSpeed(speed);
        }

        public void SetSpeed(float speed)
        {
            navmeshAgent.speed = speed == 0 ? this.speed : speed;
        }

        public void SetAttackSpeed() => SetSpeed(attackSpeed);
        public override void Update()
        {
            base.Update();
            stateMachine.Update();
        }

        public override void Damage(float _damage)
        {
            base.Damage(_damage);
        }

        public override void Die()
        {
            //base.Die();
            // Custom event on damaged
            events.OnDeath.Invoke();

            // Does it display killfeed on death? 
            UIEvents.onEnemyKilled.Invoke(_name);
            //stateMachine.ChangeState(States.DIE);
            //Debug.Log("Die is calling");
        }

        public void ShowDieVisual()
        {
            EnableRagdoll(true);
        }

        public void EnableRagdoll(bool setTo)
        {
            foreach (var rag in ragDollCollider)
            {
                rag.enabled = setTo;
            }
            foreach (var rBody in ragDollRigidbody)
            {
                rBody.isKinematic = setTo;
            }
        }

        public bool IsInsideAttackRadius()
        {
            //If player is in attack radius then return true else false

            return (attackRadius >= GetDistanceFromTarget());
        }
        public bool IsInsideChaseRadius()
        {
            //If player is in attack radius then return true else false

            return (chasingRadius >= GetDistanceFromTarget());
        }
        public void PlayAnimationByState(string animationName)
        {
            animator.Play(animationName);
            Debug.Log("Play animation");
        }

        public void ChasePlayer()
        {
            SetTarget(target.position);
        }

        private void SetTarget(Vector3 target)
        {
            // navmeshAgent.SetDestination(target);
            navmeshAgent.destination = target;
            Debug.Log(target);
            Debug.Log(navmeshAgent.destination + " Destination found");
        }
        private float GetDistanceFromTarget()
        {
            float distance = Vector2.Distance(target.position, transform.position);
            return distance;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, attackRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, chasingRadius);
        }
        public void FaceTarget()
        {
            Vector3 dir = target.position - transform.position;
            dir.y = 0;//This allows the object to only rotate on its y axis
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        }
    }
}

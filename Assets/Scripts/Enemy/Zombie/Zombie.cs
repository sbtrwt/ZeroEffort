using cowsins;
using FPSShooter.Sound;
using FPSShooter.StateMachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FPSShooter.Enemy
{
    public class Zombie : EnemyHealth
    {
        private const string PLAYER = "Player";
        private GenericStateMachine<Zombie> stateMachine;

        [SerializeField] private List<Collider> ragDollCollider;
        [SerializeField] private List<Rigidbody> ragDollRigidbody;

        [Space(30)]
        [SerializeField] private float attackRadius;
        [SerializeField] private float chasingRadius;
        [SerializeField] private LayerMask hitLayer;

        [Space(30)]
        [SerializeField] private float damageAnimationTime;
        [SerializeField] private int playerDamageAmount;
        [SerializeField] private float speed;

        [Space()]
        [SerializeField] private float attackDamage;

        [Space()]
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent navmeshAgent;

        [Space()]
        [SerializeField] private SoundSO soundSO;


        private Transform target;

        public SoundSO GetSoundSO() => soundSO;

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
            navmeshAgent.speed = speed;
        }

        public void SetAttackSpeed() => SetSpeed(0);

        public void SetSpeedZero()
        {
            SetSpeed(0);
        }

        public void SetRunningSpeed()
        {
            SetSpeed(speed);
        }

        public override void Update()
        {
            base.Update();
            stateMachine.Update();
        }

        public override void Damage(float _damage)
        {
            TriggerDamage();
            base.Damage(_damage);
        }

        public override void Die()
        {
            events.OnDeath.Invoke();

            UIEvents.onEnemyKilled.Invoke(_name);

            stateMachine.ChangeState(States.DIE);
        }

        private void ShowDieVisual()
        {
            EnableRagdoll(true);
            enabled = false;
        }

        public void EnableRagdoll(bool setTo)
        {
            foreach (var rag in ragDollCollider)
            {
                rag.enabled = setTo;
            }

            foreach (var rBody in ragDollRigidbody)
            {
                rBody.isKinematic = !setTo;
            }
        }

        public void TriggerDamage()
        {
            const string DAMAGE = "Damage";
            animator.SetTrigger(DAMAGE);
            SoundManager.Instance.PlaySound(soundSO.GetZombieHitSound(), 0, 0, false, 0, .7f);
            stateMachine.ChangeState(States.DAMAGE);
        }

        public void ChasePlayer()
        {
            SetTarget(target.position);
        }

        private void SetTarget(Vector3 target)
        {
            navmeshAgent.destination = target;
        }

        private float GetDistanceFromTarget()
        {
            float distance = Vector3.Distance(transform.position, target.position);
            return distance;
        }

        private void SetAnimatorStop()
        {
            animator.enabled = false;
        }

        public void OnDie()
        {
            SetAnimatorStop();
            ShowDieVisual();
            navmeshAgent.enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = false;
            enabled = false;
        }


        public bool CheckIsPlayerInChaseRadius()
        {
            float targetDist = GetDistanceFromTarget();
            bool isInChasingRadius = targetDist < chasingRadius && targetDist > attackRadius;
            if (isInChasingRadius && FireRay())
            {
                SetSetIsAttack(false);
                stateMachine.ChangeState(States.CHASING);
                return true;
            }
            return false;
        }

        public bool CheckIsPlayerInAttackRaidus()
        {
            float targetDist = GetDistanceFromTarget();
            if (targetDist < attackRadius)
            {
                SetSetIsAttack(true);
                stateMachine.ChangeState(States.ATTACKING);
                return true;
            }
            return false;
        }

        public bool CheckIsPlayerOutOfAttackRadius()
        {
            float targetDist = GetDistanceFromTarget();
            if (targetDist > attackRadius)
            {
                SetSetIsAttack(false);
                stateMachine.ChangeState(States.CHASING);
                return true;
            }
            return false;
        }

        private void SetSetIsAttack(bool isAttack)
        {
            const string IS_ATTACK = "IsAttack";
            animator.SetBool(IS_ATTACK, isAttack);
        }

        public void PlayChasing()
        {
            float fadeTime = .2f;
            const string CHASING = "Chasing";
            animator.CrossFade(CHASING, fadeTime);
        }

        public bool IsAttacking()
        {
            const string IS_ATTACK = "IsAttack";
            return animator.GetBool(IS_ATTACK);
        }

        public void AttackPlayerTarget()
        {
            target.GetComponent<IDamageable>().Damage(attackDamage);
            CamShake.instance.ShootShake(.25f);
            SoundManager.Instance.PlaySound(soundSO.GetPlayerDamageClip(), 0, 0, false, 0);
            SoundManager.Instance.PlaySound(soundSO.GetRandomoZombieAttackSound(), 0, 0, false, 0);
        }

        private bool FireRay()
        {
            Vector3 direction = (target.position - transform.position).normalized;

            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, Mathf.Infinity, hitLayer))
            {

                if (hit.collider.CompareTag(PLAYER))
                {
                    return true;
                }
            }
            return false;
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, attackRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, chasingRadius);
        }

        public virtual void PlayFootStep()
        {
            SoundManager.Instance.PlaySound(soundSO.GetZombieFootStepSound(), 0, 0, false, 0, .7f);
        }
    }
}

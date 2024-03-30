using cowsins;
using FPSShooter.StateMachine;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSShooter.Enemy
{
    public class Zombie : EnemyHealth
    {
        private GenericStateMachine<Zombie> stateMachine;
        [SerializeField] private List<Collider> ragDollCollider;
        [SerializeField] private List<Rigidbody> ragDollRigidbody;
        private void Awake()
        {
            stateMachine = new ZombieStateMachine(this);
        }
        public override void Start()
        {
            base.Start();
            EnableRagdoll(false);
        }

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
            stateMachine.ChangeState(States.DIE);
        }

        public void ShowDieVisual()
        {
            EnableRagdoll(true);
        }

        public void EnableRagdoll(bool setTo)
        {
            foreach(var rag in ragDollCollider)
            {
                rag.enabled = setTo;
            }
            foreach (var rBody in ragDollRigidbody)
            {
                rBody.isKinematic = setTo;
            }
        }
    }
}

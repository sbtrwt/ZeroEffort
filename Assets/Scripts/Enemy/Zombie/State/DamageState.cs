﻿using FPSShooter.StateMachine;
using UnityEngine;

namespace FPSShooter.Enemy
{
    public class DamageState<T> : IState where T : Zombie
    {
        public Zombie Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        private float currentDamageAnimationTime;
        private const string ANIM_NAME = "Damage";
        public DamageState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            currentDamageAnimationTime = Owner.DamageAnimationTime;
            Owner.PlayAnimationByState(ANIM_NAME);
        }
        public void Update()
        {
            currentDamageAnimationTime -= Time.deltaTime;
            if(currentDamageAnimationTime <= 0)
            {
                if (Owner.IsInsideAttackRadius())
                {
                    stateMachine.ChangeState(States.ATTACKING);
                }
                else
                {
                    stateMachine.ChangeState(States.CHASING);
                }
            }
        }

        public void OnStateExit()
        {
        }


    }
}

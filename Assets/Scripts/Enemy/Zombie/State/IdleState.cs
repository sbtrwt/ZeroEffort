using cowsins;
using FPSShooter.Sound;
using FPSShooter.StateMachine;
using UnityEngine;

namespace FPSShooter.Enemy
{
    public class IdleState<T> : IState where T : Zombie
    {
        public Zombie Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public IdleState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            Owner.SetSpeedZero();
        }

        public void Update()
        {
            Owner.CheckIsPlayerInChaseRadius();
        }

        public void OnStateExit()
        {
            Owner.PlayChasing();
            SoundManager.Instance.PlaySound(Owner.GetSoundSO().GetRandomoZombieAttackSound(), 0, .2f, false, 0);    
        }
    }
}

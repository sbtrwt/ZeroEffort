using FPSShooter.StateMachine;
using UnityEngine;

namespace FPSShooter.Enemy
{
    public class AttakingState<T> : IState where T : Zombie
    {
        public Zombie Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public AttakingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            Owner.SetSpeed(0);
        }

        public void Update()
        {
            Owner.CheckIsPlayerOutOfAttackRadius();
        }

        public void OnStateExit()
        {

        }
    }
}

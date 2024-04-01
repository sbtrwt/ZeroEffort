using FPSShooter.StateMachine;
using UnityEngine;

namespace FPSShooter.Enemy
{
    public class ChasingState<T> : IState where T : Zombie
    {
        public Zombie Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public ChasingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            Owner.SetRunningSpeed();
        }

        public void Update()
        {
            Owner.ChasePlayer();
            Owner.CheckIsPlayerInAttackRaidus();
        }

        public void OnStateExit()
        {

        }


    }
}

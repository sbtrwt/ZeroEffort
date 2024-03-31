using FPSShooter.StateMachine;
using UnityEngine;

namespace FPSShooter.Enemy
{
    public class ChasingState<T> : IState where T : Zombie
    {
        public Zombie Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        private const string ANIM_NAME = "Chasing";

        public ChasingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            Owner.PlayAnimationByState(ANIM_NAME);
            Debug.Log("State " + ANIM_NAME);
        }
        public void Update()
        {
           Owner.ChasePlayer();
            if (Owner.IsInsideAttackRadius())
            {
                stateMachine.ChangeState(States.ATTACKING);
            }
        }

        public void OnStateExit()
        {
        }


    }
}

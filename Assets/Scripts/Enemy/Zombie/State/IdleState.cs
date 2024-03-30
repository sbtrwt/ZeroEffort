using FPSShooter.StateMachine;
using UnityEngine;

namespace FPSShooter.Enemy
{
    public class IdleState<T> : IState where T : Zombie
    {
        public Zombie Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        private const string ANIM_NAME = "Idle";

        public IdleState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            Owner.PlayAnimationByState(ANIM_NAME);
            Debug.Log("State "+ ANIM_NAME);
        }
        public void Update()
        {
            if (Owner.IsInsideChaseRadius())
            {
                stateMachine.ChangeState(States.CHASING);
            }
        }

        public void OnStateExit()
        {
        }


    }
}

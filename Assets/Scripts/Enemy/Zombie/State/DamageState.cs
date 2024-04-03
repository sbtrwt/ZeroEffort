using FPSShooter.StateMachine;
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
            Debug.Log("Enter Damage");
            Owner.SetSpeedZero();
        }

        public void Update()
        {
            if (Owner.IsAttacking())
            {
                Debug.Log("Working");
                stateMachine.ChangeState(States.ATTACKING);
            }
            else
            {
                Debug.Log("Working2");
                stateMachine.ChangeState(States.CHASING);
            }
        }

        public void OnStateExit()
        {
            
        }

    }
}

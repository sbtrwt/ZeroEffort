using cowsins;
using FPSShooter.StateMachine;
using UnityEngine;


namespace FPSShooter.Enemy
{
    public class DieState<T> : IState where T : Zombie
    {
        public Zombie Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        private const string ANIM_NAME = "_";

        public DieState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            Owner.SetSpeedZero();
            Owner.OnDie();
            SoundManager.Instance.PlaySound(Owner.GetSoundSO().GetRandomDieSound(), 0, 0, false, 0);
        }

        public void Update()
        {

        }

        public void OnStateExit()
        {

        }
    }
}

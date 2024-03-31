using FPSShooter.StateMachine;


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
            Owner.ShowDieVisual();
            Owner.PlayAnimationByState(ANIM_NAME);
        }
        public void Update()
        {

        }

        public void OnStateExit()
        {
        }


    }
}

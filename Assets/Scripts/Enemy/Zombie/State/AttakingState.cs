using FPSShooter.StateMachine;


namespace FPSShooter.Enemy
{
    public class AttakingState<T> : IState where T : Zombie
    {
        public Zombie Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        private const string ANIM_NAME = "Attack";

        public AttakingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            Owner.PlayAnimationByState(ANIM_NAME);
            Owner.SetAttackSpeed();
        }
        public void Update()
        {
            //Owner.ChasePlayer();
            if (!Owner.IsInsideAttackRadius())
            {
                stateMachine.ChangeState(States.CHASING);
            }
        }

        public void OnStateExit()
        {
            Owner.SetSpeed(0);
        }


    }
}

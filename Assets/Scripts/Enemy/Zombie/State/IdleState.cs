using FPSShooter.StateMachine;


namespace FPSShooter.Enemy
{
    public class IdleState<T> : IState where T : Zombie
    {
        public Zombie Owner { get; set; }
        private GenericStateMachine<T> stateMachine;


        public IdleState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            throw new System.NotImplementedException();
        }
        public void Update()
        {

        }

        public void OnStateExit()
        {
        }


    }
}

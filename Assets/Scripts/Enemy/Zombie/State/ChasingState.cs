using FPSShooter.StateMachine;


namespace FPSShooter.Enemy
{
    public class ChasingState<T> : IState where T : Zombie
    {
        public Zombie Owner { get; set; }
        private GenericStateMachine<T> stateMachine;


        public ChasingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

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

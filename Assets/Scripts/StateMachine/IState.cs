using FPSShooter.Enemy;


namespace FPSShooter.StateMachine
{
    public interface IState
    {
        public Zombie Owner { get; set; }
        public void OnStateEnter();
        public void Update();
        public void OnStateExit();
    }
}

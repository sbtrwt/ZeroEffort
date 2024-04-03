using FPSShooter.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSShooter.Enemy
{
    public class ZombieStateMachine : GenericStateMachine<Zombie>
    {
        public ZombieStateMachine(Zombie Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.States.IDLE, new IdleState<Zombie>(this));
            States.Add(StateMachine.States.CHASING, new ChasingState<Zombie>(this));
            States.Add(StateMachine.States.ATTACKING, new AttakingState<Zombie>(this));
            States.Add(StateMachine.States.DIE, new DieState<Zombie>(this));
            States.Add(StateMachine.States.DAMAGE, new DamageState<Zombie>(this));
        }
    }
}

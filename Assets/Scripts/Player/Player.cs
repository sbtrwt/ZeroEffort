using FPSShooter.Interfaces;
using UnityEngine;

namespace FPSShooter.Player
{
    public abstract class Player : IMovable
    {
        protected Vector3 position;
        protected float speed = 5f;
        public Vector3 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public virtual void OnMove(Vector2 target)
        {
            position += new Vector3(target.x,target.y) * Time.deltaTime * speed;
        }


    }
}

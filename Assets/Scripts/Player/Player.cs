using FPSShooter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FPSShooter.Player
{
    public abstract class Player : IMovable
    {
        private Vector3 position;
        public virtual void OnMove()
        {

        }
       
    }
}

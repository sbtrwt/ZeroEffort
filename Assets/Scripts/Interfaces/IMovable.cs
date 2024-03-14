using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FPSShooter.Interfaces
{
    public interface IMovable
    {
        void OnMove(Vector2 target);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FPSShooter.Player
{

    [CreateAssetMenu(fileName = "New Player", menuName = "Player")]
    public class PlayerSO: ScriptableObject
    {
        public int ID;
        public PlayerView PlayerView;
        public float walkSpeed;
        public float runSpeed;
        public float jumpForce;
    }
}

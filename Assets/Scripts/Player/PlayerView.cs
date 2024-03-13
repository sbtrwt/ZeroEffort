using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FPSShooter.Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;
        public void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}

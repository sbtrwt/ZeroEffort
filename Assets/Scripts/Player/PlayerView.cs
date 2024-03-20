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
        [SerializeField] protected Rigidbody playerRb;

        private PlayerController playerController;

        public void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void Jump(Vector3 jumpDir)
        {
            playerRb.AddForce(jumpDir, ForceMode.Impulse);
        }

        public void Move(Vector3 target, float speed)
        {
            Vector3 moveDir = new Vector3(target.x, 0, target.y);

            transform.position += speed * Time.deltaTime * moveDir;
        }
    }
}

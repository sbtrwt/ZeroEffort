using System.Collections.Generic;
using UnityEngine;
namespace FPSShooter.Sound
{
    public class JumpScareSound : MonoBehaviour
    {
        [SerializeField] private SoundSO soundSO;
        [SerializeField] private AudioSource audioSource;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                List<AudioClip> jumpScareSoundEffects = soundSO.jumpScareSoundEffects;
                AudioClip clip = jumpScareSoundEffects[Random.Range(0, jumpScareSoundEffects.Count)];
                audioSource.PlayOneShot(clip);

                GetComponent<Collider>().enabled = false;
            }
        }
    }
}



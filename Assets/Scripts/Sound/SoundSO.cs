using System.Collections.Generic;
using UnityEngine;
namespace FPSShooter.Sound
{
    [CreateAssetMenu()]
    public class SoundSO : ScriptableObject
    {
        [SerializeField] private List<AudioClip> jumpScareSoundEffects;

        [SerializeField] private List<AudioClip> zombieDie;

        [SerializeField] private List<AudioClip> zombieAttack;

        [SerializeField] private List<AudioClip> zombieWalk;

        public AudioClip GetRandomJumpScareSound()
        {
            return jumpScareSoundEffects[Random.Range(0, jumpScareSoundEffects.Count)];
        }

        public AudioClip GetRandomAttackSound()
        {
            return zombieAttack[Random.Range(0, zombieAttack.Count)];
        }

        public AudioClip GetRandomDieSound()
        {
            return zombieDie[Random.Range(0, zombieDie.Count)];
        }
    }
}



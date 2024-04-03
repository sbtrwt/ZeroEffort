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

        [SerializeField] private List<AudioClip> zombieHit;

        [SerializeField] private List<AudioClip> playerDamage;

        public AudioClip doorSound;
        public AudioClip interactionSound;

        public AudioClip GetRandomJumpScareSound()
        {
            return jumpScareSoundEffects[Random.Range(0, jumpScareSoundEffects.Count)];
        }

        public AudioClip GetRandomoZombieAttackSound()
        {
            return zombieAttack[Random.Range(0, zombieAttack.Count)];
        }

        public AudioClip GetRandomDieSound()
        {
            return zombieDie[Random.Range(0, zombieDie.Count)];
        }

        public AudioClip GetZombieHitSound()
        {
            return zombieHit[Random.Range(0, zombieHit.Count)];
        }

        public AudioClip GetZombieFootStepSound()
        {
            return zombieWalk[Random.Range(0, zombieWalk.Count)];

        }

        public AudioClip GetPlayerDamageClip()
        {
            return playerDamage[Random.Range(0, playerDamage.Count)];
        }
    }
}





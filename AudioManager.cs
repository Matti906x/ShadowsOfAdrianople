using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusicSource;
    [SerializeField] AudioSource zombieApproachSource;
    [SerializeField] AudioSource zombieAttackSource;
    [SerializeField] AudioSource arrowImpactSource;

    EnemyHealth health;

    void Start()
    {
        backgroundMusicSource.Play();
        health = GetComponent<EnemyHealth>();
    }

    public void PlayZombieApproach(AudioClip clip)
    {
        if (!zombieApproachSource.isPlaying)
        {
            zombieApproachSource.clip = clip;
            zombieApproachSource.Play();
        }
    }

    public void StopZombieApproach(AudioClip clip)
    {
        zombieApproachSource.clip = clip;
        zombieApproachSource.Stop();
    }

    public void PlayZombieAttack(AudioClip clip)
    {
        if (!zombieAttackSource.isPlaying)
        {
            zombieAttackSource.clip = clip;
            zombieAttackSource.Play();
        }
    }

    public void ArrowImpact(AudioClip clip)
    {
        arrowImpactSource.clip = clip;
        arrowImpactSource.Play();
    }
}

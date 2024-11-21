using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;

    AudioManager audioManager;
    [SerializeField] AudioClip zombieAttack;
    
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    public void AttackHitEvent()
    {
        if (target == null) return;
        audioManager.PlayZombieAttack(zombieAttack);
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}

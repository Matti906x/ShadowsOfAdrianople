using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    private Vector3 direction;
    private float damage;

    [SerializeField] GameObject hitEffect;

    AudioManager audioManager;
    [SerializeField] AudioClip arrowImpact;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        // Move the arrow forward in the set direction
        transform.position += direction * speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    public void SetDamage(float damageAmount)
    {
        damage = damageAmount;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Instantiate the hit effect at the collision point
        if (hitEffect != null)
        {
            GameObject impact = Instantiate(hitEffect, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal));
            Debug.Log("Hit effect instantiated at: " + collision.contacts[0].point);
            audioManager.ArrowImpact(arrowImpact);
            Destroy(impact, 0.5f);
        }
        
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth target = collision.gameObject.GetComponent<EnemyHealth>();
            audioManager.ArrowImpact(arrowImpact);
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

        // Destroy the arrow after it hits something
        Destroy(gameObject);
    }

}
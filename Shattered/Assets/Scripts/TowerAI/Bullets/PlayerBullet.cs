using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour, ICanDamage
{
    private float lifeTime = 5f; // Time in seconds before the projectile is destroyed if it doesn't hit anything

    private float speed = 10f;

    [SerializeField] private float bulletDamage = 1;

    public float Damage => bulletDamage;

    void Start()
    {
        // Destroy the projectile after 'lifeTime' seconds to prevent memory leaks
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move the projectile in the set direction
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
        {
            return;
        }

        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}

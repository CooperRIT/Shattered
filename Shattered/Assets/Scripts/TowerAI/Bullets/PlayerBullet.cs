using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float lifeTime = 5f; // Time in seconds before the projectile is destroyed if it doesn't hit anything

    private float speed = 10f;

    private Vector3 moveDirection;

    void Start()
    {
        // Set the direction of the projectile (firePoint's right direction)
        moveDirection = transform.right;

        // Destroy the projectile after 'lifeTime' seconds to prevent memory leaks
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move the projectile in the set direction
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the projectile collided with an object tagged as "Enemy" 
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

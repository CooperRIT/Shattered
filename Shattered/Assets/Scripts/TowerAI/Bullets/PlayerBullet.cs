using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float lifeTime = 5f; // Time in seconds before the projectile is destroyed if it doesn't hit anything

    private float speed = 10f;

    private Vector3 moveDirection;


    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    void Start()
    {
        // Destroy the projectile after 'lifeTime' seconds to prevent memory leaks
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move the projectile in the set direction
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    //Cooper- This is a fine approach, but you will need to use the interface implimentation that enemies have in order to properly dispose of them
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

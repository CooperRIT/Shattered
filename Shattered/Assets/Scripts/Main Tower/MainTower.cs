using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainTower : MonoBehaviour, IDamageable
{
    NavMeshAgent agent;

    float health = 10;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDeath();
            return;
        }
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}

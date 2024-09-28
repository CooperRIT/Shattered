using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, IDamageable
{
    NavMeshAgent agent;
    [SerializeField] Transform destination;

    [SerializeField] FloatEventChannel onEnemyDeath_FloatEventChannel;

    [SerializeField] float health = 100;
    [SerializeField] float speed = 3;
    [SerializeField] float currencyValue = 1;
    FloatEvent currencyValue_FloatEvent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        currencyValue_FloatEvent.FloatValue = currencyValue;
        OnSpawn();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            OnDeath();
            return;
        }
        //UI Logic here

    }

    public void OnSpawn()
    {
        agent.SetDestination(destination.position);
    }

    public void OnDeath()
    {
        onEnemyDeath_FloatEventChannel.CallEvent(currencyValue_FloatEvent);
    }
}

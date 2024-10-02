using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, IDamageable, ICanDamage
{
    NavMeshAgent agent;
    [SerializeField] Transform destination;

    [SerializeField] FloatEventChannel onEnemyDeath_FloatEventChannel;

    [SerializeField] float health = 1;
    [SerializeField] float speed = 3;
    [SerializeField] float currencyValue = 1;
    FloatEvent currencyValue_FloatEvent;

    public float Damage => health;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        currencyValue_FloatEvent.FloatValue = currencyValue;
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

    public void OnSpawn(Transform _destination)
    {
        destination = _destination;
        agent.SetDestination(destination.position);
    }

    public void OnDeath()
    {
        currencyValue_FloatEvent.FloatValue = currencyValue;
        onEnemyDeath_FloatEventChannel.CallEvent(currencyValue_FloatEvent);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Enemy Base Class Responsible For Behavior Every Enemy Has
/// </summary>
public abstract class BaseEnemyAI : MonoBehaviour, IDamageable, ICanDamage
{
    NavMeshAgent agent;
    [SerializeField] Transform destination;

    [SerializeField] FloatEventChannel onEnemyDeath_FloatEventChannel;

    [SerializeField] protected float health = 1;
    [SerializeField] protected float speed = 3;
    [SerializeField] protected float currencyValue = 1;
    FloatEvent currencyValue_FloatEvent;

    public float Damage => health;

    bool isDead;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        currencyValue_FloatEvent.FloatValue = currencyValue;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDeath();
            return;
        }
        //UI Logic here

    }

    public virtual void OnSpawn(Transform _destination)
    {
        destination = _destination;
        agent.SetDestination(destination.position);
    }

    public virtual void OnDeath()
    {
        if(isDead)
        {
            return;
        }
        isDead = true;

        currencyValue_FloatEvent.FloatValue = currencyValue;
        onEnemyDeath_FloatEventChannel.CallEvent(currencyValue_FloatEvent);
        Destroy(gameObject);
    }
}

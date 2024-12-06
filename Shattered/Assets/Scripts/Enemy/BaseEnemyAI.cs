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
    [SerializeField] List<Transform> destinations = new List<Transform>();

    [SerializeField] FloatEventChannel onEnemyDeath_FloatEventChannel;

    [SerializeField] protected float health = 1;
    [SerializeField] protected float speed = 3;
    [SerializeField] protected float currencyValue = 2;
    FloatEvent currencyValue_FloatEvent;

    public float Damage => health;

    bool isDead;

    public delegate void PursueDestination();
    public PursueDestination pursueDestination;

    public float Health
    {
        get { return health; }
        set {
            currencyValue = health * 2;
            currencyValue_FloatEvent.FloatValue = currencyValue;
            health = value;
            }
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        pursueDestination += () => { };
    }
    private void Start()
    {
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
        destinations.Add(_destination);
        agent.SetDestination(destinations[0].position);
    }

    public virtual void OnSpawn(List<Transform> _destinations)
    {
        destinations = _destinations;
        agent.SetDestination(destinations[0].position);
        pursueDestination += GoTowardDestination;
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

    private void GoTowardDestination()
    {
        if (Vector3.Distance(destinations[0].position, transform.position) > 1f)
        {
            return;
        }

        destinations.RemoveAt(0);
        agent.SetDestination(destinations[0].position);

        if(destinations.Count <= 1)
        {
            pursueDestination -= GoTowardDestination;
            return;
        }
    }

    public virtual void Update()
    {
        pursueDestination();
    }
}

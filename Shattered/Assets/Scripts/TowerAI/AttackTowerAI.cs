using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class that holds values that support towers can buff
[System.Serializable]
public class BuffableStats
{
    public float towerDamage;
    public float attackTime;

    public float AttackTime
    {
        get { return attackTime; }
        set { attackTime = value; }
    }
    public float TowerDamage
    {
        get { return towerDamage; }
        set { towerDamage = value; }
    }
}

public class AttackTowerAI : BaseTowerAI, ICanDamage
{
    //Serialize Version of the class that holds these values
    [SerializeField] BuffableStats buffableStats = new BuffableStats();

    float timerAmount => buffableStats.AttackTime;

    public float Damage => buffableStats.TowerDamage;

    [SerializeField] List<EnemyAI> enemies = new List<EnemyAI>();

    [SerializeField] GameObject bullet_Prefab;

    protected Transform target;

    [SerializeField] Transform shootPoint;

    float timer;
    

    [SerializeField] float randomOffset;

    //IAttackBehavior attackBehavior;

    private void Awake()
    {
        randomOffset = Random.Range(0.0f, .3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count == 0)
        {
            timer = timer < Time.time ? randomOffset + Time.time : timer;
            return;
        }

        if(timer < Time.time)
        {
            FireProjectile();
            timer = Time.time + timerAmount;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
        {
            return;
        }

        if (other.gameObject.TryGetComponent(out EnemyAI enemy))
        {
            enemies.Add(enemy);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enemy"))
        {
            return;
        }

        if (other.gameObject.TryGetComponent(out EnemyAI enemy))
        {
            enemies.Remove(enemy);
        }
    }

    public void FireProjectile()
    {
        //Make sure to have enemies destroy themselves in late update to avoid double destroy
        while (enemies[0] == null)
        {
            enemies.RemoveAt(0);
            if (enemies.Count == 0)
            {
                return;
            }
        }

        //Future implimentation
        //attackBehavior.AttackBehavior();

        target = enemies[0].transform;

        //Temp Cast
        IDamageable damagable = enemies[0];
        damagable.TakeDamage(Damage);

        //Shoot Bullet For Visual Sake
        Transform projectile = Instantiate(bullet_Prefab, shootPoint.position, Quaternion.identity).transform;

        projectile.LookAt(target.transform.position);
    }

    public override void SpecialBehavior()
    {
        //TowerCodeHere
    }
    
    public BuffableStats BuffableStats
    {
        get { return buffableStats; }
    }
}

public interface IDamageable
{
    public void TakeDamage(float damage);
}
public interface ICanDamage
{
    public float Damage { get; }
}

public interface IAttackBehavior
{
    public void AttackBehavior();
}

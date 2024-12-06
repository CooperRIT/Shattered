using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Tooltip("BuffOne = Attack Damage, BuffTwo = AttackSpeed")]
public class AttackTowerAI : BaseTowerAI, ICanDamage, CanBeBuffed
{
    public float Damage => upgrades.UpgradableStats.UpgradableStatOne;

    float timerAmount => upgrades.UpgradableStats.UpgradableStatTwo;

    [SerializeField] List<EnemyAI> enemies = new List<EnemyAI>();

    [SerializeField] GameObject bullet_Prefab;

    protected Transform target;

    [SerializeField] Transform shootPoint;

    float timer;

    [SerializeField] float randomOffset;


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

    public override void UpgradeLogicOne(int statIncrease)
    {
        upgrades.UpgradePriceOne *= 2;

        ModifyStats(statIncrease, 0);
    }

    public override void UpgradeLogicTwo(int statIncrease)
    {
        upgrades.UpgradePriceTwo += 10;

        ModifyStats(0, statIncrease);
    }

    public void ModifyStats(float statModifyOne, float statModifyTwo)
    {
        //In order to nullify further buffs
        if (BuffableStatOne + statModifyOne > upgrades.UpgradableStats.MaxUpgradeStatOne)
        {
            statModifyOne = 0;
        }

        if (BuffableStatTwo - statModifyTwo < upgrades.UpgradableStats.MaxUpgradeStatTwo)
        {
            statModifyTwo = 0;
        }


        BuffableStatOne += statModifyOne;
        BuffableStatTwo -= statModifyTwo;
    }

    public override bool CanUpgrade(int statToIncrease)
    {
        if(statToIncrease == 1)
        {
            return BuffableStatOne < upgrades.UpgradableStats.MaxUpgradeStatOne;
        }
        else
        {
            return BuffableStatTwo > upgrades.UpgradableStats.MaxUpgradeStatTwo;
        }
    }

    public float BuffableStatOne 
    {
        get { return upgrades.UpgradableStats.UpgradableStatOne; }
        set { upgrades.UpgradableStats.UpgradableStatOne = value; }
    }

    public float BuffableStatTwo
    {
        get { return upgrades.UpgradableStats.UpgradableStatTwo; }
        set { upgrades.UpgradableStats.UpgradableStatTwo = value; }
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

public interface CanBeBuffed
{
    public float BuffableStatOne { get; set; }
    public float BuffableStatTwo { get; set; }

    public void ModifyStats(float statModifyOne, float statModifyTwo);
}

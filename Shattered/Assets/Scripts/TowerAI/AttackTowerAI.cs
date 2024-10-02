using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTowerAI : MonoBehaviour, ICanDamage
{
    /*
     * Script implimentation is temporary, but serves it purpose for now
     * The duplication of code is not to my liking, but is a nesissary evil for now
     */

    [SerializeField] List<EnemyAI> enemies = new List<EnemyAI>();

    [SerializeField] GameObject bullet_Prefab;

    Transform target;

    float timer;
    [SerializeField] float timerAmount = 5;

    [SerializeField] Transform shootPoint;

    float towerDamage = 4;

    public float Damage => towerDamage;

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

    void FireProjectile()
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

        target = enemies[0].transform;

        //Temp Cast
        IDamageable damagable = enemies[0];
        damagable.TakeDamage(towerDamage);

        //Shoot Bullet For Visual Sake
        Transform projectile = Instantiate(bullet_Prefab, shootPoint.position, Quaternion.identity).transform;

        projectile.LookAt(target.transform.position);
    }
}

public interface IDamageable
{
    void TakeDamage(float damage);
}
public interface ICanDamage
{
    public float Damage { get; }
}

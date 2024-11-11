using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class MainTower : MonoBehaviour, IDamageable
{
    [SerializeField] VoidEventChannel onMainTowerDeath;
    [SerializeField] TextMeshPro healthText;
    float health = 10;

    private void Awake()
    {
        UpdateHealthText();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        UpdateHealthText();


        if (health <= 0)
        {
            OnDeath();
            return;
        }
    }

    public void OnDeath()
    {
        onMainTowerDeath.CallEvent(new());
        //Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
        {
            return;
        }

        if (other.gameObject.TryGetComponent(out EnemyAI enemy))
        {
            TakeDamage(enemy.Damage);
            enemy.TakeDamage(1000);
        }
    }

    public void UpdateHealthText()
    {
       // healthText.text = $"<b>Tower Health Remaining:</b> {health}";
    }
}

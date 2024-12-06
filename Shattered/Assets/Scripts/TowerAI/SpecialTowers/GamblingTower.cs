using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OutComes
{
    DestroyAllEnemies,
    DestroyAllTowers
}

public class GamblingTower : BaseTowerAI
{
    int costToRoll;
    bool canRoll = true;

    [SerializeField] List<GameObject> towers = new List<GameObject>();
    [SerializeField] List<IDamageable> enemies = new List<IDamageable>();

    [SerializeField] GameObject displayText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            towers.Add(other.gameObject);
        }

        else if (other.gameObject.layer == 7)
        {
            if(other.gameObject.TryGetComponent(out IDamageable enemy))
            {
                enemies.Add(enemy);
            }
        }
    }

    void LetsGoGambling()
    {
        if (!canRoll)
        {
            return;
        }

        canRoll = false;

        displayText.SetActive(false);

        int randomRoll = Random.Range(0, 2);

        switch ((OutComes)randomRoll)
        {
            case OutComes.DestroyAllEnemies:
                DestoryAllEnemies();
                break;

            case OutComes.DestroyAllTowers:
                DestroyAllTowers();
                break;
        }
    }

    public void OnRoundEnd(VoidEvent ctx)
    {
        enemies.Clear();
        canRoll = true;
        displayText.SetActive(true);
    }

    void DestroyAllTowers()
    {
        for(int i = 0; i < towers.Count; i++)
        {
            if (towers[i] != null)
            {
                Destroy(towers[i]);
            }
        }
        towers.Clear();
        Destroy(transform.parent.gameObject);
    }

    void DestoryAllEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].TakeDamage(1000);
            }
        }
        enemies.Clear();
    }

    void IncreaseTowerHealth()
    {

    }

    void GoBroke()
    {
        GameManager.instance.Currency = 0;
    }

    public override void UpgradeLogicOne(int statIncrease)
    {
        LetsGoGambling();
        upgrades.UpgradePriceOne *= 4;
    }

    public override void UpgradeLogicTwo(int statIncrease)
    {

    }

    public override bool CanUpgrade(int statToIncrease)
    {
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupportTowerAI : BaseTowerAI, ICanBuff
{
    [SerializeField] SphereCollider sphereCollider;

    float radius => upgrades.UpgradableStats.UpgradableStatOne;

    [SerializeField] List<CanBeBuffed> buffedTowers = new List<CanBeBuffed>();

    [SerializeField] LayerMask buffableLayers;
    private void OnTriggerEnter(Collider other)
    {

        if ((buffableLayers.value & (1 << other.gameObject.layer)) == 0)
        {
            return;
        }

        if (other.transform.GetChild(0).TryGetComponent(out CanBeBuffed buffed))
        {
            Debug.Log("applied buffs");
            buffed.ModifyStats(0, 1);
            buffedTowers.Add(buffed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((buffableLayers.value & (1 << other.gameObject.layer)) == 0)
        {
            return;
        }

        if (other.transform.GetChild(0).TryGetComponent(out CanBeBuffed buffed))
        {
            Debug.Log("applied buffs");
            buffed.ModifyStats(0, -1);
            buffedTowers.Remove(buffed);
        }
    }

    public override void UpgradeLogicOne(int statIncrease)
    {
        if (radius + statIncrease > upgrades.UpgradableStats.MaxUpgradeStatOne)
        {
            return;
        }

        upgrades.UpgradableStats.UpgradableStatOne += statIncrease;
        sphereCollider.radius = radius;
        upgrades.UpgradePriceOne += 10;
    }

    public override void UpgradeLogicTwo(int statToIncrease)
    {

    }

    private void OnDestroy()
    {
        foreach(CanBeBuffed buffed in buffedTowers)
        {
            if(buffed == null)
            {
                continue;
            }
            buffed.ModifyStats(0, -1);
        }
    }

    public override bool CanUpgrade(int statIncrease)
    {
        return radius < upgrades.UpgradableStats.MaxUpgradeStatOne;
    }
}

public interface ICanBuff
{
    //public float StatIncrease { get; set; }

}

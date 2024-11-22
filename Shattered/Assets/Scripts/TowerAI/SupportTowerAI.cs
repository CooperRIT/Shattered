using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportTowerAI : BaseTowerAI, ICanBuff
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != 6)
        {
            return;
        }

        Debug.Log("is tower");

        if (other.transform.GetChild(0).TryGetComponent(out CanBeBuffed attackTower))
        {
            Debug.Log("applied buffs");
            attackTower.ModifyStats(0, -1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 6)
        {
            return;
        }

        if (other.transform.GetChild(0).TryGetComponent(out CanBeBuffed attackTower))
        {
            attackTower.ModifyStats(0, 1);
        }
    }

    public override void UpgradeLogicOne(int statIncrease)
    {
        throw new System.NotImplementedException();
    }

    public override void UpgradeLogicTwo(int statIncrease)
    {
        throw new System.NotImplementedException();
    }
}

public interface ICanBuff
{
    //public float StatIncrease { get; set; }

}

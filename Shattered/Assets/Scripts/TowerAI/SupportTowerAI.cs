using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportTowerAI : BaseTowerAI, ICanBuff
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != 7)
        {
            return;
        }

        if(other.transform.GetChild(0).TryGetComponent(out AttackTowerAI attackTower))
        {
            Debug.Log("applied buffs");
            ApplyBuffs(attackTower.BuffableStats);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 7)
        {
            return;
        }

        if (other.transform.GetChild(0).TryGetComponent(out AttackTowerAI attackTower))
        {
            RemoveBuffs(attackTower.BuffableStats);
        }
    }

    public void ApplyBuffs(BuffableStats buffableStats)
    {
        buffableStats.AttackTime -= 1;
    }

    public void RemoveBuffs(BuffableStats buffableStats)
    {
        buffableStats.AttackTime += 1;
    }
}

public interface ICanBuff
{
    public void ApplyBuffs(BuffableStats buffableStats);
    public void RemoveBuffs(BuffableStats buffableStats);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportTowerAI : BaseTowerAI, ICanBuff
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Buffable"))
        {
            return;
        }

        if(other.transform.GetChild(0).TryGetComponent(out AttackTowerAI attackTower))
        {
            ApplyBuffs(attackTower.BuffableStats);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Buffable"))
        {
            return;
        }

        if (other.transform.GetChild(0).TryGetComponent(out AttackTowerAI attackTower))
        {
            RemoveBuffs(attackTower.BuffableStats);
        }
    }


    public override void SpecialBehavior()
    {
        
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

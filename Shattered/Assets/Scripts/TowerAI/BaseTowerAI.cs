using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Class Responsible For Behavior Every Tower Has
/// </summary>
public abstract class BaseTowerAI : MonoBehaviour, IInteractable
{
    protected bool fullyUpgraded = false;
    protected bool canInteract = true;

    [SerializeField] protected GameObjectEventChannel onTowerInteract_EventChannel;

    [SerializeField] protected Upgrades upgrades = new Upgrades();

    private void Start()
    {
        upgrades.upgradeLogicOneDel += UpgradeLogicOne;
        upgrades.upgradeLogicTwoDel += UpgradeLogicTwo;
    }


    public bool CanInteract 
    { 
        get {return canInteract;}
        set { canInteract = value; }
    }

    public virtual void OnInteract()
    {
        if(!canInteract)
        {
            return;
        }
        if(fullyUpgraded)
        {
            return;
        }

        SpecialBehavior();
    }

    public virtual void SpecialBehavior()
    {
        onTowerInteract_EventChannel.CallEvent(new(transform.parent.gameObject));
    }

    public abstract void UpgradeLogicOne(int statIncrease);

    public abstract void UpgradeLogicTwo(int statIncrease);

    private void OnDestroy()
    {
        
    }
}

//Container class that allows for upgrades to be handled
[System.Serializable]
public class Upgrades
{
    [SerializeField] Upgradable upgradableStats = new Upgradable();

    [SerializeField] string upgradeTextOne;
    [SerializeField] string upgradeTextTwo;

    [SerializeField] int upgradePriceOne;
    [SerializeField] int upgradePriceTwo;

    public delegate void UpgradeLogicOne(int statIncrease);
    public UpgradeLogicOne upgradeLogicOneDel;
    public delegate void UpgradeLogicTwo(int statIncrease);
    public UpgradeLogicTwo upgradeLogicTwoDel;

    public string UpgradeTextOne
    {
        get { return upgradeTextOne; } 
    }

    public string UpgradeTextTwo
    {
        get { return upgradeTextTwo; }
    }

    public Upgradable UpgradableStats
    {
        get { return upgradableStats; }
    }
}

//Container class that holds upgradable stats
[System.Serializable]
public class Upgradable
{
    [SerializeField] float upgradableStatOne;
    [SerializeField] float upgradableStatTwo;


    public float UpgradableStatOne
    {
        get { return upgradableStatOne; }
        set { upgradableStatOne = value; }
    }

    public float UpgradableStatTwo
    {
        get { return upgradableStatTwo; }
        set { upgradableStatTwo = value; }
    }
}

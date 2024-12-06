using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        upgrades.UpgradeLogicOneUE += UpgradeLogicOne;
        upgrades.UpgradeLogicTwoUE += UpgradeLogicTwo;
        upgrades.AbleToUpgradeLogicD += CanUpgrade;
    }


    public bool CanInteract 
    { 
        get {return canInteract;}
        set { canInteract = value; }
    }

    public Upgrades Upgrades
    {
        get {return upgrades;}
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

    public abstract bool CanUpgrade(int statToIncrease);

    private void OnDestroy()
    {
        
    }
}

//Container class that allows for upgrades to be handled
[System.Serializable]
public class Upgrades
{
    [SerializeField] string towerName;

    [SerializeField] Upgradable upgradableStats = new Upgradable();

    [SerializeField] string upgradeTextOne;
    [SerializeField] string upgradeTextTwo;

    [SerializeField] int upgradePriceOne;
    [SerializeField] int upgradePriceTwo;

    public UnityAction<int> UpgradeLogicOneUE;
    public UnityAction<int> UpgradeLogicTwoUE;

    public delegate bool CanUpgrade(int statToIncrease);
    public CanUpgrade AbleToUpgradeLogicD;

    public string UpgradeTextOne
    {
        get { return upgradeTextOne; }
    }

    public string UpgradeTextTwo
    {
        get { return upgradeTextTwo; }
    }

    public int UpgradePriceOne
    {
        get { return upgradePriceOne; }
        set { upgradePriceOne = value; }
    }

    public int UpgradePriceTwo
    {
        get { return upgradePriceTwo; }
        set { upgradePriceTwo = value; }
    }

    public Upgradable UpgradableStats
    {
        get { return upgradableStats; }
    }

    public string TowerName
    {
        get { return towerName; }
    }
}

//Container class that holds upgradable stats
[System.Serializable]
public class Upgradable
{
    [SerializeField] float upgradableStatOne;
    [SerializeField] float upgradableStatTwo;

    [SerializeField] float maxUpgradeStatOne;
    [SerializeField] float maxUpgradeStatTwo;


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

    public float MaxUpgradeStatOne
    {
        get { return maxUpgradeStatOne; }
    }

    public float MaxUpgradeStatTwo
    {
        get { return maxUpgradeStatTwo; }
    }
}

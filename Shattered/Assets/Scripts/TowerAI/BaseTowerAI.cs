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

    private void OnDestroy()
    {
        
    }
}

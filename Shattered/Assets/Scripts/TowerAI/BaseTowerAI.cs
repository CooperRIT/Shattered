using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Class Responsible For Behavior Every Tower Has
/// </summary>
public abstract class BaseTowerAI : MonoBehaviour, IInteractable
{
    protected bool canInteract;

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
        SpecialBehavior();
    }

    public abstract void SpecialBehavior();
}

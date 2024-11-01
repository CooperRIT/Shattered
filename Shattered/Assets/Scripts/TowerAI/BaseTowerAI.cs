using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Class Responsible For Behavior Every Tower Has
/// </summary>
public abstract class BaseTowerAI : MonoBehaviour, IInteractable
{
    GameObject interactionPoint;

    protected bool canInteract = true;

    public GameObject InteractionPoint
    {
        get { return interactionPoint; }
        set { interactionPoint = value; }
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
        SpecialBehavior();
    }

    public abstract void SpecialBehavior();

    private void OnDestroy()
    {
        interactionPoint.SetActive(true);
    }
}

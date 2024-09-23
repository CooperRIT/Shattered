using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public bool CanInteract { get; set; }
    public void OnInteract();
}

public class BlockInteractionBehavior : MonoBehaviour, IInteractable
{
    bool canInteract = true;

    public bool CanInteract 
    {
        get { return canInteract; }
        set { canInteract = value; }
    }

    public void OnInteract()
    {
        if(!canInteract)
        {
            return;
        }

        Debug.Log("Interacted");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

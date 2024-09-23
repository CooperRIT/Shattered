using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    bool interacted;

    private void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag("Interactable"))
        {
            return;
        }

        if(other.transform.GetChild(0).TryGetComponent(out IInteractable interactable))
        {
            if(!Interacted)
            {
                return;
            }
            interactable.OnInteract();
            interacted = false;
        }
    }

    public bool Interacted
    {
        get { return interacted; }
        set {interacted = value; }
    }
}

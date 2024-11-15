using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    bool interacted;

    [SerializeField] Transform playerCamera;

    [SerializeField] float maxDistance;

    [SerializeField] LayerMask layerMask;

    RaycastHit hit;

    private void Update()
    {
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, maxDistance, layerMask))
        {
            if(!hit.transform.gameObject.CompareTag("Interactable"))
            {
                return;
            }

            if (hit.transform.GetChild(0).TryGetComponent(out IInteractable interactable))
            {
                if (!Interacted)
                {
                    return;
                }
                interactable.OnInteract();
                interacted = false;
                Debug.Log("Interacted");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag("Interactable"))
        {
            return;
        }

        
    }

    public bool Interacted
    {
        get { return interacted; }
        set {interacted = value; }
    }
}

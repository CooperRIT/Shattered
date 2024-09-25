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

    //Temp Variables for tower placing
    [SerializeField] GameObject towerPrefab;
    MeshRenderer mR;

    public void OnInteract()
    {
        if(!canInteract)
        {
            return;
        }

        canInteract = false;
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        mR.enabled = false;

    }

    // Start is called before the first frame update
    void Awake()
    {
        mR = transform.parent.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

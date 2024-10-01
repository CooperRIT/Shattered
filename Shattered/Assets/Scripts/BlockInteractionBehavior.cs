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

    // Variables
    MeshRenderer mR;
    [SerializeField] GameObject canvas;
    private GameObject gm;

    public void OnInteract()
    {
        if(!canInteract)
        {
            return;
        }

        canvas.GetComponent<TowerSpawn>().menuActive = true;

    }

    // Start is called before the first frame update
    void Awake()
    {
        mR = transform.parent.GetComponent<MeshRenderer>();
        gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonUsed(GameObject prefab)
    {
        // TEMP tower costs 5 credits, you must have 5
        if (gm.GetComponent<GameManager>().Kills >= 5)
        {
            gm.GetComponent<GameManager>().Kills -= 5; // Take 5 currency away
            canInteract = false; // Deactivate the interactable
            Instantiate(prefab, transform.position, Quaternion.identity); // Create the tower
            mR.enabled = false; // Deactivate the collision detection
        }
    }
}

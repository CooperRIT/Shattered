using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementPointer : MonoBehaviour
{
    [SerializeField] Transform playerCamera;

    [SerializeField] float maxDistance;

    [SerializeField] LayerMask layerMask;

    bool canPlace = true;

    Collider boxCollider;

    [SerializeField] int colliderCount;

    Material cubeMaterial;

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, maxDistance, layerMask))
        {
            transform.position = hit.point;
        }
    }

    private void OnEnable()
    {
        colliderCount = 0;
        cubeMaterial.color = Color.green;
    }

    private void Awake()
    {
        cubeMaterial = GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        canPlace = false;
        colliderCount += 1;
        Debug.Log("collided");
        cubeMaterial.color = Color.red;
    }

    private void OnTriggerExit(Collider other)
    {
        colliderCount -= 1;

        if(colliderCount > 0)
        {
            return;
        }

        cubeMaterial.color = Color.green;
        canPlace = true;
    }

    public bool CanPlace
    {
        get { return canPlace; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    //Prefab of projectile
    [SerializeField]
    private GameObject projectilePrefab; 

    //Spawn Point
    [SerializeField]
    private Transform firePoint; 

    private MainPlayerControls mainPlayerControls;
    //private InputAction attackAction;

    void Awake()
    {
        mainPlayerControls = new MainPlayerControls();
    }

    void OnEnable()
    {
        mainPlayerControls.BasicControls.Enable();
        mainPlayerControls.BasicControls.Attack.performed += (InputAction.CallbackContext ctx) => { Attack(); };
    }

    void OnDisable()
    {
        mainPlayerControls.BasicControls.Attack.performed -= (InputAction.CallbackContext ctx) => { Attack(); };
        mainPlayerControls.BasicControls.Disable();
    }

    void OnAttack(InputAction.CallbackContext context)
    {
        Attack();
    }

    void Attack()
    {
        // Instantiate the projectile at the fire point's position and rotation
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
    }
}

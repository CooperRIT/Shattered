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

    //Cooper - We alerady have a reference to this in the player controls script, please use that script to map actions
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

    //Cooper - I assume the code below is the remnants of something you were trying to create, please just use 1 method for this

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

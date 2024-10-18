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

    [SerializeField]
    private PlayerBullet bullet;

    [SerializeField]
    private Camera mainCamera;

    private Vector3 cameraDirection;
    public Vector3 CameraDirection { get { return cameraDirection; } }

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        cameraDirection = mainCamera.transform.forward;
    }

    public void Attack(Vector3 direction)
    {
        // Instantiate the projectile at the fire point's position and rotation
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        bullet = projectile.GetComponent<PlayerBullet>();
        bullet.SetDirection(direction);
    }
}

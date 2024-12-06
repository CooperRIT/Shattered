using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour, CanBeBuffed
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

    private Vector3 cameraDirection => Camera.main.transform.forward;

    public float BuffableStatOne { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float BuffableStatTwo 
    { 
        get => timerAmmount; 
        set => timerAmmount = value; 
    }

    private float timer;

    [SerializeField] float timerAmmount = 5;

    [SerializeField] VoidEventChannel onFirstPlayerAttack_EventChannel;
    bool isFirstAttack = true;

    [SerializeField] Image cooldownCircle;
    [SerializeField] Sprite upCircle;
    [SerializeField] Sprite downCircle;
    [SerializeField] TextMeshProUGUI cooldownTimer;
    private bool refresh = true;

    void Awake()
    {

    }

    void Update()
    {
        if(timer > Time.time)
        {
            cooldownTimer.text = ((int)(timer - Time.time)).ToString();
        }
        else if(refresh)
        {
            refresh = false;
            cooldownTimer.text = "RMB";
            cooldownCircle.sprite = upCircle;
        }
    }

    public void Attack()
    {
        if (isFirstAttack)
        {
            onFirstPlayerAttack_EventChannel.CallEvent(new());
            isFirstAttack = false;
        }

        if(timer > Time.time)
        {
            return;
        }

        // Instantiate the projectile at the fire point's position and rotation
        Transform projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity).transform;

        projectile.forward = cameraDirection;

        timer = Time.time + timerAmmount;

        cooldownCircle.sprite = downCircle;
        refresh = true;
    }

    public void ModifyStats(float statModifyOne, float statModifyTwo)
    {
        if(timerAmmount <= .5f)
        {
            return;
        }

        Debug.Log("buffed");

        timerAmmount -= statModifyTwo / 2;
    }
}

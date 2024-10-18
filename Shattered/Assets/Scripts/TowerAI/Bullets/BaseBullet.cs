using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    float deathTimer = .3f;

    [SerializeField] float bulletSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deathTimer);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Enemy"))
        {
            return;
        }

    }
}

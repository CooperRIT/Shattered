using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5;
    [SerializeField] float dragRate = 5;
    float fixedUpdateMultiplier = 100;

    private Vector2 wasdInput;
    private Rigidbody rb;
    private Transform parentTransform;


    public Vector2 WASDInput
    {
        get { return wasdInput; }
        set { wasdInput = value; }
    }


    // Start is called before the first frame update
    void Awake()
    {
        rb = transform.GetComponentInParent<Rigidbody>();
        parentTransform = transform.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 force = wasdInput.y * parentTransform.forward + wasdInput.x * parentTransform.right;

        force *= playerSpeed;

        Vector3 dampeningForce = rb.velocity * dragRate;

        rb.AddForce((force - dampeningForce) * (fixedUpdateMultiplier * Time.fixedDeltaTime));
    }
}

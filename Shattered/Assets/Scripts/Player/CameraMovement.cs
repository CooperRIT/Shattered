using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform parentTransform;
    Transform cameraTransform;

    Vector2 m_Position;

    public Vector2 M_Position
    {
        get { return m_Position; }
        set { m_Position = value; }
    }


    float maxX = 90;

    [SerializeField] float sensitvity;

    float xRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
    }

    void RotatePlayer()
    {
        float mouseX = m_Position.x * sensitvity * Time.deltaTime;
        float mouseY = m_Position.y * sensitvity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -maxX, maxX);

        cameraTransform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        parentTransform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}

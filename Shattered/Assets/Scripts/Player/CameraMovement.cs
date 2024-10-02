using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform parentTransform;   // The player's body or parent object
    Transform cameraTransform;                   // The camera's transform

    Vector2 m_Position;                          // Mouse input position

    public Vector2 M_Position
    {
        get { return m_Position; }
        set { m_Position = value; }
    }

    float maxX = 90f;                            // Maximum vertical look limit
    [SerializeField] float sensitivity = 100f;   // Mouse sensitivity

    float xRotation;                             // Vertical rotation tracking
    float yRotation;                             // Horizontal rotation tracking
    float smoothTime = 0.05f;                    // Smoothing time for rotation

    Vector2 currentVelocity;                     // Used for smooth damp calculations

    // Start is called before the first frame update
    void Start()
    {
        // Store the camera transform
        cameraTransform = transform.parent;

        // Optionally lock the cursor for first-person view
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        RotatePlayer();
    }

    void RotatePlayer()
    {
        // Get mouse input with sensitivity
        float mouseX = m_Position.x * sensitivity * Time.deltaTime;
        float mouseY = m_Position.y * sensitivity * Time.deltaTime;

        // Add the rotation values
        yRotation += mouseX;
        xRotation -= mouseY;

        // Clamp the vertical rotation to prevent unnatural camera flips
        xRotation = Mathf.Clamp(xRotation, -maxX, maxX);

        // Smooth horizontal rotation using SmoothDamp for smooth transitions
        float smoothYRotation = Mathf.SmoothDampAngle(parentTransform.eulerAngles.y, yRotation, ref currentVelocity.x, smoothTime);
        parentTransform.rotation = Quaternion.Euler(0f, smoothYRotation, 0f);

        // Apply vertical rotation directly to the camera for up/down look
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // Correct local rotation for camera
    }
}

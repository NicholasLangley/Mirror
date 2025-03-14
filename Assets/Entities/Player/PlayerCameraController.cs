using System;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField]
    float maxVerticalLookAngle = 89f;
    float verticalLookAngle;

    public float mouseSensitivityX, MouseSensitivityY;

    public bool invertMouseX, invertMouseY;

    [SerializeField]
    Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        verticalLookAngle = 0f;   
    }

    public void updateCamera(Vector3 position, Vector2 rotationVector)
    {
        if (invertMouseX) { rotationVector.x *= -1; }
        if (invertMouseY) { rotationVector.y *= -1; }

        transform.position = position;

        transform.Rotate(transform.up, rotationVector.x * mouseSensitivityX);

        verticalLookAngle += rotationVector.y * MouseSensitivityY;
        verticalLookAngle = Mathf.Clamp(verticalLookAngle, -maxVerticalLookAngle, maxVerticalLookAngle);
        cam.transform.localRotation = Quaternion.Euler(-verticalLookAngle, 0, 0);
    }
}

using System;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField]
    public Camera cam;

    [Header("Camera Settings")]
    [SerializeField]
    float maxVerticalLookAngle = 89f;
    float verticalLookAngle;

    public float mouseSensitivityX, MouseSensitivityY;

    public bool invertMouseX, invertMouseY;

    Transform characterFollowTransform;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        verticalLookAngle = 0f;   
    }

    private void Update()
    {
        transform.position = characterFollowTransform.position;
    }

    public void SetFollowTransform(Transform followPoint)
    {
        characterFollowTransform = followPoint;
        transform.position = characterFollowTransform.position;
    }
    public void updateCameraAim(Vector2 rotationVector)
    {
        if (invertMouseX) { rotationVector.x *= -1; }
        if (invertMouseY) { rotationVector.y *= -1; }

        transform.Rotate(transform.up, rotationVector.x * mouseSensitivityX);

        verticalLookAngle += rotationVector.y * MouseSensitivityY;
        verticalLookAngle = Mathf.Clamp(verticalLookAngle, -maxVerticalLookAngle, maxVerticalLookAngle);
        cam.transform.localRotation = Quaternion.Euler(-verticalLookAngle, 0, 0);
    }
}

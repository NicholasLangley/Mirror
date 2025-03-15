using KinematicCharacterController.Examples;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerInputHandler playerInputHandler;

    [Header("Camera")]
    [SerializeField]
    PlayerCameraController playerCameraController;
    public Transform cameraFollowTransform;

    [Header("Character")]
    [SerializeField]
    CharacterController characterController;

    private Vector3 _lookInputVector = Vector3.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Tell camera to follow transform
        playerCameraController.SetFollowTransform(cameraFollowTransform);

    }

    void Update()
    {
        HandlePlayerInput();
    }

    void HandlePlayerInput()
    {
        playerCameraController.updateCameraAim(playerInputHandler.aimInput);

        MovementInputs movementInputs = new MovementInputs();
        movementInputs.moveAxis = playerInputHandler.moveInput;
        movementInputs.aimRotation = playerCameraController.transform.rotation;

        characterController.SetInputs(movementInputs);
    }
}

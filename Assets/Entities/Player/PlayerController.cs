using KinematicCharacterController.Examples;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerInputHandler playerInputHandler;

    [Header("RED")]
    [SerializeField]
    CharacterController redCharacterController;
    [SerializeField]
    PlayerCameraController redPlayerCameraController;
    public Transform redCameraFollowTransform;

    [Header("BLUE")]
    [SerializeField]
    CharacterController blueCharacterController;
    [SerializeField]
    PlayerCameraController bluePlayerCameraController;
    public Transform blueCameraFollowTransform;

    private Vector3 _lookInputVector = Vector3.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Tell cameras to follow transform
        redPlayerCameraController.SetFollowTransform(redCameraFollowTransform);
        bluePlayerCameraController.SetFollowTransform(blueCameraFollowTransform);

    }

    void Update()
    {
        HandlePlayerInput();
    }

    void HandlePlayerInput()
    {
        //update cameras
        redPlayerCameraController.updateCameraAim(playerInputHandler.aimInput);
        bluePlayerCameraController.updateCameraAim(playerInputHandler.aimInput);

        //create input structs to update player controllers
        MovementInputs redMovementInputs = new MovementInputs();
        redMovementInputs.moveAxis = playerInputHandler.moveInput;
        redMovementInputs.aimRotation = redPlayerCameraController.transform.rotation;
        redMovementInputs.jumpPressed = playerInputHandler.jumpInput;
        redCharacterController.SetInputs(redMovementInputs);

        MovementInputs blueMovementInputs = new MovementInputs();
        blueMovementInputs.moveAxis = playerInputHandler.moveInput;
        blueMovementInputs.aimRotation = bluePlayerCameraController.transform.rotation;
        blueMovementInputs.jumpPressed = playerInputHandler.jumpInput;
        blueCharacterController.SetInputs(blueMovementInputs);
    }
}

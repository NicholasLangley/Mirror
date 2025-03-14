using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    InputActionAsset inputActionMap;

    [SerializeField]
    string actionMapName;

    InputAction moveAction { get; set; }
    InputAction aimAction { get; set; }
    InputAction attackAction { get; set; }
    InputAction interactAction { get; set; }
    InputAction jumpAction { get; set; }
    InputAction crouchAction { get; set; }

    public Vector2 moveInput { get; private set; }
    public Vector2 aimInput { get; private set; }
    public bool attackInput { get; private set; }
    public bool interactInput { get; private set; }
    public bool jumpInput { get; private set; }
    public bool crouchInput { get; private set; }

    void Awake()
    {
        moveAction = inputActionMap.FindActionMap(actionMapName).FindAction("Move");
        aimAction = inputActionMap.FindActionMap(actionMapName).FindAction("Aim");
        attackAction = inputActionMap.FindActionMap(actionMapName).FindAction("Attack");
        interactAction = inputActionMap.FindActionMap(actionMapName).FindAction("Interact");
        jumpAction = inputActionMap.FindActionMap(actionMapName).FindAction("Jump");
        crouchAction = inputActionMap.FindActionMap(actionMapName).FindAction("Crouch");
        RegisterInputActions();
    }

    void RegisterInputActions()
    {
        moveAction.performed += context => moveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => moveInput = Vector2.zero;

        aimAction.performed += context => aimInput = context.ReadValue<Vector2>();
        aimAction.canceled += context => aimInput = Vector2.zero;

        attackAction.performed += context => attackInput = true;
        attackAction.canceled += context => attackInput = false;

        interactAction.performed += context => interactInput = true;
        interactAction.canceled += context => interactInput = false;

        jumpAction.performed += context => jumpInput = true;
        jumpAction.canceled += context => jumpInput = false;

        crouchAction.performed += context => crouchInput = true;
        crouchAction.canceled += context => crouchInput = false;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        aimAction.Enable();
        attackAction.Enable();
        interactAction.Enable();
        jumpAction.Enable();
        crouchAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        aimAction.Disable();
        attackAction.Disable();
        interactAction.Disable();
        jumpAction.Disable();
        crouchAction.Disable();
    }

}
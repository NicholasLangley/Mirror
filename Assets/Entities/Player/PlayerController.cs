using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerInputHandler playerInputHandler;

    [SerializeField]
    PlayerCameraController playerCameraController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCameraController.updateCamera(playerInputHandler.moveInput, playerInputHandler.aimInput);
    }
}

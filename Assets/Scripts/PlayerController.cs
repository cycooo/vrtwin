using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // exported variables
    [SerializeField] Transform playerCamera;
    [SerializeField] float mouseSensitivity = 2f;
    [SerializeField] float walkSpeed = 5;
    [SerializeField] float gravity = 12.0f;
    [SerializeField] float moveSmoothTime = 0.1f;
    [SerializeField] public bool lockCursor = true;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;

    CharacterController characterController = null;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock the cursor at the start
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    // Function to handle looking around with the mouse
    private void UpdateMouseLook()
    {
        // Get the mouse input and put it in a Vector2
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // Set the camera's pitch and clamp it so the player can't look up or down more than 90 degrees
        cameraPitch -= mouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        // Rotate the camera up and down
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        // Rotate the player as a whole left and right
        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);
    }

    // Function to handle moving the player
    private void UpdateMovement()
    {
        //QueueJump();

        // Get the input direction and put it in a Vector2
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        // Apply smoothing to the movement vector
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        // Set the player's vertical velocity to 0 when they are on the ground
        if (characterController.isGrounded)
        {
            velocityY = 0.0f;
        }

        // When the player is not grounded, apply gravity to velocityY
        velocityY += gravity * Time.deltaTime;

        // Create a vector that combines all movement directions (up down, left right, forward backward)
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.down * velocityY;

        // Move the player using the above vector
        characterController.Move(velocity * Time.deltaTime);
    }

    private void QueueJump()
    {
        // to do
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerMovementsFly : MonoBehaviour
{
    public InputActionAsset inputActions;

    private CharacterController controller;
    private InputAction moveAction;

    public float speed = 12f;
    public float gravity = -9.81f;
    private bool movementIsEnabled = true;

    private Vector3 verticalVelocity;

    public void ToggleMovement(bool enable)
    {
        movementIsEnabled = enable;

        // If we are re-enabling, we might need a small delay
        if (enable)
        {
            StartCoroutine(ReEnableMovementAfterDelay(0.1f));
        }
    }

    private IEnumerator ReEnableMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        movementIsEnabled = true;
    }



    void Awake()
    {
        controller = GetComponent<CharacterController>();

        if (inputActions != null)
        {
            var locomotionMap = inputActions.FindActionMap("XRI LeftHand Locomotion");
            moveAction = locomotionMap.FindAction("Move");
        }
    }

    void OnEnable()
    {
        if (moveAction != null)
        {
            moveAction.Enable();
        }
    }

    void OnDisable()
    {
        if (moveAction != null)
        {
            moveAction.Disable();
        }
    }
    public void TeleportTo(Transform destination)
    {
        // Disable the CharacterController to move the player directly
        controller.enabled = false;

        // Set the player's position to the destination's position
        transform.position = destination.position;

        // Re-enable the CharacterController after moving
        controller.enabled = true;
    }
    void Update()
    {
        if (!movementIsEnabled)
        {
            return;
        }

        if (controller == null || moveAction == null) return;


        // --- HORIZONTAL MOVEMENT ---
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * speed * Time.deltaTime);

        // --- VERTICAL MOVEMENT (GRAVITY ONLY) ---
        if (controller.isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -2f; // Keep player grounded
        }

        // Always apply gravity
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);

    }
}
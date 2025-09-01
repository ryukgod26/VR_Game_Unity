using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerMovementsFly : MonoBehaviour
{
    public InputActionAsset inputActions;

    private CharacterController controller;
    private InputAction moveAction;

    public float speed = 12f;
    [Tooltip("Gravity force applied every second (negative value).")]
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
        if (!movementIsEnabled) return;
        if (controller == null || moveAction == null) return;

        // Read planar input (Vector2). We purposely ignore any attempt to inject vertical motion via keys (Q/E etc.).
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        // Build a yaw-only frame so that looking up/down (pitch) does NOT cause ascent.
        Vector3 fwd = transform.forward; fwd.y = 0f; fwd = fwd.sqrMagnitude > 0.0001f ? fwd.normalized : Vector3.forward;
        Vector3 right = transform.right; right.y = 0f; right = right.sqrMagnitude > 0.0001f ? right.normalized : Vector3.right;
        Vector3 desired = (right * moveInput.x + fwd * moveInput.y) * speed;
        controller.Move(desired * Time.deltaTime);

        // Gravity handling (always downward only)
        if (controller.isGrounded && verticalVelocity.y < 0f)
        {
            verticalVelocity.y = -2f; // sticky ground force
        }
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }
}
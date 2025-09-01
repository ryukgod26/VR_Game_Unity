using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Root transform of the Player/XR Origin. If left empty will attempt to auto-find by tag 'Player'.")]
    public Transform player;
    [Tooltip("Destination portal (the exit). Player will be moved to its position & rotation.")]
    public Transform destinationPortal;

    [Header("Settings")] 
    [Tooltip("Optional extra offset applied after teleport (e.g., to avoid overlapping portal collider).")]
    public Vector3 exitOffset = Vector3.forward * 0.25f;
    [Tooltip("Delay (seconds) before allowing another teleport after exiting the portal.")]
    public float cooldown = 0.25f;

    private bool isTeleporting = false;
    private float cooldownTimer = 0f;

    private void Awake()
    {
        if (player == null)
        {
            GameObject tagged = GameObject.FindGameObjectWithTag("Player");
            if (tagged != null) player = tagged.transform;
        }
        if (destinationPortal == null)
        {
            Debug.LogWarning(name + ": Destination portal not assigned.");
        }
    }

    private void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                cooldownTimer = 0f;
                isTeleporting = false; // ensure reset after cooldown.
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TryInitiateTeleport(other);
    }

    private void OnTriggerStay(Collider other)
    {
        // In case high speed causes enter to miss or player already inside when scene loads.
        TryInitiateTeleport(other);
    }

    private void TryInitiateTeleport(Collider other)
    {
        if (isTeleporting || cooldownTimer > 0f) return;
        if (!IsPlayerCollider(other)) return;

        // If player ref still null but we detected a child, climb up to root that has CharacterController
        if (player == null)
        {
            var cc = other.GetComponentInParent<CharacterController>();
            if (cc != null) player = cc.transform;
            else player = other.transform.root; // fallback
        }
        TeleportPlayer();
    }

    private bool IsPlayerCollider(Collider other)
    {
        if (player == null) return other.CompareTag("Player");
        // Check if the collider belongs to the player hierarchy.
        return other.transform == player || other.transform.IsChildOf(player);
    }

    private void TeleportPlayer()
    {
        if (player == null || destinationPortal == null)
        {
            Debug.LogWarning(name + ": Cannot teleport - missing references.");
            return;
        }

        isTeleporting = true;
        cooldownTimer = cooldown; // start cooldown immediately.

        Debug.Log("[PortalTeleporter] Teleporting player to " + destinationPortal.name);

        CharacterController cc = player.GetComponent<CharacterController>();
        bool hadCC = cc != null && cc.enabled;
        if (hadCC) cc.enabled = false;

        // Teleport position & rotation
        Vector3 targetPos = destinationPortal.position + destinationPortal.TransformVector(exitOffset);
        player.SetPositionAndRotation(targetPos, destinationPortal.rotation);

        if (hadCC) cc.enabled = true;
        Debug.Log("[PortalTeleporter] Teleport complete.");
    }
}
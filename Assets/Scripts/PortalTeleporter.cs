using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform destinationPortal;

    private bool isTeleporting = false;

    // This function is called when another collider enters this trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering is the player and we aren't already teleporting
        if (other.CompareTag("Player") && !isTeleporting)
        {
            isTeleporting = true;
            TeleportPlayer();
        }
    }

    // This function is called when another collider exits this trigger
    private void OnTriggerExit(Collider other)
    {
        // Allow teleporting again once the player has left the portal area
        if (other.CompareTag("Player"))
        {
            isTeleporting = false;
        }
    }

    private void TeleportPlayer()
    {
        Debug.Log("Teleporting Player");
        // Important: If you are using a CharacterController, you must disable it before teleporting
        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null)
        {
            Debug.Log("Finded Character");
            cc.enabled = false;
        }

        // Move the player to the destination's position
        player.position = destinationPortal.position;

        // Rotate the player to face the destination's forward direction
        player.rotation = destinationPortal.rotation;

        // Re-enable the CharacterController after the teleport is complete
        if (cc != null)
        {
            cc.enabled = true;
            Debug.Log("TelePortation Completed");
        }
    }
}
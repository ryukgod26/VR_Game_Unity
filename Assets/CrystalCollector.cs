using UnityEngine;

public class CrystalCollector : MonoBehaviour
{
    // This function is called automatically when this collider enters another trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object we touched has the "Crystal" tag
        if (other.CompareTag("Crystal"))
        {
            // If it's a crystal, "collect" it.
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject crystal)
    {
        // Print a message to the console to confirm collection
        Debug.Log("Crystal collected!");

        // You can add scoring logic here, e.g., GameManager.instance.AddScore(1);

        // Make the crystal disappear
        Destroy(crystal);
    }
}
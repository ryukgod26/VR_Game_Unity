using UnityEngine;

public class CrystalCollector : MonoBehaviour
{
    // Global crystal counter accessible from anywhere.
    public static int CollectedCrystalCount { get; private set; } = 0;

    [Tooltip("Total crystals needed to win.")]
    public int crystalsToWin = 3;

    [Tooltip("If true, crystals are Destroyed. If false, they are just hidden & disabled.")]
    public bool destroyCrystal = false;

    [Header("Collection Triggers")] 
    [Tooltip("If true, mere trigger contact collects the crystal. If false, require explicit Grab call.")]
    public bool collectOnTrigger = false;
    [Tooltip("If true, calling OnCrystalGrabbed (e.g., from XR Grab event) will collect.")]
    public bool collectOnGrab = true;
    [Tooltip("Optional: Only allow trigger collection if the collider has this tag (e.g., 'PlayerBody'). Leave empty to accept any player collider.")]
    public string triggerCollectorTag = "";

    private void OnTriggerEnter(Collider other)
    {
        if (!collectOnTrigger) return;
        if (!string.IsNullOrEmpty(triggerCollectorTag) && !other.CompareTag(triggerCollectorTag)) return;
        TryCollect(other.gameObject);
    }

    // Hook this to XR Interaction Toolkit's grab event (OnSelectEnter) via UnityEvent or script.
    public void OnCrystalGrabbed(UnityEngine.Object grabbed)
    {
        if (!collectOnGrab) return;
        if (grabbed is GameObject go) TryCollect(go);
        else if (grabbed is Component comp) TryCollect(comp.gameObject);
    }

    public void TryCollect(GameObject target)
    {
        if (!target.CompareTag("Crystal")) return;
        Collect(target);
    }

    private void Collect(GameObject crystal)
    {
        // Prevent double collection.
        crystal.tag = "Untagged";

        if (destroyCrystal)
        {
            Destroy(crystal);
        }
        else
        {
            foreach (var r in crystal.GetComponentsInChildren<Renderer>()) r.enabled = false;
            foreach (var c in crystal.GetComponentsInChildren<Collider>()) c.enabled = false;
        }

        CollectedCrystalCount++;
        Debug.Log($"Crystal collected! Total: {CollectedCrystalCount}");
        if (CollectedCrystalCount >= crystalsToWin)
        {
            Debug.Log("Player Won");
        }
    }
}
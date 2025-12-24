using UnityEngine;

public class MagnifierZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LeafMagnify leaf = other.GetComponentInParent<LeafMagnify>();

        if (leaf != null)
        {
            leaf.StartMagnify();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        LeafMagnify leaf = other.GetComponentInParent<LeafMagnify>();

        if (leaf != null)
        {
            leaf.StopMagnify();
        }
    }
}

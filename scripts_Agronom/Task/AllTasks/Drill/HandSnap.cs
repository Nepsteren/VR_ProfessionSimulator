using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class HandSnapToGrip : MonoBehaviour
{
    private Transform handTransform;
    private Transform originalParent;
    [SerializeField] InputActionManager actionManager;

    public void Snap(Transform grip)
    {
        actionManager.enabled = false;
        originalParent = transform.parent;
        transform.SetParent(grip);
        transform.localPosition = Vector3.zero;
        transform.localRotation = grip.rotation;
    }

    public void Release()
    {
        actionManager.enabled = true;
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
    }
}

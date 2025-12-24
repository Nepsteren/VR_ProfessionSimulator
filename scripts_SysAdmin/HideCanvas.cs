using UnityEngine;

public class HideCanvas : MonoBehaviour
{
    public void HideParentCanvas()
    {
        transform.root.gameObject.SetActive(false);
    }
}

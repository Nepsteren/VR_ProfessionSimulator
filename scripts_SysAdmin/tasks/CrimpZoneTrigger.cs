using UnityEngine;

public class CrimpZoneTrigger : MonoBehaviour
{
    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;

        Debug.Log("»грок вошЄл в зону обжима");

        TaskController.instance.ActivityTask?.Complete();
    }

    public void ResetTrigger()
    {
        triggered = false;
    }
}

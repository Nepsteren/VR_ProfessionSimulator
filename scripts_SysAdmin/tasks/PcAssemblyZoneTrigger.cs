using UnityEngine;

public class PcAssemblyZoneTrigger : MonoBehaviour
{
    private bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;

        Debug.Log("Старт со сборки ПК");

        TaskController.instance.trainingPath =
            TaskController.TrainingPath.StartedWithAssembly;

        TaskController.instance.ChangeTaskAndSetIndex("InstallMotherboard");
    }
}

using UnityEngine;

public class EnterPcAssemblyZoneTask : Task
{
    [SerializeField] private AssemblyStarter assemblyStarter;
    private bool triggered;

    public override string RUDescription => "войдите в зону сборки ПК";
    public override string Name => "EnterPcAssemblyZone";

    private void OnTriggerEnter(Collider other)
    {
        if (!activated) return;
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;

        Debug.Log("Игрок вошёл в зону сборки ПК");

        assemblyStarter.StartAssemblyExternally();

        Complete();
        TaskController.instance.ChangeTaskAndSetIndex("InstallMotherboard");
    }
}

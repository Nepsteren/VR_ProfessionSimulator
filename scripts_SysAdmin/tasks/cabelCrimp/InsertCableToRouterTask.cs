using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InsertCableToRouterTask : Task
{
    [Header("Socket")]
    [SerializeField] private XRSocketInteractor routerSocket;

    [Header("Visual")]
    [SerializeField] private GameObject routerLed;

    [Header("Highlight (Outline)")]
    [SerializeField] private Behaviour cableOutline;
    [SerializeField] private Behaviour routerOutline;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip insertSound;

    [Header("Zone Control")]
    [SerializeField] private AssemblyStarter assemblyStarter;
    [SerializeField] private GameObject pcAssemblyZoneVisual;

    private bool completed;

    public override string RUDescription => "вставь кабель в маршрутизатор";
    public override string Name => "InsertCableToRouter";

    public override void Terms()
    {
        base.Terms();

        completed = false;

        if (routerLed != null)
            routerLed.SetActive(false);

        if (pcAssemblyZoneVisual != null)
            pcAssemblyZoneVisual.SetActive(false);

        EnableHighlight(true);

        if (routerSocket != null)
            routerSocket.selectEntered.AddListener(OnCableInserted);
    }

    public override void Complete()
    {
        base.Complete();

        EnableHighlight(false);

        if (routerSocket != null)
            routerSocket.selectEntered.RemoveListener(OnCableInserted);
    }

    private void OnDestroy()
    {
        if (routerSocket != null)
            routerSocket.selectEntered.RemoveListener(OnCableInserted);
    }

    private void OnCableInserted(SelectEnterEventArgs args)
    {
        if (!activated || completed) return;

        completed = true;

        if (routerLed != null)
            routerLed.SetActive(true);

        if (audioSource != null && insertSound != null)
            audioSource.PlayOneShot(insertSound);

        if (assemblyStarter != null)
            assemblyStarter.UnlockAndHideZone();

        if (pcAssemblyZoneVisual != null)
            pcAssemblyZoneVisual.SetActive(true);

        Debug.Log("Зона обжима завершена, переход к сборке ПК");

        Complete();
        TaskController.instance.NextTask();
    }

    private void EnableHighlight(bool state)
    {
        if (cableOutline != null)
            cableOutline.enabled = state;

        if (routerOutline != null)
            routerOutline.enabled = state;
    }
}

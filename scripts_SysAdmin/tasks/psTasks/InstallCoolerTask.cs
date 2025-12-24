using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InstallCoolerTask : Task
{
    [Header("Socket")]
    [SerializeField] private XRSocketInteractor coolerSocket;

    [Header("Socket Highlight")]
    [SerializeField] private GameObject coolerSocketHighlight;

    [Header("Cooler Highlight (Outline)")]
    [SerializeField] private Behaviour coolerOutline;

    [Header("Sound (optional)")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip installSound;

    private bool installed;

    public override string RUDescription => "установить кулер на процессор";
    public override string Name => "InstallCooler";

    public override void Terms()
    {
        base.Terms();
        installed = false;

        if (coolerSocket != null)
        {
            coolerSocket.socketActive = true;
            coolerSocket.selectEntered.AddListener(OnCoolerInstalled);
        }

        if (coolerSocketHighlight != null)
            coolerSocketHighlight.SetActive(true);

        if (coolerOutline != null)
            coolerOutline.enabled = true;
    }

    public override void Complete()
    {
        base.Complete();

        if (coolerSocket != null)
            coolerSocket.selectEntered.RemoveListener(OnCoolerInstalled);

        if (coolerSocketHighlight != null)
            coolerSocketHighlight.SetActive(false);

        if (coolerOutline != null)
            coolerOutline.enabled = false;
    }

    private void OnCoolerInstalled(SelectEnterEventArgs args)
    {
        if (!activated || installed) return;

        installed = true;

        if (audioSource && installSound)
            audioSource.PlayOneShot(installSound);

        Debug.Log("Кулер установлен");

        Complete();
        TaskController.instance.NextTask();
    }
}

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InstallCpuTask : Task
{
    [Header("Socket")]
    [SerializeField] private XRSocketInteractor cpuSocket;

    [Header("Socket Highlight")]
    [SerializeField] private GameObject cpuSocketHighlight;

    [Header("CPU Highlight (Outline)")]
    [SerializeField] private Behaviour cpuOutline;

    [Header("CPU Indicator (on CPU)")]
    [SerializeField] private GameObject cpuSocketIndicator;

    [Header("Sound (optional)")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip installSound;

    private bool installed;

    public override string RUDescription => "установи процессор";
    public override string Name => "InstallCPU";

    public override void Terms()
    {
        base.Terms();
        installed = false;

        if (cpuSocket != null)
        {
            cpuSocket.socketActive = true;
            cpuSocket.selectEntered.AddListener(OnCpuInstalled);
        }

        if (cpuSocketHighlight != null)
            cpuSocketHighlight.SetActive(true);

        if (cpuOutline != null)
            cpuOutline.enabled = true;

        if (cpuSocketIndicator != null)
            cpuSocketIndicator.SetActive(true);
    }

    public override void Complete()
    {
        base.Complete();

        if (cpuSocket != null)
            cpuSocket.selectEntered.RemoveListener(OnCpuInstalled);

        if (cpuSocketHighlight != null)
            cpuSocketHighlight.SetActive(false);

        if (cpuOutline != null)
            cpuOutline.enabled = false;

        if (cpuSocketIndicator != null)
            cpuSocketIndicator.SetActive(false);
    }

    private void OnCpuInstalled(SelectEnterEventArgs args)
    {
        if (!activated || installed) return;

        installed = true;

        if (audioSource && installSound)
            audioSource.PlayOneShot(installSound);

        Debug.Log("Процессор установлен");

        Complete();
        TaskController.instance.NextTask();
    }
}

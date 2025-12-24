using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InstallPsuTask : Task
{
    [Header("Socket")]
    [SerializeField] private XRSocketInteractor psuSocket;

    [Header("Socket Highlight")]
    [SerializeField] private GameObject psuSocketHighlight;

    [Header("PSU Highlight (Outline)")]
    [SerializeField] private Behaviour psuOutline;

    [Header("Sound (optional)")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip installSound;

    private bool installed;

    public override string RUDescription => "установить блок питани€";
    public override string Name => "InstallPSU";

    public override void Terms()
    {
        base.Terms();
        installed = false;

        if (psuSocket != null)
        {
            psuSocket.socketActive = true;
            psuSocket.selectEntered.AddListener(OnPsuInstalled);
        }

        if (psuSocketHighlight != null)
            psuSocketHighlight.SetActive(true);

        if (psuOutline != null)
            psuOutline.enabled = true;
    }

    public override void Complete()
    {
        base.Complete();

        if (psuSocket != null)
            psuSocket.selectEntered.RemoveListener(OnPsuInstalled);

        if (psuSocketHighlight != null)
            psuSocketHighlight.SetActive(false);

        if (psuOutline != null)
            psuOutline.enabled = false;
    }

    private void OnPsuInstalled(SelectEnterEventArgs args)
    {
        if (!activated || installed) return;

        installed = true;

        if (audioSource && installSound)
            audioSource.PlayOneShot(installSound);

        Debug.Log("Ѕлок питани€ установлен");

        Complete();
        TaskController.instance.NextTask();
    }
}

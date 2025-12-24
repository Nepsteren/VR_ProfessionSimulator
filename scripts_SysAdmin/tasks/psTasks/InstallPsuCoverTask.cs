using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InstallPsuCoverTask : Task
{
    [Header("Socket")]
    [SerializeField] private XRSocketInteractor psuCoverSocket;

    [Header("Socket Highlight")]
    [SerializeField] private GameObject psuCoverHighlight;

    [Header("PSU Cover Highlight (Outline)")]
    [SerializeField] private Behaviour psuCoverOutline;

    [Header("Sound (optional)")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip installSound;

    private bool installed;

    public override string RUDescription => "установи защиту блока питания";
    public override string Name => "InstallPsuCover";

    public override void Terms()
    {
        base.Terms();
        installed = false;

        if (psuCoverSocket != null)
        {
            psuCoverSocket.socketActive = true;
            psuCoverSocket.selectEntered.AddListener(OnCoverInstalled);
        }

        if (psuCoverHighlight != null)
            psuCoverHighlight.SetActive(true);

        if (psuCoverOutline != null)
            psuCoverOutline.enabled = true;
    }

    public override void Complete()
    {
        base.Complete();

        if (psuCoverSocket != null)
            psuCoverSocket.selectEntered.RemoveListener(OnCoverInstalled);

        if (psuCoverHighlight != null)
            psuCoverHighlight.SetActive(false);

        if (psuCoverOutline != null)
            psuCoverOutline.enabled = false;
    }

    private void OnCoverInstalled(SelectEnterEventArgs args)
    {
        if (!activated || installed) return;

        installed = true;

        if (audioSource && installSound)
            audioSource.PlayOneShot(installSound);

        Debug.Log("Защита БП установлена");

        Complete();

        PcAssemblyZoneManager.instance.UnlockAndOpen();

        Debug.Log("trainingPath = " + TaskController.instance.trainingPath);

        if (TaskController.instance.trainingPath ==
            TaskController.TrainingPath.StartedWithAssembly)
        {
            Debug.Log("Переход к обжиму");
            TaskController.instance.ChangeTaskAndSetIndex("EnterCrimpZone");
        }
        else
        {
            Debug.Log("Финал обучения");
            TaskController.instance.NextTask(); 
        }
    }



}

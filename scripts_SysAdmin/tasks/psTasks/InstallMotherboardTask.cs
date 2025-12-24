using UnityEngine;

public class InstallMotherboardTask : Task
{
    [Header("PC")]
    [SerializeField] private PCMaster pcMaster;

    [Header("Socket Highlight")]
    [SerializeField] private GameObject socketHighlight;

    [Header("Motherboard Highlight (Outline)")]
    [SerializeField] private Behaviour motherboardOutline;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip installSound;

    private PCMaster.PCComponent motherboard;
    private bool completed;

    public override string RUDescription => "установи материнскую плату";
    public override string Name => "InstallMotherboard";

    public override void Terms()
    {
        base.Terms();
        completed = false;

        if (socketHighlight != null)
            socketHighlight.SetActive(true);

        if (motherboardOutline != null)
            motherboardOutline.enabled = true;

        motherboard = null;

        foreach (var comp in pcMaster.components)
        {
            if (comp.componentName.ToLower() == "motherboard")
            {
                motherboard = comp;
                break;
            }
        }

        if (motherboard == null)
            Debug.LogError("Motherboard component not found");
    }

    private void Update()
    {
        if (!activated || completed || motherboard == null)
            return;

        if (motherboard.isInstalled)
        {
            Complete();
        }
    }

    public override void Complete()
    {
        if (completed) return;

        completed = true;
        base.Complete();

        if (audioSource != null && installSound != null)
            audioSource.PlayOneShot(installSound);

        if (socketHighlight != null)
            socketHighlight.SetActive(false);

        if (motherboardOutline != null)
            motherboardOutline.enabled = false;

        Debug.Log("Материнская плата установлена");

        TaskController.instance.NextTask();
    }
}

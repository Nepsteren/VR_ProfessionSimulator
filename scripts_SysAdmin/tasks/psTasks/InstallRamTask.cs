using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class InstallRamTask : Task
{
    [Header("RAM Sockets (НЕ ТРОГАЕМ)")]
    [SerializeField] private List<XRSocketInteractor> ramSockets;

    [Header("Socket Visual")]
    [SerializeField] private GameObject[] socketHighlights;

    [Header("RAM Highlight (Outline)")]
    [SerializeField] private Behaviour[] ramOutlines;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip installSound;

    private int installedCount;

    public override string RUDescription => "установи оперативную память (4 модуля)";
    public override string Name => "InstallRAM";

    public override void Terms()
    {
        base.Terms();
        installedCount = 0;

        for (int i = 0; i < ramSockets.Count; i++)
        {
            if (ramSockets[i] == null) continue;

            ramSockets[i].selectEntered.AddListener(OnRamInstalled);
            ramSockets[i].selectExited.AddListener(OnRamRemoved);
            ramSockets[i].socketActive = true;

            if (socketHighlights != null && i < socketHighlights.Length)
                socketHighlights[i].SetActive(true);

            if (ramOutlines != null && i < ramOutlines.Length && ramOutlines[i] != null)
                ramOutlines[i].enabled = true;
        }
    }

    public override void Complete()
    {
        base.Complete();

        for (int i = 0; i < ramSockets.Count; i++)
        {
            if (ramSockets[i] == null) continue;

            ramSockets[i].selectEntered.RemoveListener(OnRamInstalled);
            ramSockets[i].selectExited.RemoveListener(OnRamRemoved);
        }

        DisableAllRamOutlines();
    }

    private void OnRamInstalled(SelectEnterEventArgs args)
    {
        installedCount++;

        if (audioSource != null && installSound != null)
            audioSource.PlayOneShot(installSound);

        UpdateHighlights();
        UpdateRamOutlines();

        Debug.Log($"RAM установлено: {installedCount}/4");

        if (installedCount >= ramSockets.Count)
        {
            Debug.Log("Вся оперативная память установлена");
            TaskController.instance.NextTask();
        }
    }

    private void OnRamRemoved(SelectExitEventArgs args)
    {
        installedCount = Mathf.Max(0, installedCount - 1);

        UpdateHighlights();
        UpdateRamOutlines();
    }

    private void UpdateHighlights()
    {
        if (socketHighlights == null) return;

        for (int i = 0; i < socketHighlights.Length; i++)
        {
            bool occupied = i < ramSockets.Count && ramSockets[i].hasSelection;
            socketHighlights[i].SetActive(!occupied);
        }
    }

    private void UpdateRamOutlines()
    {
        if (ramOutlines == null) return;

        for (int i = 0; i < ramOutlines.Length; i++)
        {
            if (ramOutlines[i] == null) continue;

            bool installed = i < ramSockets.Count && ramSockets[i].hasSelection;
            ramOutlines[i].enabled = !installed;
        }
    }

    private void DisableAllRamOutlines()
    {
        if (ramOutlines == null) return;

        foreach (var outline in ramOutlines)
            if (outline != null)
                outline.enabled = false;
    }
}

using UnityEngine;

public class ReadSafetyInstructionTask : Task
{
    [SerializeField] private GameObject instructionCanvas;
    [SerializeField] private GameObject safetyBlocker;
    [SerializeField] private GameObject startZoneVisual;
    [SerializeField] private GameObject startZoneVisualPC;


    public override string RUDescription =>
        "ознакомься с инструктажем по теxнике безопасности";
    public override string Name => "ReadSafetyInstruction";

    public override void Terms()
    {
        base.Terms();

        if (instructionCanvas != null)
            instructionCanvas.SetActive(true);

        if (safetyBlocker != null)
            safetyBlocker.SetActive(true);

        if (startZoneVisual != null)
            startZoneVisual.SetActive(false);

        if (startZoneVisualPC != null)
            startZoneVisualPC.SetActive(false);
    }

    public override void Complete()
    {
        if (!activated) return;

        activated = false;

        if (instructionCanvas != null)
            instructionCanvas.SetActive(false);
        
        if (safetyBlocker != null)
            safetyBlocker.SetActive(false);

        if (startZoneVisual != null)
            startZoneVisual.SetActive(true);

        if (startZoneVisualPC != null)
            startZoneVisualPC.SetActive(true);

        TaskController.instance.NextTask();
    }
}

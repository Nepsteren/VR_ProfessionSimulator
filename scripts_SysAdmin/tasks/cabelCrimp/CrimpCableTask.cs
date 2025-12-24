using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class CrimpCableTask : Task
{
    [Header("Sockets")]
    [SerializeField] private XRSocketInteractor connectorSocket;
    [SerializeField] private XRSocketInteractor cableSocket;

    [Header("Crimper")]
    [SerializeField] private XRGrabInteractable crimperGrab;
    [SerializeField] private Animator crimperAnimator;
    [SerializeField] private string crimpTriggerName = "Crimp";

    [Header("Visuals")]
    [SerializeField] private GameObject uncrimpedConnector;
    [SerializeField] private GameObject crimpedConnector;

    [Header("Highlight (Outline)")]
    [SerializeField] private Behaviour cableOutline;
    [SerializeField] private Behaviour crimperOutline;
    [SerializeField] private Behaviour connectorOutline;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip crimpSound;

    private bool isCrimped;

    public override string RUDescription => "обожми кабель в коннекторе";
    public override string Name => "CrimpCable";

    public override void Terms()
    {
        base.Terms();

        isCrimped = false;

        if (uncrimpedConnector) uncrimpedConnector.SetActive(true);
        if (crimpedConnector) crimpedConnector.SetActive(false);

        EnableHighlight(true);

        if (crimperGrab != null)
            crimperGrab.activated.AddListener(OnCrimperActivate);
    }

    public override void Complete()
    {
        base.Complete();

        EnableHighlight(false);

        if (crimperGrab != null)
            crimperGrab.activated.RemoveListener(OnCrimperActivate);
    }

    private void OnDestroy()
    {
        if (crimperGrab != null)
            crimperGrab.activated.RemoveListener(OnCrimperActivate);
    }

    private void Update()
    {
        if (!activated || isCrimped) return;

        if (Keyboard.current?.spaceKey.wasPressedThisFrame == true)
            TryCrimp();
    }

    private void OnCrimperActivate(ActivateEventArgs args)
    {
        TryCrimp();
    }

    private void TryCrimp()
    {
        if (!activated) return;
        if (isCrimped) return;
        if (connectorSocket == null || !connectorSocket.hasSelection) return;
        if (cableSocket == null || !cableSocket.hasSelection) return;

        Crimp();
    }

    private void Crimp()
    {
        isCrimped = true;

        if (audioSource && crimpSound)
            audioSource.PlayOneShot(crimpSound);

        if (crimperAnimator != null && !string.IsNullOrEmpty(crimpTriggerName))
            crimperAnimator.SetTrigger(crimpTriggerName);

        if (uncrimpedConnector) uncrimpedConnector.SetActive(false);
        if (crimpedConnector) crimpedConnector.SetActive(true);

        LockSocket(connectorSocket);
        LockSocket(cableSocket);

        Debug.Log("Кабель успешно обжат");

        Complete();
        TaskController.instance.NextTask();
    }

    private void LockSocket(XRSocketInteractor socket)
    {
        if (socket != null)
            socket.socketActive = false;
    }

    private void EnableHighlight(bool state)
    {
        if (cableOutline != null)
            cableOutline.enabled = state;

        if (crimperOutline != null)
            crimperOutline.enabled = state;

        if (connectorOutline != null)
            connectorOutline.enabled = state;
    }
}

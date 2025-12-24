using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class StripCableTask : Task
{
    [Header("Socket")]
    [SerializeField] private XRSocketInteractor socket;

    [Header("Crimper")]
    [SerializeField] private XRGrabInteractable crimperGrab;
    [SerializeField] private Animator crimperAnimator;
    [SerializeField] private string stripTriggerName = "Strip";

    [Header("Visuals")]
    [SerializeField] private GameObject insulatedModel;
    [SerializeField] private GameObject strippedModel;

    [Header("Highlight (Outline)")]
    [SerializeField] private Behaviour cableOutline;
    [SerializeField] private Behaviour crimperOutline;

    [Header("Sound")]
    [SerializeField] private AudioSource cutSound;

    private bool stripped;

    public override string RUDescription => "сними изоляцию с кабеля";

    public override void Terms()
    {
        base.Terms();

        stripped = false;

        insulatedModel.SetActive(true);
        strippedModel.SetActive(false);

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

    void Update()
    {
        if (!activated) return;

        if (Keyboard.current?.mKey.wasPressedThisFrame == true)
            PlayAnimationOnly();

        if (stripped) return;

        if (Keyboard.current?.spaceKey.wasPressedThisFrame == true)
            TryStrip();
    }

    private void OnCrimperActivate(ActivateEventArgs args)
    {
        TryStrip();
    }

    private void TryStrip()
    {
        if (!activated) return;
        if (stripped) return;
        if (socket == null || !socket.hasSelection) return;

        StripInsulation();
    }

    private void StripInsulation()
    {
        stripped = true;

        PlayAnimationAndSound();

        Invoke(nameof(ApplyVisualChange), 0.4f);
    }

    private void PlayAnimationAndSound()
    {
        if (crimperAnimator != null && !string.IsNullOrEmpty(stripTriggerName))
            crimperAnimator.SetTrigger(stripTriggerName);

        if (cutSound != null)
            cutSound.Play();
    }

    private void PlayAnimationOnly()
    {
        if (crimperAnimator != null && !string.IsNullOrEmpty(stripTriggerName))
        {
            crimperAnimator.SetTrigger(stripTriggerName);
            Debug.Log("Тест анимации кримпера (M)");
        }
    }

    private void ApplyVisualChange()
    {
        insulatedModel.SetActive(false);
        strippedModel.SetActive(true);

        Debug.Log("Изоляция снята");

        Complete();
        TaskController.instance.NextTask();
    }

    private void EnableHighlight(bool state)
    {
        if (cableOutline != null)
            cableOutline.enabled = state;

        if (crimperOutline != null)
            crimperOutline.enabled = state;
    }

}

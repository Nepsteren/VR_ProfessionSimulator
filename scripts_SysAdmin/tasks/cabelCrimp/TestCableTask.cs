using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class TestCableTask : Task
{
    [Header("Socket")]
    [SerializeField] private XRSocketInteractor testerSocket;

    [Header("Tester")]
    [SerializeField] private XRGrabInteractable testerGrab;

    [Header("Leds")]
    [SerializeField] private GameObject[] leftLeds;
    [SerializeField] private GameObject[] rightLeds;
    [SerializeField] private float ledDelay = 0.4f;

    [Header("Highlight (Outline)")]
    [SerializeField] private Behaviour cableOutline;
    [SerializeField] private Behaviour testerOutline;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip testSound;

    private bool tested;
    private Coroutine testCoroutine;

    public override string RUDescription => "проверь соединение кабеля тестером";
    public override string Name => "TestCable";

    public override void Terms()
    {
        base.Terms();

        tested = false;
        DisableAllLeds();
        EnableHighlight(true);

        if (testerGrab != null)
            testerGrab.activated.AddListener(OnTesterActivate);
    }

    public override void Complete()
    {
        base.Complete();

        EnableHighlight(false);
        StopTestSequence();
        DisableAllLeds();

        if (testerGrab != null)
            testerGrab.activated.RemoveListener(OnTesterActivate);
    }

    private void OnDestroy()
    {
        if (testerGrab != null)
            testerGrab.activated.RemoveListener(OnTesterActivate);
    }

    private void Update()
    {
        if (!activated) return;

        if (tested && testerSocket != null && !testerSocket.hasSelection)
        {
            Debug.Log("Кабель вынут — сброс подсветки и теста");

            StopTestSequence();
            DisableAllLeds();
            tested = false;
            EnableHighlight(true);
        }

        if (tested) return;

        if (Keyboard.current?.spaceKey.wasPressedThisFrame == true)
            TryTest();
    }

    private void OnTesterActivate(ActivateEventArgs args)
    {
        TryTest();
    }

    private void TryTest()
    {
        if (!activated) return;
        if (tested) return;
        if (testerSocket == null || !testerSocket.hasSelection) return;

        TestCable();
    }

    private void TestCable()
    {
        tested = true;

        EnableHighlight(false);

        if (audioSource && testSound)
            audioSource.PlayOneShot(testSound);

        StartTestSequence();
    }

    private void StartTestSequence()
    {
        StopTestSequence();
        DisableAllLeds();
        testCoroutine = StartCoroutine(TestSequence());
    }

    private IEnumerator TestSequence()
    {
        yield return new WaitForSeconds(2.0f);

        int count = Mathf.Min(leftLeds.Length, rightLeds.Length);

        for (int i = 0; i < count; i++)
        {
            leftLeds[i]?.SetActive(true);
            rightLeds[i]?.SetActive(true);

            yield return new WaitForSeconds(ledDelay);
        }

        Debug.Log("Кабель успешно проверен");

        Complete();
        TaskController.instance.NextTask();
    }

    private void StopTestSequence()
    {
        if (testCoroutine != null)
        {
            StopCoroutine(testCoroutine);
            testCoroutine = null;
        }
    }

    private void DisableAllLeds()
    {
        foreach (var led in leftLeds)
            if (led) led.SetActive(false);

        foreach (var led in rightLeds)
            if (led) led.SetActive(false);
    }

    private void EnableHighlight(bool state)
    {
        if (cableOutline != null)
            cableOutline.enabled = state;

        if (testerOutline != null)
            testerOutline.enabled = state;
    }
}

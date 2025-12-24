using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class ActivateOnMotherboardInstall : MonoBehaviour
{
    [Header("ОСНОВНЫЕ НАСТРОЙКИ")]
    public XRSocketInteractor motherboardSocket;
    public GameObject wireMouseObject;

    [Header("АНИМАЦИЯ ПОЯВЛЕНИЯ")]
    public float appearAnimationTime = 1.0f;
    public AnimationCurve scaleCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public bool useFadeEffect = true;

    [Header("ЗВУКИ")]
    public AudioClip appearSound;
    public AudioClip disappearSound;
    [Range(0, 1)] public float volume = 0.7f;

    [Header("НАСТРОЙКИ ПОВЕДЕНИЯ")]
    public bool hideOnRemoval = true;
    public bool disableInteractionDuringAnimation = true;

    private AudioSource audioSource;
    private Vector3 originalScale;
    private Material wireMaterial;
    private Color originalColor;

    void Start()
    {
        if (motherboardSocket == null)
        {
            Debug.LogError("Не назначен motherboardSocket!");
            enabled = false;
            return;
        }

        if (wireMouseObject == null)
        {
            Debug.LogError("Не назначен wireMouseObject!");
            enabled = false;
            return;
        }

        originalScale = wireMouseObject.transform.localScale;

        if (useFadeEffect)
        {
            Renderer renderer = wireMouseObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                wireMaterial = renderer.material;
                originalColor = wireMaterial.color;
            }
        }

        if (appearSound != null || disappearSound != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.spatialBlend = 1.0f;
            audioSource.volume = volume;
        }

        motherboardSocket.selectEntered.AddListener(OnMotherboardInstalled);

        if (hideOnRemoval)
        {
            motherboardSocket.selectExited.AddListener(OnMotherboardRemoved);
        }

        InitializeWire();
    }

    void InitializeWire()
    {
        if (wireMouseObject == null) return;

        wireMouseObject.SetActive(false);

        if (useFadeEffect && wireMaterial != null)
        {
            wireMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        }

        wireMouseObject.transform.localScale = Vector3.zero;
    }

    void OnMotherboardInstalled(SelectEnterEventArgs args)
    {
        StartCoroutine(ShowWireAnimation());
    }

    void OnMotherboardRemoved(SelectExitEventArgs args)
    {
        StartCoroutine(HideWireAnimation());
    }

    IEnumerator ShowWireAnimation()
    {
        wireMouseObject.SetActive(true);

        if (appearSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(appearSound);
        }

        Debug.Log("Начинаем анимацию появления провода...");

        float elapsedTime = 0f;

        while (elapsedTime < appearAnimationTime)
        {
            float progress = elapsedTime / appearAnimationTime;
            float curveValue = scaleCurve.Evaluate(progress);

            wireMouseObject.transform.localScale = originalScale * curveValue;

            if (useFadeEffect && wireMaterial != null)
            {
                float alpha = Mathf.Lerp(0, originalColor.a, curveValue);
                wireMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        wireMouseObject.transform.localScale = originalScale;
        if (useFadeEffect && wireMaterial != null)
        {
            wireMaterial.color = originalColor;
        }

        Debug.Log("Провод для мыши полностью показан");
    }

    IEnumerator HideWireAnimation()
    {
        if (!wireMouseObject.activeSelf) yield break;

        Debug.Log("Начинаем анимацию исчезновения провода...");

        if (disappearSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(disappearSound);
        }

        float elapsedTime = 0f;
        Vector3 startScale = wireMouseObject.transform.localScale;
        Color startColor = wireMaterial != null ? wireMaterial.color : originalColor;

        while (elapsedTime < appearAnimationTime)
        {
            float progress = elapsedTime / appearAnimationTime;
            float curveValue = scaleCurve.Evaluate(1 - progress); 

            wireMouseObject.transform.localScale = originalScale * curveValue;

            if (useFadeEffect && wireMaterial != null)
            {
                float alpha = Mathf.Lerp(0, startColor.a, curveValue);
                wireMaterial.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        wireMouseObject.SetActive(false);

        Debug.Log("Провод для мыши скрыт");
    }

    public void ShowWire()
    {
        StartCoroutine(ShowWireAnimation());
    }

    public void HideWire()
    {
        StartCoroutine(HideWireAnimation());
    }

    void OnValidate()
    {
        if (scaleCurve == null || scaleCurve.keys.Length == 0)
        {
            scaleCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        }
    }
}
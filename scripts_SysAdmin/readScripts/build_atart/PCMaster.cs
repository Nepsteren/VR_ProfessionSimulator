using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;
using System.Collections;

public class PCMaster : MonoBehaviour
{
    [System.Serializable]
    public class PCComponent
    {
        public string componentName;
        public XRSocketInteractor socket;
        public string requiredTag;
        public AudioClip installSound;
        public AudioClip removeSound;
        public bool isInstalled = false;
        public GameObject installedObject;
    }

    public List<PCComponent> components = new List<PCComponent>();
    public bool enforceSequence = true;
    private int currentStep = 0;

    public AudioClip errorSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.spatialBlend = 1f;
            audioSource.volume = 0.7f;
        }

        InitializeSockets();
    }

    void InitializeSockets()
    {
        for (int i = 0; i < components.Count; i++)
        {
            PCComponent component = components[i];

            if (component.socket != null)
            {
                component.socket.showInteractableHoverMeshes = false;

                int index = i;
                component.socket.selectEntered.AddListener((args) => OnComponentInstalled(index, args));
                component.socket.selectExited.AddListener((args) => OnComponentRemoved(index, args));

                if (enforceSequence)
                {
                    component.socket.socketActive = (i == 0);
                }
            }
        }
    }

    void OnComponentInstalled(int componentIndex, SelectEnterEventArgs args)
    {
        PCComponent component = components[componentIndex];

        if (!CanInstallComponent(componentIndex))
        {
            StartCoroutine(RejectInstallation(args.interactableObject));
            PlaySound(errorSound);
            return;
        }

        GameObject installedObj = args.interactableObject.transform.gameObject;
        if (!string.IsNullOrEmpty(component.requiredTag) && !installedObj.CompareTag(component.requiredTag))
        {
            StartCoroutine(RejectInstallation(args.interactableObject));
            PlaySound(errorSound);
            return;
        }

        component.isInstalled = true;
        component.installedObject = installedObj;
        currentStep++;

        PlaySound(component.installSound);

        Renderer renderer = installedObj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = GetComponentColor(component.componentName);
        }

        if (enforceSequence && componentIndex + 1 < components.Count)
        {
            components[componentIndex + 1].socket.socketActive = true;
        }
    }

    void OnComponentRemoved(int componentIndex, SelectExitEventArgs args)
    {
        PCComponent component = components[componentIndex];

        component.isInstalled = false;
        component.installedObject = null;
        currentStep--;

        PlaySound(component.removeSound);

        if (enforceSequence)
        {
            for (int i = componentIndex + 1; i < components.Count; i++)
            {
                components[i].socket.socketActive = false;
            }
        }
    }

    bool CanInstallComponent(int componentIndex)
    {
        if (!enforceSequence) return true;

        for (int i = 0; i < componentIndex; i++)
        {
            if (!components[i].isInstalled)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator RejectInstallation(IXRSelectInteractable interactable)
    {
        var socket = interactable.firstInteractorSelecting as XRSocketInteractor;
        if (socket != null)
        {
            socket.socketActive = false;
            yield return new WaitForSeconds(0.5f);
            socket.socketActive = true;
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    Color GetComponentColor(string componentName)
    {
        switch (componentName.ToLower())
        {
            case "motherboard": return Color.green;
            case "cpu": return Color.blue;
            case "cpu cover": return Color.gray;
            case "cooler": return Color.cyan;
            case "ram": return Color.magenta;
            case "psu": return Color.yellow;
            case "psu cover": return Color.black;
            default: return Color.white;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < components.Count; i++)
            {
                string status = components[i].isInstalled ? "yes" : "no";
                string active = components[i].socket != null ?
                    $" (active: {components[i].socket.socketActive})" : "";
            }
        }
    }
}
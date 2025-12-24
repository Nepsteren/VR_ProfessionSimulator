using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ForceHoldInteractable : MonoBehaviour
{
    private XRGrabInteractable grab;

    private IXRSelectInteractor lastInteractor;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();

        grab.selectEntered.AddListener(OnSelectEntered);
        grab.selectExited.AddListener(OnSelectExited);
    }

    void OnDestroy()
    {
        grab.selectEntered.RemoveListener(OnSelectEntered);
        grab.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        lastInteractor = args.interactorObject;
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        // Принудительно возвращаем объект в руку
        if (lastInteractor != null)
        {
            grab.interactionManager.SelectEnter(
                lastInteractor,
                grab
            );
        }
    }
}

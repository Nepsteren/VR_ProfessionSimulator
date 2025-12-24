using System.Collections;
using UnityEngine;

public class RemoveComponentPerFrame : MonoBehaviour
{
    [SerializeField] private Component[] componentRemovable;

    private void Start()
    {
        StartCoroutine(Waiter());
    }

    IEnumerator Waiter()
    {
        yield return new WaitForEndOfFrame();

        foreach (Component comp in componentRemovable)
        {
            if (comp == null)
                continue;

            if (comp is Behaviour behaviour)
            {
                behaviour.enabled = false;
            }
            else
            {
                Debug.LogWarning($"{comp.GetType().Name} нельзя отключить", comp);
            }
        }
    }
}

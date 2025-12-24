using UnityEngine;

public class PlayerZoneDetector : MonoBehaviour
{
    public AssemblyStarter assemblyStarter;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == assemblyStarter.gameObject)
        {
            Debug.Log("Игрок вошел в зону сборки");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == assemblyStarter.gameObject)
        {
            Debug.Log("Игрок вышел из зоны сборки");
        }
    }
}
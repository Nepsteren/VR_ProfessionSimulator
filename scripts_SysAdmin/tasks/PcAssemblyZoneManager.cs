using UnityEngine;

public class PcAssemblyZoneManager : MonoBehaviour
{
    public static PcAssemblyZoneManager instance;

    [SerializeField] private GameObject[] blockingWalls;

    private void Awake()
    {
        instance = this;
    }

    public void UnlockAndOpen()
    {
        foreach (var wall in blockingWalls)
            wall.SetActive(false);

        Debug.Log("Зона сборки открыта");
    }
}

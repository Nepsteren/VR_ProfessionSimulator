using UnityEngine;

public class AssemblyStarter : MonoBehaviour
{
    public PCMaster pcMaster;
    public GameObject startZoneVisual;
    public GameObject assemblyTable;
    public AudioClip startSound;
    public GameObject[] blockingWalls;

    private bool assemblyStarted;
    private AudioSource audioSource;

    private EnterCrimpZoneTask currentTask;

    [SerializeField] private ZoneType zoneType;

    public enum ZoneType
    {
        Assembly,
        Crimp
    }


    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        SetWallsActive(false);
        DisableAllAssembly();

        if (assemblyTable != null)
            assemblyTable.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (assemblyStarted) return;

        assemblyStarted = true;

        Debug.Log($"»грок вошЄл в зону: {zoneType}");

        var tc = TaskController.instance;

        if (zoneType == ZoneType.Assembly)
        {
            tc.trainingPath = TaskController.TrainingPath.StartedWithAssembly;
            tc.ChangeTaskAndSetIndex("InstallMotherboard");
        }
        else
        {
            tc.trainingPath = TaskController.TrainingPath.StartedWithCrimp;
            tc.ChangeTaskAndSetIndex("StartCrimp");
        }

        StartAssembly();
    }


    public void EnableStartTrigger(EnterCrimpZoneTask task)
    {
        currentTask = task;
        GetComponent<Collider>().enabled = true;

        if (startZoneVisual != null)
            startZoneVisual.SetActive(true);
    }

    public void DisableStartTrigger()
    {
        GetComponent<Collider>().enabled = false;
    }

    private void StartAssembly()
    {
        assemblyStarted = true;

        if (startSound != null)
            audioSource.PlayOneShot(startSound);

        SetWallsActive(true);
        EnableAssembly();

        if (assemblyTable != null)
            assemblyTable.SetActive(true);

        if (startZoneVisual != null)
            startZoneVisual.SetActive(false);
    }

    private void SetWallsActive(bool active)
    {
        foreach (var wall in blockingWalls)
            if (wall != null)
                wall.SetActive(active);
    }

    private void EnableAssembly()
    {
        if (pcMaster == null) return;

        foreach (var component in pcMaster.components)
            if (component.socket != null)
                component.socket.socketActive = true;
    }

    private void DisableAllAssembly()
    {
        if (pcMaster == null) return;

        foreach (var component in pcMaster.components)
            if (component.socket != null)
                component.socket.socketActive = false;
    }

    public void UnlockAndHideZone()
    {
        SetWallsActive(false);

        if (startZoneVisual != null)
            startZoneVisual.SetActive(false);
    }

    public void StartAssemblyExternally()
    {
        if (assemblyStarted) return;
        StartAssembly();
    }

    public void OpenWalls()
    {
        SetWallsActive(false);
    }

}

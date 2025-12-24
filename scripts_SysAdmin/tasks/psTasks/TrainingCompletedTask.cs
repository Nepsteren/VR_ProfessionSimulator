using UnityEngine;

public class TrainingCompletedTask : Task
{
    [Header("Final UI")]
    [SerializeField] private GameObject finalCanvas;

    [Header("Optional")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip successSound;

    public override string RUDescription => "все задания успешно освоенны";
    public override string Name => "TrainingCompleted";

    public override void Terms()
    {
        base.Terms();

        if (finalCanvas != null)
            finalCanvas.SetActive(true);

        if (audioSource && successSound)
            audioSource.PlayOneShot(successSound);

        Debug.Log("Обучение завершено: профессия освоена");
    }

    public override void Complete()
    {
        base.Complete();
    }
}

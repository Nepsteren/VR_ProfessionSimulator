using UnityEngine;

public class CompleteCurrentTaskButton : MonoBehaviour
{
    public void CompleteTask()
    {
        Task current = TaskController.instance.ActivityTask;
        if (current != null)
            current.Complete();
    }
}

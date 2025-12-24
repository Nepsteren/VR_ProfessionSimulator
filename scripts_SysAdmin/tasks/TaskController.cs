using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public static TaskController instance;
    public Task ActivityTask;
    public List<Task> Tasks = new List<Task>();
    private int activityTaskNumber = -1;

    public enum TrainingStartMode
    {
        FullTraining,    
        PcAssemblyOnly    
    }

    public enum TrainingPath
    {
        None,
        StartedWithAssembly,
        StartedWithCrimp
    }


    public TrainingStartMode startMode = TrainingStartMode.FullTraining;

    public TrainingPath trainingPath = TrainingPath.None;




    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        NextTask();

    }
    //Смена задания
    public void NextTask()
    {
        activityTaskNumber++;
        ActivityTask = Tasks[activityTaskNumber];
        print(activityTaskNumber);
        UIController.instance.ChangeTaskText();
        Tasks[activityTaskNumber].Terms();
        //foreach (var task in Tasks)
        //{
            
        //    if (task.Name == taskName)
        //    {
        //        ActivityTask = task;
        //        //UIController.instance.TaskText();
        //        ActivityTask.Terms();
        //    }
        //}
    }
    //Смена задания
    public void ChangeTask(string taskName)
    {
        if (ActivityTask != null)
        {
            ActivityTask.Complete();
        }

        foreach (var task in Tasks)
        {
            if (task.Name == taskName)
            {
                ActivityTask = task;
                ActivityTask.Terms();

                UIController.instance.ChangeTaskText();

                return;
            }
        }

        Debug.LogError($"Task с именем {taskName} не найден");
    }

    public void ChangeTaskAndSetIndex(string taskName)
    {
        if (ActivityTask != null)
            ActivityTask.Complete();

        for (int i = 0; i < Tasks.Count; i++)
        {
            if (Tasks[i].Name == taskName)
            {
                ActivityTask = Tasks[i];
                activityTaskNumber = i; 
                ActivityTask.Terms();

                UIController.instance.ChangeTaskText();
                return;
            }
        }

        Debug.LogError($"Task {taskName} не найден");
    }



    //Получение задания по названию
    public Task GetTask(string taskName)
    {
        foreach (var task in Tasks)
        {
            if (task.Name == taskName)
            {
                return task;
            }
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public static TaskController instance;
    public Task ActivityTask;
    public List<Task> Tasks = new List<Task>();
    private int activityTaskNumber = -1;


    //Инициализация контроллера
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
        foreach (var task in Tasks)
        {
            if (task.Name == taskName)
            {
                ActivityTask = task;
                //UIController.instance.TaskText();
                ActivityTask.Terms();
            }
        }
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

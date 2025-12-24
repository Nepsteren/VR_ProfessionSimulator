using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController2 : MonoBehaviour
{
    public static TaskController2 instance;
    public Task2 ActivityTask;
    public List<Task2> Tasks = new List<Task2>();
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

        //activityTaskNumber++;
        //ActivityTask = Tasks[activityTaskNumber];
        //print(activityTaskNumber);
        //UIController.instance.ChangeTaskText();
        //if(activityTaskNumber > 0)
        //    Tasks[activityTaskNumber-1].ChangeOutline(false);
        //Tasks[activityTaskNumber].Terms();
        StartCoroutine(ChangeTaskAsync());
        
    }
    private IEnumerator ChangeTaskAsync()
    {
        if (activityTaskNumber != -1)
        {
            UIController2.instance._completedEllipse.SetActive(true);
            yield return new WaitForSeconds(2.5f);
            UIController2.instance._completedEllipse.SetActive(false);
        }
            activityTaskNumber++;
            ActivityTask = Tasks[activityTaskNumber];
            print(activityTaskNumber);
            UIController2.instance.ChangeTaskText();
            if (activityTaskNumber > 0)
                Tasks[activityTaskNumber - 1].ChangeOutline(false);
            Tasks[activityTaskNumber].Terms();
        
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
    public Task2 GetTask(string taskName)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    private TaskAnim anim;
    private void Awake()
    {
        anim = FindFirstObjectByType<TaskAnim>();
    }
    public virtual bool activated { get; set; }
    public virtual string RUDescription { get; set; }

    public virtual string ENDescription
    {
        get; set;
    }
    public virtual string Name { get; set; }



    //public virtual void Complete(string name)
    //{
    //    activated = false;
    //    TaskController.taskController.ChangeTask(name);
    //    MainMenu.instance.CompletedTasks[TaskController.taskController.Tasks.IndexOf(this)].gameObject.SetActive(true);
    //}

    public virtual void Terms()
    {
        activated = true;
    }
    public void FinishTask()
    {        
        activated = false;
        anim.SwitchImage();
    }
}

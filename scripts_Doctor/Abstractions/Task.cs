using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2 : MonoBehaviour
{
    
    public virtual bool activated { get; set; }
    public virtual string RUDescription { get; set; }

    public virtual string ENDescription
    {
        get; set;
    }
    public virtual string Name { get; set; }
    [SerializeField]
    public List<Outline> _interactableObjects = new List<Outline>();


    public virtual void ChangeOutline(bool active)
    {
        // 1. Проверяем, существует ли сам список
        if (_interactableObjects == null) return;

        if (_interactableObjects.Count > 0)
        {
            foreach (var obj in _interactableObjects)
            {
                // 2. ВОТ ЭТА ПРОВЕРКА НУЖНА (добавляем её перед 28 строкой)
                if (obj != null)
                {
                    try
                    {
                        obj.enabled = active;
                    }
                    catch (System.Exception) // Используем общий Exception для надежности
                    {
                        continue;
                    }
                }
            }
        }
    }

    //public virtual void Complete(string name)
    //{
    //    activated = false;
    //    TaskController.taskController.ChangeTask(name);
    //    MainMenu.instance.CompletedTasks[TaskController.taskController.Tasks.IndexOf(this)].gameObject.SetActive(true);
    //}

    public virtual void Terms()
    {
        ChangeOutline(true);
        activated = true;
    }
}

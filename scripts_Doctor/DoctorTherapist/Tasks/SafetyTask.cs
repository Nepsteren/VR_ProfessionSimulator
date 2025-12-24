using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyTask : Task2
{
    [SerializeField] private GameObject _locomotionSystem;


    public override string RUDescription { get => "Ознакомиться с техникой безопасности"; set { } }
    public override string ENDescription { get => "Pack electronics and documents in a bag (telephone, laptop, camera, passport)"; }
    public override string Name { get => DoctorTherapistTasksNames.ThroatExamination.ToString(); }


    public void CompleteTask()
    {
        _locomotionSystem.SetActive(true);
        TaskController2.instance.NextTask();
    }
    //Условия выполнения задания
    public override void Terms()
    {       
        base.Terms();
    }
}

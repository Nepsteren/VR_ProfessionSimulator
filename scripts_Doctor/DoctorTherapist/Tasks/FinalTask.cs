using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTask : Task2
{
    [SerializeField] private GameObject _finalCanvas, _activityTask;
    [SerializeField] private GameObject _locomotionSystem,_leftcontroller,_rightController;

    public override string RUDescription { get => ""; set { } }
    public override string ENDescription { get => "Pack electronics and documents in a bag (telephone, laptop, camera, passport)"; }
    public override string Name { get => DoctorTherapistTasksNames.TemperatureMeasurement.ToString(); }

    public override void ChangeOutline(bool active)
    {
        base.ChangeOutline(active);
    }
    

    //Условия выполнения задания
    public override void Terms()
    {
        _finalCanvas.SetActive(true);
        _activityTask.SetActive(false);
        _locomotionSystem.SetActive(false);
        _rightController.SetActive(false);
        _leftcontroller.SetActive(false);
        base.Terms();
    }
}

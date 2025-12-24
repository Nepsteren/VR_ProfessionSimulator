using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientExaminationTask : Task2
{
    [SerializeField] private GameObject _thermometerTrigger,_tonometrTrigger;
    [SerializeField] private NPC _npc;
    //[SerializeField] private Tonometr _tonometr;
    private static int completedMissions = 0;
    public override string RUDescription { get => "Провести осмотр пациента(измерить температуру и давление)"; set { } }
    public override string ENDescription { get => "Pack electronics and documents in a bag (telephone, laptop, camera, passport)"; }
    public override string Name { get => DoctorTherapistTasksNames.TemperatureMeasurement.ToString(); }
    private void Start()
    {
        completedMissions = 0;
    }
    public override void ChangeOutline(bool active)
    {
        base.ChangeOutline(active);
    }
    public static void CompleteMission()
    {
        completedMissions++;
        if (completedMissions == 2 && Tonometr._torusOnHand==false){
            TaskController2.instance.NextTask();
        }
            
    }
    public void CheckComplete()
    {
        if (completedMissions == 2 && Tonometr._torusOnHand == false)
        {
            TaskController2.instance.NextTask();
        }
    }
    //Условия выполнения задания
    public override void Terms()
    {
        _npc.SittingSlowAnimation();
        _thermometerTrigger.SetActive(true);
        _tonometrTrigger.SetActive(true);
        base.Terms();
    }
}

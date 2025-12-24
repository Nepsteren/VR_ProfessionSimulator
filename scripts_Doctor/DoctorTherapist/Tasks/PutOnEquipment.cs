using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOnEquipment : Task2
{
    
    public override string RUDescription { get => "Надеть маску и перчатки"; set { } }
    static int completedMissions;
    public override string ENDescription { get => "Pack electronics and documents in a bag (telephone, laptop, camera, passport)"; }
    public override string Name { get => DoctorTherapistTasksNames.ReferralForTests.ToString(); }
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
        if(completedMissions == 2)
            TaskController2.instance.NextTask();
    }
    //Условия выполнения задания
    public override void Terms()
    {     
        base.Terms();
    }
}

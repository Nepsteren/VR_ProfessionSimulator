using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTreatment : Task2
{
    [SerializeField] private GameObject _antiseptikTrigger;
    public override string RUDescription { get => "Обработать руки антисептиком"; set { } }
    public override string ENDescription { get => "Pack electronics and documents in a bag (telephone, laptop, camera, passport)"; }
    public override string Name { get => DoctorTherapistTasksNames.ReferralForTests.ToString(); }
    


    public override void ChangeOutline(bool active)
    {
        base.ChangeOutline(active);       
    }
    //Условия выполнения задания
    public override void Terms()
    {
        Debug.Log("HandTreatment Terms");
        _antiseptikTrigger.SetActive(true);
        base.Terms();
    }
}

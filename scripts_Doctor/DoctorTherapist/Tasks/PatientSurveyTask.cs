using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSurveyTask : Task2
{
    [SerializeField] private GameObject _questions;
    [SerializeField] private GameObject originalNpc, throatNpc;
    public override string RUDescription { get => "Опросить пациента"; set { } }
    public override string ENDescription { get => "Pack electronics and documents in a bag (telephone, laptop, camera, passport)"; }
    public override string Name { get => DoctorTherapistTasksNames.PatientSurvey.ToString(); }


    public override void ChangeOutline(bool active)
    {
        base.ChangeOutline(active);
    }
    //Условия выполнения задания
    public override void Terms()
    {
        PlayerPanel2.onlyEnable = true;
        originalNpc.SetActive(true);
        throatNpc.SetActive(false);
        _questions.SetActive(true);
        base.Terms();
    }
}

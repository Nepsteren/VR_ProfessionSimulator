using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferralForTestsTask : Task2
{
    [SerializeField] private GameObject _tests;
    public override string RUDescription { get => "Выписать направление на анализы"; set { } }
    public override string ENDescription { get => "Pack electronics and documents in a bag (telephone, laptop, camera, passport)"; }
    public override string Name { get => DoctorTherapistTasksNames.ReferralForTests.ToString(); }

    public override void ChangeOutline(bool active)
    {
        base.ChangeOutline(active);
    }

    //Условия выполнения задания
    public override void Terms()
    {
        _tests.SetActive(true);
        base.Terms();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinTask : Task2
{
    [SerializeField] private GameObject _binTrigger,_mouthNpc,_originalNpc;
    public override string RUDescription { get => "Выкинуть шпатель в мусорку"; set { } }
    public override string ENDescription { get => "Pack electronics and documents in a bag (telephone, laptop, camera, passport)"; }
    public override string Name { get => DoctorTherapistTasksNames.ReferralForTests.ToString(); }

    public override void ChangeOutline(bool active)
    {
        base.ChangeOutline(active);
    }
    public void ChangeNpc()
    {
        _originalNpc.SetActive(true);
        _mouthNpc.SetActive(false);
    }
    //Условия выполнения задания
    public override void Terms()
    {
        _binTrigger.SetActive(true);
        base.Terms();
    }
}

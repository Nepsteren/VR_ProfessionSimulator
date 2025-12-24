using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferralToSpecialistTask : Task2
{
    public GameObject referalSpecialists;
    public override string RUDescription { get => "Выписать направление к врачам"; set { } }
    public override string ENDescription { get => "Pack electronics and documents in a bag (telephone, laptop, camera, passport)"; }
    public override string Name { get => DoctorTherapistTasksNames.ReferralToSpecialist.ToString(); }

    public override void ChangeOutline(bool active)
    {
        base.ChangeOutline(active);
    }

    //Условия выполнения задания
    public override void Terms()
    {
        referalSpecialists.SetActive(true);
        base.Terms();
    }
}

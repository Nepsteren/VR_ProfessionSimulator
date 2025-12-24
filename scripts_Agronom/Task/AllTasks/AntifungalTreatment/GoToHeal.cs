using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHeal : Task
{
    public GameObject attachPoint;
    public override string RUDescription { get => "Пройди в место для обработки пшеницы"; set { } }
    public override string ENDescription { get => "Process the wheat"; }
    public override string Name { get => "GoToHeal"; }

    public override void Terms()
    {
        attachPoint.SetActive(true);
        base.Terms();
    }
}

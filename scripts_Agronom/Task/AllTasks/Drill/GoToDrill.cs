using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToDrill : Task
{
    [SerializeField] GameObject attachPoint;
    public override string RUDescription { get => "Пройди в подсвеченную область для проведения анализа почвы"; set { } }
    public override string ENDescription { get => "Proceed to the highlighted area to conduct a soil analysis"; }
    public override string Name { get => "GoToDrill"; }

    public override void Terms()
    {
        attachPoint.SetActive(true);
        base.Terms();
    }
}

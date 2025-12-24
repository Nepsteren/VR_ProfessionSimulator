using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToInspectZone : Task
{
    [SerializeField] GameObject _attachPoint;
    public override string RUDescription { get => "Пройди в подсвеченную область для осмотра пшеницы"; set { } }
    public override string ENDescription { get => "Go to the highlighted area to inspect the wheat"; }
    public override string Name { get => "GoToInspectZone"; }

    public override void Terms()
    {
        _attachPoint.SetActive(true);
        base.Terms();
    }
}

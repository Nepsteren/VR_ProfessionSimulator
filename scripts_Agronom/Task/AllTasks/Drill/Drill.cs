using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : Task
{
    [SerializeField] GameObject _drillPrefab;
    public override string RUDescription { get => "Пробурить отверстие в земле"; set { } }
    public override string ENDescription { get => "Drill a hole in the ground"; }
    public override string Name { get => "Drill"; }

    public override void Terms()
    {
        _drillPrefab.SetActive(true);
        _drillPrefab.GetComponent<Outline>().enabled = true;
        base.Terms();
    }
    public void EndDrill()
    {
        _drillPrefab.SetActive(false);
        FinishTask();
    }
}

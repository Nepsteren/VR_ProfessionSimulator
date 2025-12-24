using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigPlants : Task
{
    [SerializeField] GameObject shovel;
    [SerializeField] GameObject _cilinder;
    public override string RUDescription { get => "Аккуратно подкопайте растение справа с помощью лопаты"; set { } }
    public override string ENDescription { get => "Carefully dig up the plant on the right side using a shovel"; }
    public override string Name { get => "DigPlants"; }

    public override void Terms()
    {
        shovel.SetActive(true);
        _cilinder.SetActive(true);
        base.Terms();
    }
    public void EndDigging()
    {
        _cilinder.SetActive(false);
        FinishTask();
    }
}

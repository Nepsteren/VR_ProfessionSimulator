using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChoise : Task
{
    [SerializeField] Canvas choiseCanvas;
    public override string RUDescription { get => "Повернуть левую руку ладонью вверх и сделать выбор"; set { } }
    public override string ENDescription { get => "Turn your left hand palm up and make a selection"; }
    public override string Name { get => "MakeChoise"; }
    public override void Terms()
    {
        choiseCanvas.enabled = true;
        base.Terms();
    }

    public void FirstButtonClick()
    {
        Debug.Log("Растениям будет не достаточно просто полива");
    }
    public void SecondButtonClick()
    {
        Debug.Log("Растениям будет не достаточно обработки от грибка");
    }
    public void ThirdButtonClick() {
        Debug.Log("Выбор сделан правильно");
        choiseCanvas.enabled = false;
        FinishTask();
    }
}

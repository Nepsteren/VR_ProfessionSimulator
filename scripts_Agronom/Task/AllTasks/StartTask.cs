using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StartTask : Task
{
    [SerializeField] GameObject _canv;
    public override string RUDescription { get => "Прочитайте инструктаж и нажмите на кнопку"; set { } }
    public override string ENDescription { get => "Start"; }
    public override string Name { get => "StartTask"; }

    public override void Terms()
    {
        _canv.SetActive(true);
        base.Terms();
    }
    public void EndTutor()
    {
        _canv.SetActive(false);
        FinishTask();
    }
}

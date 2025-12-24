using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : Task
{
    [SerializeField] GameObject _taskMenu;
    [SerializeField] GameObject _endCanvas;
    public override string RUDescription { get => "все"; set { } }
    public override string ENDescription { get => "end"; }
    public override string Name { get => "EndGame"; }
    public override void Terms()
    {
        _taskMenu.SetActive(false);
        _endCanvas.SetActive(true);
        base.Terms();
    }
}

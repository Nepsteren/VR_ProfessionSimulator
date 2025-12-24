using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TakeColosInEarth : Task
{
    [SerializeField] GameObject _colosWithRoots;
    private bool _isFirst;
    public override string RUDescription { get => "Извлеките растение из земли"; set { } }
    public override string ENDescription { get => "Remove the plant from the ground"; }
    public override string Name { get => "TakeColosInEarth"; }

    public override void Terms()
    {
        _isFirst = true;
        _colosWithRoots.GetComponent<BoxCollider>().enabled = true;
        _colosWithRoots.GetComponent<Outline>().enabled = true;
        base.Terms();
    }
    public void FinishTaking()
    {
        if (_isFirst)
        {
            _isFirst = false;
            _colosWithRoots.GetComponent<Outline>().enabled = false;
            FinishTask();
        }

        
    }
}

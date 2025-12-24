using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeInstrument : Task
{
    [SerializeField] GameObject[] _instrument;
    public override string RUDescription { get => "Взять инструменты из машины"; set { } }
    public override string ENDescription { get => "Take the tools from the car"; }
    public override string Name { get => "TakeInstrument"; }
    // Start is called before the first frame update
    public override void Terms()
    {
        foreach (var instrument in _instrument)
        {
            instrument.GetComponent<BoxCollider>().enabled = true;
            instrument.GetComponent<Outline>().enabled = true;
        }
        base.Terms();
    }

    public void EndTakingInstrument()
    {
        foreach (var instrument in _instrument)
        {
            instrument.GetComponent<BoxCollider>().enabled = false;
            instrument.GetComponent<Outline>().enabled = false;
        }
        FinishTask();
    }
}

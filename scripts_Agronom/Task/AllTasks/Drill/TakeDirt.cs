using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDirt : Task
{
    [SerializeField] GameObject[] _earthPart;
    public override string RUDescription { get => "Проверьте образец земли на сухость"; set { } }
    public override string ENDescription { get => "Pick up a soil sample"; }
    public override string Name { get => "TakeDirt"; }

    public override void Terms()
    {
        foreach (var part in _earthPart) {
            part.GetComponent<Outline>().enabled = true;
        }
        base.Terms();
    }
    public void EndTaking()
    {
        foreach (var part in _earthPart) {
            part.SetActive(false);
            part.GetComponent<Outline>().enabled = false;
        }
        FinishTask();
    }
}

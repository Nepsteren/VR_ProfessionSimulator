using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Venomancer : Task
{
    [SerializeField] BoxCollider _ven;
    [SerializeField] GameObject _vh;
    public override string RUDescription { get => "Обработать поле фургицидом"; set { } }
    public override string ENDescription { get => "Treat the field with a formic acid"; }
    public override string Name { get => "Venomancer"; }
    public override void Terms()
    {
        _ven.enabled = true;
        _vh.SetActive(true);
        _vh.GetComponent<Outline>().enabled = true;
        base.Terms();
    }
    public void EndVenoms()
    {
        _ven.enabled = false;
        _vh.SetActive(false);
        _vh.GetComponent <Outline>().enabled = false;
        FinishTask();
    }
}

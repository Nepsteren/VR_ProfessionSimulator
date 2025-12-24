using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRespirator : Task
{
    [SerializeField] BoxCollider _colliderRespirator;
    [SerializeField] GameObject _respiratorOnFace;
    public override string RUDescription { get => "Надеть респиратор"; set { } }
    public override string ENDescription { get => "Put on respirator"; }
    public override string Name { get => "AddRespirator"; }
    public override void Terms()
    {
        _colliderRespirator.enabled = true;
        _colliderRespirator.gameObject.GetComponent<Outline>().enabled = true;
        base.Terms();
    }
    public void PutRespirator()
    {
        _respiratorOnFace.SetActive(true);
        _colliderRespirator.gameObject.GetComponent<Outline>().enabled = false;
        FinishTask();
    }
}

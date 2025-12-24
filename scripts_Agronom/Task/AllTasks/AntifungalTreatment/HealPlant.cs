using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PutOnSpraybottle : Task
{
    [SerializeField] Transform lidPosition;
    [SerializeField] GameObject lid;
    [SerializeField] GameObject _rezervuar;
    [SerializeField] GameObject _rezervuarOnBody;
    [SerializeField] XRGrabInteractable interactable;

    public override string RUDescription { get => "Наденьте резевуар с ядом"; set { } }
    public override string ENDescription { get => "Put on the spray bottle"; }
    public override string Name { get => "HealPlant"; }

    public override void Terms()
    {
        lid.transform.position = lidPosition.position;
        interactable.enabled = true;
        _rezervuar.GetComponent<Outline>().enabled = true;
        lid.GetComponent<Outline>().enabled = true;
        
        base.Terms();
    }
    public void Equip()
    {
        _rezervuar.SetActive(false);
        _rezervuarOnBody.SetActive(true);
        lid.SetActive(false);
        FinishTask();
    }

}

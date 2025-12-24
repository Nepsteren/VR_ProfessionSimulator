using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AddVenom : Task
{
    [SerializeField] BoxCollider _bottleCollider;
    [SerializeField] GameObject _bottle;
    [SerializeField] GameObject _canistr;
    public override string RUDescription { get => "Налейте фургицид из канистры в распылитель"; set { } }
    public override string ENDescription { get => "Pour the fugicide from the canister into a spray bottle."; }
    public override string Name { get => "AddVenom"; }
    public override void Terms()
    {
        _bottleCollider.enabled = true;
        _bottle.SetActive(true);
        _bottle.GetComponent<XRGrabInteractable>().enabled = true;
        _bottleCollider.gameObject.transform.parent.GetComponent<Outline>().enabled = true;
        _canistr.GetComponent<Outline>().enabled = true;
        base.Terms();   
    }
    public void EndAdd()
    {
        _bottleCollider.enabled = false;
        _bottle.SetActive(false);
        _bottle.GetComponent<XRGrabInteractable>().enabled = false;
        _bottleCollider.gameObject.transform.parent.GetComponent<Outline>().enabled = false;
        _canistr.GetComponent<Outline>().enabled = false;
        FinishTask();
    }
}

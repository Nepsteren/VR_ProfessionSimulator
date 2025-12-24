using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGloves: Task
{
    
    [SerializeField] private BoxCollider glovesTrigger;
    public override string RUDescription { get => "Надеть перчатки"; set { } }
    public override string ENDescription { get => "Put on glove"; }
    public override string Name { get => "PutGlove"; }
    //Условия выполнения задания
    public override void Terms()
    {
        glovesTrigger.enabled = true;
        glovesTrigger.gameObject.GetComponent<Outline>().enabled = true;
        base.Terms();
    }
    public void OnGlovesWorn()
    {
        glovesTrigger.enabled = false;
        glovesTrigger.gameObject.GetComponent<Outline>().enabled = false;
        FinishTask();
    }
}

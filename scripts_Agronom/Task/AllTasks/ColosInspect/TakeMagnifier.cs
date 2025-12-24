using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMagnifier : Task
{
    [SerializeField] GameObject _magnifier;
    [SerializeField] GameObject _toolsBox;
    private bool _isFirst;
    private void Awake()
    {
        _isFirst = true;
    }
    public override string RUDescription { get => "Взять в руки лупу"; set { } }
    public override string ENDescription { get => "Take in hands magnifier"; }
    public override string Name { get => "TakeMagnifier"; }

    public override void Terms()
    {
        _magnifier.GetComponent<Collider>().enabled = true;
        _magnifier.GetComponent<Renderer>().enabled = true;
        _magnifier.GetComponent<Outline>().enabled = true;
        _toolsBox.SetActive(true);
        base.Terms();
    }
    public void End()
    {
        Debug.Log("Чето не канает");
        if (_isFirst)
        {
            Debug.Log("Проканало");
            _isFirst = false;
            FinishTask();            
        }
    }
}

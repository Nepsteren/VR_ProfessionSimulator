using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InspectionColos : Task
{
    public BoxCollider[] _leafInteractionCollider;
    public Transform[] _spawnPoint;
    private bool _isFirst;
    public GameObject _toolsBox;
    public GameObject _lupa;
    public override string RUDescription { get => "С помощью лупы осмотрите листья растения"; set { } }
    public override string ENDescription { get => "Examine the leaves of the plant on the left"; }
    public override string Name { get => "InspectionColos"; }

    public override void Terms()
    {
        _isFirst = true;
        _lupa.GetComponent<Outline>().enabled = true;
        _toolsBox.SetActive(true);
        foreach(var collider in _leafInteractionCollider)
        {
            collider.gameObject.GetComponent<Outline>().enabled = true;
            collider.enabled = true;
        }
        base.Terms();
    }
    public void EndInspectionLeaf()
    {
        if (LeafMagnify.isMushroomChecked && _isFirst)
        {
            _isFirst = false;
            _lupa.GetComponent<Outline>().enabled = false;
            foreach (var collider in _leafInteractionCollider)
            {
                Destroy(collider.gameObject);
            }
            FinishTask();
        }        
    }
}

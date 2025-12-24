using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakingAll : MonoBehaviour
{
    [SerializeField] TakeInstrument _takeInstrument;
    public static int countPickable;
    void Start()
    {
        countPickable = 0;
    }
    private void Update()
    {
        if (countPickable >= 3) {
            _takeInstrument.EndTakingInstrument();
            countPickable = 0;
        }
    }
    public void PickObject()
    {
        countPickable++;
    }
}

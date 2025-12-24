using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digging : MonoBehaviour
{
    private int _digCount;
    [SerializeField] DigPlants _plants;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Shovel")
        {
            _digCount++;
            Debug.Log(_digCount);
        }
    }

    private void Update()
    {
        if(_digCount >= 5)
        {
            _plants.EndDigging();
            _digCount = -999;
        }
    }
}

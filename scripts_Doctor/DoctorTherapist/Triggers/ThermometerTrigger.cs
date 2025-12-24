using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermometerTrigger : MonoBehaviour
{
    [SerializeField] private Thermometr _thermometr;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "thermometer")
        {
            _thermometr.StartMeasure();
            PatientExaminationTask.CompleteMission();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfusion : MonoBehaviour
{
    [SerializeField] GameObject particle1;
    [SerializeField] GameObject particle2;
    [SerializeField] GameObject particle3;
    [SerializeField] AddVenom _addVenom;
    private int timerTransfusion;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bottle")
        {
            particle1.SetActive(true);
            particle2.SetActive(true);
            particle3.SetActive(true);
            StartCoroutine(Timer());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "bottle")
        {
            particle1.SetActive(false);
            particle2.SetActive(false);
            particle3.SetActive(false);

            StopCoroutine(Timer());
        }
    }
    IEnumerator Timer()
    {
        while (timerTransfusion < 5)
        {
            timerTransfusion++;
            yield return new WaitForSeconds(1f);
        }
        _addVenom.EndAdd();
    }
}

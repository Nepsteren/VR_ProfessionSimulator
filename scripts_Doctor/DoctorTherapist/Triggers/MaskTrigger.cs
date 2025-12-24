using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _mask;
    private bool isActivated = false;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == _mask.tag)
    //    {
    //        PutOnEquipment.CompleteMission();
    //        Destroy(_mask);
    //        gameObject.SetActive(false);
    //    }
    //}
    public void ActivateMask()
    {
        if(!isActivated)
            PutOnEquipment.CompleteMission();

        //Destroy(_mask);
        //gameObject.SetActive(false);
    }
}

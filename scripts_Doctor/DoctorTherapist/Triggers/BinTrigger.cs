using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinTrigger : MonoBehaviour
{
    public BinTask binTask;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Shpatel")
        {
            binTask.ChangeNpc();
            TaskController2.instance.NextTask();
            Destroy(gameObject);
        }
    }
}

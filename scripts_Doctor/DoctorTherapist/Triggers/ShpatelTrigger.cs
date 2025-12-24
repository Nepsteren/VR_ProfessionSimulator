using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShpatelTrigger : MonoBehaviour
{
    [SerializeField] private NPCMouth _npcMouth;
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Shpatel")
        {
            _npcMouth = FindFirstObjectByType<NPCMouth>();
            _npcMouth.MouthClose();
            TaskController2.instance.NextTask();
            Destroy(gameObject);
        }
    }
}

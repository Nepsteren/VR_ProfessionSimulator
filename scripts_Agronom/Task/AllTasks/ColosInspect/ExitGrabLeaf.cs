using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGrabLeaf : MonoBehaviour
{
    [SerializeField] private InspectionColos inspectionColos;
    public void FinishChecker()
    {
        if (LeafMagnify.isMushroomChecked)
        {
            Debug.Log("Завершен осмотр листьев");
            inspectionColos.FinishTask();
        }
    }
}

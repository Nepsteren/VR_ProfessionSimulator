using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analyses : MonoBehaviour
{
    private int analyses = 0;
    public void AddAnalyses()
    {
        analyses++;
        if (analyses == 2)
        {
            TaskController2.instance.NextTask();
            gameObject.SetActive(false);
        }
            
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specialists : MonoBehaviour
{
    private int specialists = 0;
    
    [SerializeField] private GameObject _referal;

    public void AddAnalyses()
    {
        specialists++;
        if (specialists == 2)
        {
            TaskController2.instance.NextTask();          
            _referal.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}

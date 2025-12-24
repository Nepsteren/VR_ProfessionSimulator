using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Questions : MonoBehaviour
{
    private int readyQuestions = 0;

    
    public void AddQuestion()
    {
        readyQuestions++;
        if (readyQuestions == 3)
        {
            PlayerPanel2.onlyEnable = false;
            TaskController2.instance.NextTask();
        }
           
    }
    

}

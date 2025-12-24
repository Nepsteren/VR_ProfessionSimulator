using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMouth : MonoBehaviour
{
    
    private Animator animator;
    private bool isOpened;

    private void Start()
    {
        animator=GetComponent<Animator>();
        
    }

    public void MouthOpen()
    {
        print("Рот открыт");
        isOpened = true;
        animator.SetBool("openMouth",isOpened);
        PlayerPanel2.onlyEnable = false;
    }
    public void MouthClose()
    {
        isOpened=false;
        animator.SetBool("openMouth", isOpened);
        animator.SetBool("closeMouth", true);
    }
    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleAnim : MonoBehaviour
{
    [SerializeField] GameObject _bottleAnim;
    [SerializeField] GameObject _interactBottle;
    [SerializeField] AddVenom _task;

    public void StartAnim()
    {
        _bottleAnim.SetActive(true);
        _interactBottle.SetActive(false);
        StartCoroutine(Anim());
        
    }
    public IEnumerator Anim()
    {
        yield return new WaitForSeconds(3f);
        _bottleAnim.SetActive(false);
        _interactBottle.SetActive(true);
        _task.EndAdd();
    }
}

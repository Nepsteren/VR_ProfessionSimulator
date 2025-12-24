using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiseptikTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _leftHand, _rightHand,_particles,trigger;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Outline _ant;

    private bool leftReady,rightReady;
    private int readyHands = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == _leftHand.tag)
        {
            if (!leftReady)
            {
                audioSource.Play();
                StartCoroutine(EnableParticles());
                readyHands++;
                if (readyHands == 2)
                {
                    TaskController2.instance.NextTask();    
                    _ant.enabled = false;
                }                    
                leftReady = true;
            }
        }
        if (other.gameObject.tag == _rightHand.tag)
        {
            if (!rightReady)
            {
                audioSource.Play();
                StartCoroutine(EnableParticles());
                readyHands++;
                if (readyHands == 2)
                {
                    TaskController2.instance.NextTask(); 
                    _ant.enabled = false;
                }                    
                rightReady = true;
            }
        }
    }
    private IEnumerator EnableParticles()
    {
        _particles.SetActive(true);
        yield return new WaitForSeconds(1);
        _particles.SetActive(false);
    }

}

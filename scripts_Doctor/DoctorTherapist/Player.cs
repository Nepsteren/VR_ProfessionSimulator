using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance; 
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Talk(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}

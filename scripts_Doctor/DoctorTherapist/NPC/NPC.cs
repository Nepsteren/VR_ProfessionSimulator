using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public TextMeshProUGUI _subtitres;
    public AudioSource audioSource;
    private bool isSittingSlow;
    private bool isTalking;

    private void Start()
    {
        _animator=GetComponent<Animator>();
        audioSource=GetComponent<AudioSource>();
    }
    public void SittingSlowAnimation()
    {
        isSittingSlow = !isSittingSlow;
        _animator.SetBool("sittingSlow",isSittingSlow);
    }
    public void TalkingAnimation()
    {
        //isTalking = !isTalking;
        _animator.SetTrigger("Talk");
    }
    public void StartTalk(string text, AudioClip clip)
    {
        _subtitres.text = text;
        _subtitres.gameObject.SetActive(true);
        audioSource.clip = clip;
        audioSource.Play();
        StartCoroutine(Wait());
        _subtitres.gameObject.SetActive(false);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
    }
}

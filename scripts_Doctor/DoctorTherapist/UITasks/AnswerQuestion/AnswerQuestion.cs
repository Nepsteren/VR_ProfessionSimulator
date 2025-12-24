using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerQuestion : MonoBehaviour
{
    public AudioSource playerAudio;
    public AudioSource npcAudio;
    public AudioClip answerClip;
    public AudioClip questionClip;
    public TextMeshProUGUI answerTextUI;
    public string answerText;
    private bool isSpeaking = false;
    public NPC _npc;
    private void Start()
    {
        print($"{questionClip.name} длина {questionClip.length}");
    }
    public void StartSpeak()
    {
        if(isSpeaking is false)
            StartCoroutine(Speak());
    }

    private IEnumerator Speak()
    {
        _npc=FindFirstObjectByType<NPC>();
        isSpeaking = true;
        playerAudio.clip = questionClip;
        playerAudio.Play();
        yield return new WaitForSeconds(questionClip.length);
        _npc.TalkingAnimation();
        answerTextUI.text = answerText;
        answerTextUI.gameObject.transform.parent.gameObject.SetActive(true);
        npcAudio.clip = answerClip;
        npcAudio.Play();
        yield return new WaitForSeconds(2f);
        //answerTextUI.gameObject.SetActive(false);
        answerTextUI.gameObject.transform.parent.gameObject.SetActive(false);
        _npc.TalkingAnimation();
        isSpeaking = false;
        FindFirstObjectByType<Questions>().AddQuestion();
        Destroy(gameObject);

    }
}

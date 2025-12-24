using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Question : MonoBehaviour
{
    public AudioClip question;
    public AudioClip answer;
    public UnityEvent next;
    [SerializeField] private string answerText;

    [SerializeField] private NPC _npc;
    
    public void TalkingQuestion()
    {
        Player.instance.Talk(question);
        StartCoroutine(StartNextAction());
    }
    
    public void StartTalkingQuestionAndAnswer()
    {
        StartCoroutine(TalkingQuestionAndAnswer());
        print("вопрос ответ запущен");
    }
    private IEnumerator StartNextAction()
    {
        yield return new WaitForSeconds(question.length);
        next?.Invoke();
        
    }
    private IEnumerator TalkingQuestionAndAnswer()
    {
       
        Player.instance.Talk(question);
        yield return new WaitForSeconds(question.length);
        print("говорит ответ");
        //_npc.audioSource.clip = answer;
        //_npc.audioSource.Play();
        //_npc._subtitres.text = answerText;
        //_npc._subtitres.gameObject.SetActive(true);
        //yield return new WaitForSeconds(answer.length);
        //_npc._subtitres.gameObject.SetActive(false);
        _npc.StartTalk(answerText, answer);
    }
}

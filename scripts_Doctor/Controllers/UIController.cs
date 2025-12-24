using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController2 : MonoBehaviour
{
    public static UIController2 instance;
    [SerializeField] private TextMeshProUGUI _activityTaskText, _npcSubtitles;
    public GameObject _completedEllipse;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    //Вывод текста задания
    public void ChangeTaskText()
    {
        if (TaskController2.instance.ActivityTask != null)
        {          
            Task2 task = TaskController2.instance.ActivityTask;
            _activityTaskText.text = task.RUDescription;
        }
    }
    public void ChangeSubtitles(string subtitles)
    {
        _npcSubtitles.text = subtitles;
    }
}

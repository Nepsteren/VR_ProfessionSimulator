using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] private TextMeshProUGUI _activityTaskText, _npcSubtitles;

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
        if (TaskController.instance.ActivityTask != null)
        {          
            Task task = TaskController.instance.ActivityTask;
            _activityTaskText.text = task.RUDescription;
        }
    }
    public void ChangeSubtitles(string subtitles)
    {
        _npcSubtitles.text = subtitles;
    }
}

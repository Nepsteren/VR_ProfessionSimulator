using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskAnim : MonoBehaviour
{
    [SerializeField] Image _imageTask;
    [SerializeField] Sprite _endTask;
    [SerializeField] Sprite _startTask;

    public void SwitchImage()
    {
        if (_imageTask != null)
        {
            _imageTask.sprite = _endTask;
            StartCoroutine(Timer(1f));
        }
    }
    public IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        TaskController.instance.NextTask();
        _imageTask.sprite = _startTask;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextWriteAnimation : MonoBehaviour
{
    public static TextWriteAnimation instance;
    private void Awake()
    {
        instance = this;
    }
    /// <summary>
    /// Метод для посимвольной анимации текста
    /// </summary>
    /// <param name="strokeAnim">строка которую надо вписать</param>
    /// <param name="tmp">обьект TMP куда надо вписать</param>
    public void StartAnimation(string strokeAnim, TextMeshProUGUI tmp, float timeLife)
    {
        StartCoroutine(TextAnimation(strokeAnim, tmp, timeLife));
    }
    public IEnumerator TextAnimation(string strokeAnim, TextMeshProUGUI tmp, float timeLife)
    {
        tmp.gameObject.SetActive(true);
        tmp.text = "";
        for (int i = 0; i < strokeAnim.Length; i++)
        {
            tmp.text += strokeAnim[i];
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(timeLife);
        tmp.text = "";
        tmp.gameObject.SetActive(false);
    }
}

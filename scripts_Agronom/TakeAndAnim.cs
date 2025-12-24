using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeAndAnim : MonoBehaviour
{
    public string stroke;
    public TextMeshProUGUI tmp;
    public float timeLife;
    public void GrabWithTextAnim()
    {
        TextWriteAnimation.instance.StartAnimation(stroke, tmp, timeLife);
    }
}

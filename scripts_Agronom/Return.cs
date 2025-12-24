using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Return : MonoBehaviour
{
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private XRGrabInteractable _grab;

    private bool _returning = false;
    public float returnSpeed = 4f;

    void Start()
    {
        // Запоминаем исходное положение листа
        _startPosition = transform.localPosition;
        _startRotation = transform.localRotation;

        _grab = GetComponent<XRGrabInteractable>();

        // Подписываемся на события XR Toolkit
        _grab.selectExited.AddListener(OnRelease);
        _grab.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs arg)
    {
        // Перестаём возвращать лист, если его снова взяли
        _returning = false;
    }

    private void OnRelease(SelectExitEventArgs arg)
    {
        // Включаем возврат
        _returning = true;
    }

    void Update()
    {
        if (_returning)
        {
            // Плавный возврат
            transform.localPosition = Vector3.Lerp(transform.localPosition, _startPosition, Time.deltaTime * returnSpeed);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, _startRotation, Time.deltaTime * returnSpeed);

            // Если вернулся достаточно близко — фиксируем
            if (Vector3.Distance(transform.localPosition, _startPosition) < 0.01f)
            {
                transform.localPosition = _startPosition;
                transform.localRotation = _startRotation;
                _returning = false;
            }
        }
    }
}

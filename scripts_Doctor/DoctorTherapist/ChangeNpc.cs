using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNpc : MonoBehaviour
{
    [SerializeField] private GameObject _originalNpc, _throatNpc;
    private bool _active = false;

    public void Change()
    {
        _originalNpc.SetActive(_active);
        _active = !_active;
        _throatNpc.SetActive(_active);
    }
}

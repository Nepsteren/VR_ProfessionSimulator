using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovesOnHand : MonoBehaviour
{
    [SerializeField] GameObject _rightHand;
    [SerializeField] GameObject _leftHand;
    [SerializeField] Material _glovesMaterial;
    [SerializeField] AddGloves addGloves;
    public void PutGlovesOnHand()
    {
        _rightHand.GetComponent<Renderer>().material = _glovesMaterial;
        _leftHand.GetComponent<Renderer>().material = _glovesMaterial;
        addGloves.OnGlovesWorn();
    }
}

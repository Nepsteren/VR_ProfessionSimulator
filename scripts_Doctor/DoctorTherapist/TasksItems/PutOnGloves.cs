using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PutOnGloves : MonoBehaviour
{
    [SerializeField] private ActionBasedController _left, _right;
    [SerializeField] private Transform _leftHand,_rightHand;
    [SerializeField] private Material _gloveMaterial;
    [SerializeField] private SkinnedMeshRenderer _lSkin, _rSkin;

    //public void PutOn()
    //{
    //    ChangeMaterial(_lSkin);
    //    ChangeMaterial(_rSkin);
    //    PutOnEquipment.CompleteMission();
    //    _leftHand.gameObject.SetActive(true);
    //    _rightHand.gameObject.SetActive(true);
    //    _left.modelPrefab = _leftHand;
    //    _right.modelPrefab= _rightHand;
    //    Destroy(gameObject);
    //}
    public void PutOn()
    {
        _lSkin.material = _gloveMaterial;
        _rSkin.material = _gloveMaterial;
        PutOnEquipment.CompleteMission();
        Destroy(gameObject);
    }
    public void ChangeMaterial(SkinnedMeshRenderer sk)
    {       
        sk.materials[0] = _gloveMaterial;
        
    }
}

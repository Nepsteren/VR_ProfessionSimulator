using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThroatExaminationTask : Task2
{
    [SerializeField] private GameObject _shpatelTrigger,_originalNpc,_mouthNpc,_questionPanel;
    public XRGrabInteractable _shpatel;
    
    public override string RUDescription { get => "Осмотреть горло пациента c помощью шпателя"; set { } }
    public override string ENDescription { get => "Pack electronics and documents in a bag (telephone, laptop, camera, passport)"; }
    public override string Name { get => DoctorTherapistTasksNames.ThroatExamination.ToString(); }

    public override void ChangeOutline(bool active)
    {
        base.ChangeOutline(active);
    }
    public void EnableTrigger()
    {
        _shpatelTrigger.SetActive(true);
    }
    public void ChangeNpc()
    {
        _originalNpc.SetActive(false);
        _mouthNpc.SetActive(true);
    }
    public void EnablePanel()
    {
        PlayerPanel2.onlyEnable = true;
    }
    //Условия выполнения задания
    public override void Terms()
    {
        //_shpatelTrigger.SetActive(true);
        
        _shpatel.enabled = true;
        _questionPanel.SetActive(true);
        base.Terms();
    }

}

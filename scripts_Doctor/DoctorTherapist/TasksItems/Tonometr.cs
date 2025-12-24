using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Tonometr : MonoBehaviour
{
    private LineRenderer lineRenderer;   
    public static bool _torusOnHand;
    private bool _resultsReady;
    
    [SerializeField] private Transform _tonometrPos, _torusPos, _torusOnHandPos;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _emptyScreen, _resultScreen;
    


    void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();       
    }
    private void Update()
    {
        lineRenderer.SetPosition(0, _tonometrPos.position);
        //if (onHand)
        //    lineRenderer.SetPosition(1, _torusOnHandPos.position);        
        //else
        lineRenderer.SetPosition(1, _torusPos.position);
    }
    
    public void MeasurePressure()
    {
        if (_torusOnHand)
        {
            StartCoroutine(MeasureResults());
        }     
    }
    public void PutOnHand()
    {
        _torusOnHand = !_torusOnHand;
    }
    IEnumerator MeasureResults()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length);
        _emptyScreen.SetActive(false);
        _resultScreen.SetActive(true);
        if (!_resultsReady)
        {
            _resultsReady = true;
            PatientExaminationTask.CompleteMission();
        }

        yield return new WaitForSeconds(7);
        _emptyScreen.SetActive(true);
        _resultScreen.SetActive(false);
    }


}

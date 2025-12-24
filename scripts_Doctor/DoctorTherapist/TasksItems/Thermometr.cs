using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometr : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private GameObject _emptyImage, _temperatureImage;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartMeasure()
    {
        StartCoroutine(Measure());
    }
    private IEnumerator Measure()
    {
        yield return new WaitForSeconds(1f);
        _audioSource.Play();
        _emptyImage.SetActive(false);
        _temperatureImage.SetActive(true);
        StartCoroutine(RestartThermometr());
    }
    private IEnumerator RestartThermometr()
    {
        yield return new WaitForSeconds(7f);
        _emptyImage.SetActive(true);
        _temperatureImage.SetActive(false);

    }
}

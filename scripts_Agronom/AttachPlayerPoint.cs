using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachPlayerPoint : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] GameObject _currentTask;

    [SerializeField] GameObject[] spawnedObject;
    [SerializeField] AudioSource _audioSource;

    ActionBasedContinuousMoveProvider _continuousMoveProvider;
    ActionBasedContinuousTurnProvider _snapTurnProvider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<XROrigin>())
        {
            GameObject player = other.gameObject;
            player.transform.position = _spawnPoint.position;
            player.transform.rotation = _spawnPoint.rotation;
            _continuousMoveProvider = player.GetComponent<ActionBasedContinuousMoveProvider>();
            _snapTurnProvider = player.GetComponent<ActionBasedContinuousTurnProvider>();

            if(spawnedObject != null)
            {
                foreach (var objects in spawnedObject)
                {
                    foreach (var renderer in objects.transform.GetComponentsInChildren<MeshRenderer>())
                    {
                        renderer.enabled = true;
                    }
                }
            }           
            //_continuousMoveProvider.enabled = false;
            //_snapTurnProvider.enabled = false;
            
            _currentTask.GetComponent<Task>().FinishTask();
            gameObject.SetActive(false);
            _audioSource.Play();
        }          
    }
}

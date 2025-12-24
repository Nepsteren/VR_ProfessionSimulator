using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField] Button switchScene;
    [SerializeField] GameObject character;
    [SerializeField] Transform spawnPoint;
    void Start()
    {
        switchScene.onClick.AddListener(() => TPOnScene());
    }

    public void TPOnScene()
    {
        character.transform.position = spawnPoint.position;
    }
}

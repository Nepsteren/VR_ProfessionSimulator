using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _locomotionSystem;
    private bool onPause;
    [SerializeField] private GameObject _pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !onPause)
        {           
            Pause();
        }
    }
    public void Pause()
    {
        onPause = true;
        _pauseMenu.SetActive(true);
        _locomotionSystem.SetActive(false);
    }
    public void Resume()
    {
        onPause = false;
        _pauseMenu.SetActive(false);
        _locomotionSystem.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

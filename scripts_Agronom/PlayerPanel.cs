using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPanel : MonoBehaviour
{
    public static PlayerPanel instance;
    [SerializeField] private GameObject mainMenu;
    

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.z > 60 && transform.eulerAngles.z < 90)
        {
            mainMenu.SetActive(true);
        }
        else if (transform.eulerAngles.z < 60)
        {
            mainMenu.SetActive(false);
        }

    }

    //Перезапуск игры
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    //Выход из игры
    public void Exit()
    {
        Application.Quit();
    }

   
}

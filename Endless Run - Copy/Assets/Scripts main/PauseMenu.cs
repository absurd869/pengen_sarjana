using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public GameObject navToggle;
    public Toggle toggle;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

        if (PlayerPrefs.GetInt("navToggle") == 0)
                {
                   
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            navToggle.SetActive(false);
            toggle.isOn = false;
        }
        else
        {
            navToggle.SetActive(true);
        }

    }

 
    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("tutorial", 0);
        //SceneManager.LoadScene(sceneID);
        SceneManager.LoadScene(10);


    }


    public void Level(int SceneID)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneID);
    }
}
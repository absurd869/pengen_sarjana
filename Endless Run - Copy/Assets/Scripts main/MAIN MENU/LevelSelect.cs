using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] GameObject pauseMenu;

    int levelUnlocked;
    public Button[] buttons;

    private void Start()
    {
        PlayerPrefs.SetInt("tutorial",0);
        levelUnlocked = PlayerPrefs.GetInt("LevelUnlocked", 1);
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
            }
            
            for (int i = 0; i < levelUnlocked; i++)
            {
                buttons[i].interactable = true;
            }
        }
    }

    public void LoadScene(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
    }
    public void Back(int sceneID)
    {
        //Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        SceneManager.LoadScene(sceneID);
    }

    public void ResetButton(int Reset) 
    {
        PlayerPrefs.SetInt("LevelUnlocked", Reset);
        PlayerPrefs.SetInt("Achive", 0);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        
        for (int i = 0; i < levelUnlocked; i++)
        {
            buttons[i].interactable = true;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}

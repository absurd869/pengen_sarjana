using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ACHIEVEMENT : MonoBehaviour
{
    private int Achiev,Sp;
    public GameObject[] gameObjects;

    public void Achive()
    {
        Sp = PlayerPrefs.GetInt("SpAchive", 1);
        Achiev = PlayerPrefs.GetInt("Achive", 0);

       for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(true);
            }

       for (int i = 0; i < Achiev; i++)
            {
                gameObjects[i].SetActive(false);
            }
        
        if (Achiev == 7 && Sp == 0)
        {
            gameObjects[7].SetActive(false);
        }
       
            

            
        
    }

    /*
    public void ResetButton(int Reset)
    {
        PlayerPrefs.SetInt("LevelUnlocked", Reset);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelUnlocked; i++)
        {
            buttons[i].interactable = true;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }*/
}

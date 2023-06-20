using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lmao : MonoBehaviour
{
    private int clicked,levelUnlocked;
    public Button[] buttons;
    private void Start()
    {
        clicked = 0;
    }

    public void click()
    {
        clicked += 1;

        if (clicked == 3)
        {
            levelUnlocked = 8;
            
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].interactable = false;
                }

                for (int i = 0; i < levelUnlocked; i++)
                {
                    buttons[i].interactable = true;
                }
            
        }

        PlayerPrefs.SetInt("Achive", 7);
    }
}
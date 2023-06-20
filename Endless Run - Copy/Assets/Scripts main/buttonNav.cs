using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonNav : MonoBehaviour
{
    public GameObject navToggle;
    public Toggle toggle;

    
    private void Start()
    {
         if (!PlayerPrefs.HasKey("navToggle"))
        {
            PlayerPrefs.SetInt("navToggle", 1);
            navToggle.SetActive(true);
        }
        else
{
    if (PlayerPrefs.GetInt("navToggle") == 0)
    {
        navToggle.SetActive(false);
        toggle.isOn = false;
    }
    else
    {
        navToggle.SetActive(true);
    }
}
    }

}

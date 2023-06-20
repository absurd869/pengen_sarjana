using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INFOAWAL : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject info;
    public GameObject swipe;
    
    void Start()
    {


        if (!PlayerPrefs.HasKey("tutorial"))
        {
            PlayerPrefs.SetInt("tutorial", 0);
            Time.timeScale = 0;
            info.SetActive(true);
            swipe.SetActive(true);
        } 
       
        else if (PlayerPrefs.GetInt("tutorial") == 0)
        {
            Time.timeScale = 0;
            info.SetActive(true);
        }
        else
        {
            info.SetActive(false);
            swipe.SetActive(true);
            Time.timeScale = 1;
            
        }
    }

    public void sudahBaca(int sudah)
    {
        PlayerPrefs.SetInt("tutorial", sudah);
        Time.timeScale = 1;
    }
}

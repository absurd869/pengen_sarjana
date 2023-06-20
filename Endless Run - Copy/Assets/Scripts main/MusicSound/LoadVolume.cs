using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadVolume : MonoBehaviour
{

    public static AudioSource lama;
    
    void Awake()
    {

        //AudioSource audio = gameObject.GetComponent<AudioSource>();
        lama = gameObject.GetComponent<AudioSource>();
       
        if (!PlayerPrefs.HasKey("musicToggle"))
        {
            PlayerPrefs.SetInt("musicToggle", 1);
        }
        else 
        {
            if (PlayerPrefs.GetInt("musicToggle") == 0)
            {
                lama.mute = true;
            }
        }



        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);

            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainMenu");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
    }
    
    
    

}

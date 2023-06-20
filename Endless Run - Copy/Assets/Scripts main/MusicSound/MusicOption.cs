using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOption : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public Toggle toggle;

    private GameObject alpa;
    private AudioSource volume;

    
    public void Start()
    {
        alpa = GameObject.FindGameObjectWithTag("MainMenu");
        volume = alpa.GetComponent<AudioSource>();

        int music = PlayerPrefs.GetInt("musicToggle", 1);
        if (music != 1)
            toggle.isOn = false;
        Load();
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void musicToggle()
    {
        if (!toggle.isOn)
        {
            PlayerPrefs.SetInt("musicToggle", 0);
        }
        else
        {
            PlayerPrefs.SetInt("musicToggle", 1);
        }
    }

    public void test()
    {

        if (toggle.isOn)
        {
            volume.mute = false;
            Debug.Log("nyala");
        }
        else
        {
            volume.mute = true;
            Debug.Log("mati");
        }

    }
}

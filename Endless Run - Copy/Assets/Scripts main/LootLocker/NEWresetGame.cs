using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWresetGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("sudahreset"))
        {
            PlayerPrefs.SetInt("highscore", 0);
            PlayerPrefs.SetInt("sudahreset", 1);
        }   
    }
}

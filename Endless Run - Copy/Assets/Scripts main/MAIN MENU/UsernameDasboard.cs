using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UsernameDasboard : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text UsernameText;
    private void Start()
    {
        Application.targetFrameRate = 100;

        UsernameText.text = PlayerPrefs.GetString("username","PemainAnonim");
        
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_1 : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool gameOver;
    public GameObject gameOverpanel;
    public GameObject swipe;
    //public GameObject navToggle;
   // public GameObject GameFinishText;

    public GameObject Passing;
    public GameObject Failed;
    //public GameObject 
    //public Toggle toggle;

    public Text scoreText;
    public Text failOrNot;
    private float score;
    public static int GoldOfCoins;
    public Text textcoingold;

    
    

    void Start()
    {
       // Application.targetFrameRate = 60;
        gameOver = false;
        GoldOfCoins = 0;

        PlayerPrefs.SetInt("LevelSekarang", 1);
        PlayerPrefs.SetInt("SpAchive", 0);
       
        //Debug.Log("Level Sekarang " + PlayerPrefs.GetInt("LevelSekarang"));
    }

    /*
    public void cekNav()
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
    */

    // Update is called once per frame


    private void FixedUpdate()
    {
        if (GoldOfCoins == 24)
        {
            
            Target();
            
            // Time.timeScale = 0;
        }

        //Level 1 SCRIPT

        
        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }

        textcoingold.text = GoldOfCoins.ToString();
        failOrNot.text = GoldOfCoins.ToString();

        //MAIN_GAMESCRIPT
        if (gameOver)
        {

            PlayerPrefs.SetInt("SpAchive", 1);

            FindObjectOfType<AudioManager>().Play("GameOver");

            swipe.SetActive(false);
            Time.timeScale = 0;
            gameOverpanel.SetActive(true);
            
            score = 0;
            GoldOfCoins = 0;
        }
        
    }

    /*
    public void BACK()
    {
        bool a = toggle.isOn;
        if (!a)
        {
            PlayerPrefs.SetInt("navToggle", 0);
        }
        else
        {
            PlayerPrefs.SetInt("navToggle", 1);
            navToggle.SetActive(true);

        }
    }
    */

    //LEVEL 1-SKRIPSI
    private void Target()
    {
        pass();
        FindObjectOfType<AudioManager>().Play("NewRecord");
        Debug.Log("TARGET GOLD TERCAPAI");
        
        
        gameOverpanel.SetActive(true);
        Failed.SetActive(false);
        Passing.SetActive(true);

        //GameFinishText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    //LEVEL WISUDA

    public void pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("LevelUnlocked"))
        {
            PlayerPrefs.SetInt("LevelUnlocked", currentLevel);
            PlayerPrefs.SetInt("Achive", 1);
        }
        Debug.Log("Level Unlocked " + PlayerPrefs.GetInt("LevelUnlocked"));
    }
}

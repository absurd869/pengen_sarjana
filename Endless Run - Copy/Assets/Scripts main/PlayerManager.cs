using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class PlayerManager : MonoBehaviour
{
    public static Animator AnimChoice;

    public static bool gameOver;
    public GameObject gameOverpanel;
    public GameObject newHighscore;
    public GameObject swipe;
    public GameObject THANKS;

    public Text TogaScore;
    public Text scoreText;
    public Text RunningHighscore;
    public TMP_Text ReplayhighscoreText;
    public Text GameFinishText;

    private int oldscore;
    private float score,currentTime;
    
    public static int Toga;
    public static bool LevelWisuda;

    void Start()
    {
       // AnimChoice = allAnim[3];

        gameOver = false;

        //PlayerPrefs.SetInt("LevelSekarang", 8);
        LevelWisuda = true;
        Toga = 0;
        currentTime = 0;

        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
            oldscore = PlayerPrefs.GetInt("highscore");
            
        }
        else
        {
            oldscore = PlayerPrefs.GetInt("highscore");
            PlayerPrefs.SetInt("LevelSekarang", 8);
            RunningHighscore.text = ((int)oldscore).ToString();
        }

       // RunningHighscore.text = oldscore.ToString();

        /*
       if(!THANKS.activeSelf)
        {
            cekNav();
        }*/



    }

    //SCRIPT UNTUK NAVIGASI/CONTROLLER
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

        //WISUDA SCRIPT

       
        currentTime = currentTime + Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        scoreText.text = time.ToString(@"mm\:ss");


        TogaScore.text = Toga.ToString();
        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            //score += 1 * Time.deltaTime;
            score = Toga;
            // scoreText.text = ((int)score).ToString();
            //scoreText.text = ((int)score).ToString();
        }

        /*
        if (Toga == 5)
        {
            Bonus();
        }*/

        //MAIN_GAMESCRIPT
        if (gameOver)
        {

            if ( (int)score > oldscore)
            {
                newHighscore.gameObject.SetActive(true);
                ReplayhighscoreText.text = ((int)score).ToString();
                PlayerPrefs.SetInt("highscore", (int)score);

                FindObjectOfType<AudioManager>().Play("NewRecord");

                swipe.SetActive(false);
                Time.timeScale = 0;
                gameOverpanel.SetActive(true);
                //Toga = 0;
            }
            else
            {
                newHighscore.gameObject.SetActive(false);
                ReplayhighscoreText.text = ((int)score).ToString();

                FindObjectOfType<AudioManager>().Play("GameOver");

                swipe.SetActive(false);
                Time.timeScale = 0;
                gameOverpanel.SetActive(true);
                //Toga = 0;
            }
    
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

      //LEVEL WISUDA
    private void Bonus()
    {
        Debug.Log("BONUS SCORE + 5");
        score+=5;
        FindObjectOfType<AudioManager>().Play("Bonus");
        Toga = 0;
      }
    /*
    public void pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("LevelUnlocked"))
        {
            PlayerPrefs.SetInt("LevelUnlocked", currentLevel);
        }
        Debug.Log("Level Unlocked " + PlayerPrefs.GetInt("LevelUnlocked"));
    }*/
}

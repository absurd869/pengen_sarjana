using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_3 : MonoBehaviour
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

    public GameObject GoldPass;
    public GameObject SilverPass;
    public Text scoreText;
    private float score;
    public static int GoldOfCoins;
    public static int SilverOfCoins;
    public Text textcoingold;
    public Text textcoinsilver;

    void Start()
    {
        gameOver = false;
        GoldOfCoins = 0;
        SilverOfCoins = 0;

        GoldCoins.TrgtGold = 0;
        SilverCoins.TrgtSilver = 0;

        //GANTI SETIAP LEVEL
        PlayerPrefs.SetInt("LevelSekarang", 3);


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


        if (GoldOfCoins < 19 )
        {
            GoldOfCoins = GoldCoins.TrgtGold;
        }

        if(SilverOfCoins < 7)
        {
            SilverOfCoins = SilverCoins.TrgtSilver;
        }

        if (GoldOfCoins == 18)
        {
            GoldPass.SetActive(true);
            GoldCoins.TrgtGold += 1;
            FindObjectOfType<AudioManager>().Play("Bonus");
        }

        if (SilverOfCoins == 6)
        {
            SilverPass.SetActive(true);
            SilverCoins.TrgtSilver += 1;
            FindObjectOfType<AudioManager>().Play("Bonus");
            Debug.Log("SILVERRR");
        }

        if (GoldOfCoins == 19 && SilverOfCoins == 7)
        {
            Target();
            // Time.timeScale = 0;
        }

        //Level 3 SCRIPT


        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }

        textcoingold.text = GoldOfCoins.ToString();
        textcoinsilver.text = SilverOfCoins.ToString();
        //failOrNot.text = GoldOfCoins.ToString();

        //MAIN_GAMESCRIPT
        if (gameOver)
        {

            FindObjectOfType<AudioManager>().Play("GameOver");

            swipe.SetActive(false);
            Time.timeScale = 0;
            gameOverpanel.SetActive(true);
            
            PlayerPrefs.SetInt("SpAchive", 1);


            score = 0;
            GoldOfCoins = 0;
            SilverOfCoins = 0;

            GoldCoins.TrgtGold = 0;
            SilverCoins.TrgtSilver = 0;
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
        }
        Debug.Log("Level Unlocked " + PlayerPrefs.GetInt("LevelUnlocked"));
    }
}

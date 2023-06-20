using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_4 : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool gameOver;
    //public GameObject navToggle;
    // public GameObject GameFinishText;
    //public GameObject 
    //public Toggle toggle;

    public GameObject gameOverpanel;
    public GameObject swipe;
    public GameObject Passing;
    public GameObject Failed;

    public GameObject GoldPass;
    public GameObject SilverPass;
    public GameObject JurnalPass;

    public Text scoreText;
    private float score;
    
    private int GoldOfCoins;
    private int SilverOfCoins;
    private int JurnalOfNumber;

    public Text textcoingold;
    public Text textcoinsilver;
    public Text textjurnal;

    void Start()
    {
        gameOver = false;
        GoldOfCoins = 0;
        SilverOfCoins = 0;
        JurnalOfNumber = 0;

        GoldCoins.TrgtGold = 0;
        SilverCoins.TrgtSilver = 0;
        Jurnal.TrgtJurnal = 0;


        //GANTI SETIAP LEVEL
        PlayerPrefs.SetInt("LevelSekarang", 4);


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

        if (GoldOfCoins < 16)
        {
            GoldOfCoins = GoldCoins.TrgtGold;
        }

        if (SilverOfCoins < 6)
        {
            SilverOfCoins = SilverCoins.TrgtSilver;
        }

        if(JurnalOfNumber < 5)
        {
            JurnalOfNumber = Jurnal.TrgtJurnal;
        }
  
        if (GoldOfCoins == 15)
        {
            GoldPass.SetActive(true);
            GoldCoins.TrgtGold += 1;
            FindObjectOfType<AudioManager>().Play("Bonus");
        }

        if (SilverOfCoins == 5)
        {
            SilverPass.SetActive(true);
            SilverCoins.TrgtSilver += 1;
            FindObjectOfType<AudioManager>().Play("Bonus");
            //Debug.Log("SILVERRR");
        }
        if (JurnalOfNumber == 4)
        {
            JurnalPass.SetActive(true);
            Jurnal.TrgtJurnal += 1;
            FindObjectOfType<AudioManager>().Play("Bonus");
        }



        if (GoldOfCoins == 16 && SilverOfCoins == 6 && JurnalOfNumber == 5)
        {
            Target();


            // Time.timeScale = 0;
        }

        //Level 4 SCRIPT


        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }

        //PANEL INFOS
        textcoingold.text = GoldOfCoins.ToString();
        textcoinsilver.text = SilverOfCoins.ToString();
        textjurnal.text = JurnalOfNumber.ToString();

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
            JurnalOfNumber = 0;

            GoldCoins.TrgtGold = 0;
            SilverCoins.TrgtSilver = 0;
            Jurnal.TrgtJurnal = 0;
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
            PlayerPrefs.SetInt("Achive", 4);
        }
        Debug.Log("Level Unlocked " + PlayerPrefs.GetInt("LevelUnlocked"));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_2 : MonoBehaviour
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

        PlayerPrefs.SetInt("LevelSekarang", 2);
        

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

    /* void Update()
     {

         //textcoingold.text = "" + GoldOfCoins;
         //textcoinsilver.text = "" + SilverOfCoins;

         Debug.Log("masih jalan");

         TogaScore.text = Toga.ToString();
         if (GameObject.FindGameObjectsWithTag ("Player") != null)
         {
                 score += 1 * Time.deltaTime;
                 scoreText.text = ((int)score).ToString();
         }
        
} */


private void FixedUpdate()
    {

      if(GoldOfCoins < 21)
        {
            GoldOfCoins = GoldCoins.TrgtGold;
        }

      if(SilverOfCoins < 5)
        {
            SilverOfCoins = SilverCoins.TrgtSilver;
            //Debug.Log("CEKING SILVER");
        }
            
            

        if(GoldOfCoins == 20)
        {
            GoldPass.SetActive(true);
            GoldCoins.TrgtGold += 1;
            FindObjectOfType<AudioManager>().Play("Bonus");

        }

        if(SilverOfCoins == 4)
        {
            SilverPass.SetActive(true);
            SilverCoins.TrgtSilver += 1;
            FindObjectOfType<AudioManager>().Play("Bonus");
        }

        if (GoldOfCoins == 21 && SilverOfCoins == 5)
        {
            Target();
            

            // Time.timeScale = 0;
        }

        //Level 2 SCRIPT


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

    //LEVEL 1-SKRIPSI MISI SUKSES
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
            PlayerPrefs.SetInt("Achive", 2);
        }
        Debug.Log("Level Unlocked " + PlayerPrefs.GetInt("LevelUnlocked"));
    }
}

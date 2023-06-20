using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSkripsi : MonoBehaviour
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

    public GameObject JurnalPass;
    public GameObject LaptopPass;

    public Text scoreText;
    private float score;

    private int JurnalOfNumber;
    private int LaptopOfNumber;

    public Text textjurnal;
    public Text textlaptop;

    public static bool LevelSkrip;
    void Start()
    {
        gameOver = false;
        JurnalOfNumber = 0;
        LaptopOfNumber = 0;


        
        Jurnal.TrgtJurnal = 0;
        Laptop.TrgtLaptop = 0;


        //GANTI SETIAP LEVEL
        PlayerPrefs.SetInt("LevelSekarang", 7);


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

        if (JurnalOfNumber < 21)
        {
            JurnalOfNumber = Jurnal.TrgtJurnal;
        }

        if (LaptopOfNumber < 5)
        {
            LaptopOfNumber = Laptop.TrgtLaptop;
        }


        if (JurnalOfNumber == 20)
        {
            JurnalPass.SetActive(true);
            Jurnal.TrgtJurnal += 1;
            FindObjectOfType<AudioManager>().Play("Bonus");
        }

        if (LaptopOfNumber == 4)
        {
            LaptopPass.SetActive(true);
            Laptop.TrgtLaptop += 1;
            FindObjectOfType<AudioManager>().Play("Bonus");
        }


        if (JurnalOfNumber == 21 && LaptopOfNumber == 5)
        {
            Target();


            // Time.timeScale = 0;
        }

        //Level 5 SCRIPT


        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }

        //PANEL INFOS
        textjurnal.text = JurnalOfNumber.ToString();
        textlaptop.text = LaptopOfNumber.ToString();

        //MAIN_GAMESCRIPT
        if (gameOver)
        {

            FindObjectOfType<AudioManager>().Play("GameOver");

            swipe.SetActive(false);
            Time.timeScale = 0;
            gameOverpanel.SetActive(true);

            score = 0;
            
            JurnalOfNumber = 0;
            LaptopOfNumber = 0;

            Jurnal.TrgtJurnal = 0;
            Laptop.TrgtLaptop = 0;

            PlayerPrefs.SetInt("SpAchive", 1);
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
        //Debug.Log("TARGET GOLD TERCAPAI");

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
            PlayerPrefs.SetInt("Achive", 7);
            PlayerPrefs.SetInt("SpAchive", 0);

        }
        Debug.Log("Level Unlocked " + PlayerPrefs.GetInt("LevelUnlocked"));
    }
}

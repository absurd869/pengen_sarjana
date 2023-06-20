using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using UnityEngine.UI;

public class Username : MonoBehaviour
{
    // Start is called before the first frame update

    private int MaxScore;
    public int ID, highscore;
    private string Duplicate;
    bool a, adaGI;

    public GameObject YesNo, OfflineWarning, DuplicateWarning, serverCheck;
    public GameObject usernamePanel, leaderboard;
    public TextMeshProUGUI TextUsername;

    public Button back, ok, cancel;
    private string username;
    private string GUEST_ID;

    public InputField mainInputField;

    void Start()
    {
        MaxScore = 10;
        mainInputField.characterLimit = 16;
        highscore = PlayerPrefs.GetInt("highscore", 0);


    }

    public void cekUser()
    {
        back.interactable = false;
        if (PlayerPrefs.HasKey("username") == true)
        {
            adaGI = true;
            GUEST_ID = PlayerPrefs.GetString("guest_id");
            usernamePanel.SetActive(false);
            serverCheck.SetActive(true);
            CekKoneksi();
        }
        else
        {
            adaGI = false;
            serverCheck.SetActive(true);
            GUEST_ID = "player" + GenerateRandom();
            PlayerPrefs.SetString("guest_id",GUEST_ID);
            CekKoneksi();
        }
    }
   

    // CEK KONEKSI KE SERVER
    private void CekKoneksi()
    {
        LootLockerSDKManager.StartGuestSession(GUEST_ID, (response) =>
        {
            

            if (!response.success)
            {
                Debug.Log("FAILED");
                serverCheck.SetActive(false);
                OfflineWarning.SetActive(true);
             
                //back.interactable = false;

            }

            else
            {

                back.interactable = true;
                if (!adaGI)
                {
                    serverCheck.SetActive(false);
                }
                else
                {
                     //Debug.Log("SUCCESS_" + GUEST_ID);
                    leaderboard.SetActive(true);
                    serverCheck.SetActive(false);
                }

            }
        });
    }

    //CEK DUPLIKAT USERNAME
    public void cekdata()
    {

        LootLockerSDKManager.StartGuestSession(GUEST_ID, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("FAILED");
            }

            else
            {
                Debug.Log("SUCCESS");
            }
        });

        LootLockerSDKManager.GetScoreList(ID, MaxScore, (response) =>
         {
             if (!response.success)
             {
                 Debug.Log("FAILED");
                //OfflineWarning.SetActive(true);
            }

             else
             {
                 LootLockerLeaderboardMember[] scores = response.items;


                 for (int i = 0; !a && i < scores.Length; i++)
                 {

                    //EntriesName[i].text = (scores[i].rank + " " + scores[i].member_id + ".   " + scores[i].score);

                    Duplicate = (scores[i].member_id);

                     if (Duplicate == mainInputField.text)
                     {
                         a = true;
                     }
                 }

                 if (!a)
                 {
                     YesNo.SetActive(true);
                    //SubmitScore(); 
                    //SaveUsername();
                }
                 else
                 {
                     DuplicateWarning.SetActive(true);
                    //Debug.Log("DATA ADA YANG SAMA");
                    a = false;
                 }
             }
         });
    }


    public void SaveUsername()
    {
        PlayerPrefs.SetString("username", mainInputField.text);
        string ini = PlayerPrefs.GetString("username");
        TextUsername.text = ini;
        leaderboard.SetActive(true);


        LootLockerSDKManager.SubmitScore(ini, highscore, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("SUCCESS");
            }

            else
            {
                Debug.Log("FAILED");
            }
        });

    }

    private static string GenerateRandom()
    {
        var allChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789";
        var length = 5;

        var randomChars = new char[length];

        for (int i = 0; i < length; i++)
        {
            randomChars[i] = allChars[UnityEngine.Random.Range(0, allChars.Length)];
        }

        return new string(randomChars);
    }

    //TOMBOL & INPUT
    public void Update()
    
    {
        username = mainInputField.text;

        if (username.Length < 7)
        {
            ok.interactable = false;
        }
        else
        {
            ok.interactable = true;
        }
    }

    /*private IEnumerator Cancel()
    {
        yield return new WaitForSeconds(3);
        cancel.interactable = true;
    }*/
}

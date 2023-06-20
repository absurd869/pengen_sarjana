using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class ServerCont : MonoBehaviour
{

    public GameObject serverCheck, OfflineWarning;
    private int highscore, MaxScore;
    public int ID;

    //public int unikid;
    private string PlayerUsername;
    public TMP_Text[] EntriesName;
    public TMP_Text[] Higscore;
 
    public TMP_Text PlayerRank, PlayerName, PlayerScore;
 
    private void Start()
    {

       
        highscore = PlayerPrefs.GetInt("highscore", 0);
        PlayerUsername = PlayerPrefs.GetString("username");

        PlayerName.text = PlayerUsername;
        PlayerScore.text = highscore.ToString();

        MaxScore = 99;
        SubmitScore();
    
    }
    public void ShowScores()
    {
        //LootLockerSDKManager.GetScoreListMain(ID,MaxScore,unikid, (response)=>
        //LootLockerSDKManager.GetScoreList(ID, MaxScore, (response) =>
        LootLockerSDKManager.GetScoreList(ID, MaxScore, (response) =>

        {
            if (!response.success)
            {
                //respon = response.pagination;
                Debug.Log("FAILED");
            }

            else
            {
                LootLockerLeaderboardMember[] scores = response.items;

                //for (int i = 0; i < scores.Length; i++)
                for (int i = 0; i < scores.Length; i++)
                {
                    //EntriesName[i].text = (scores[i].rank + " " + scores[i].member_id + ".   " + scores[i].score);
                    //EntriesName[i].text = (scores[i].member_id + ".   " + scores[i].score);
                    if (i < 10)
                    {
                        EntriesName[i].text = (scores[i].member_id);
                        Higscore[i].text = (scores[i].score.ToString());
                    }

                    if(scores[i].member_id == PlayerUsername)
                    {
                        PlayerRank.text = (scores[i].rank.ToString());
                    }
                    
                }

                if (scores.Length < 10)
                {
                    // for (int i = scores.Length; i < MaxScore; i++)
                    for (int i = scores.Length; i < 10; i++)
                    {
                        EntriesName[i].text = (" BELUM ADA PEMAIN ");
                        Higscore[i].text = "0";
                    }
                }

                Debug.Log("SUCCESS");
            }
        });
    }
    public void SubmitScore()
    {
      
        LootLockerSDKManager.SubmitScore(PlayerUsername, highscore, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("SUCCESS");
                
                StartCoroutine(ShowScor());
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            else
            {
                Debug.Log("FAILED");
               
            }
        });

    }
    private IEnumerator ShowScor()
    {
        yield return new WaitForSeconds(1f);
        ShowScores();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Karakter : MonoBehaviour
{
    public lockclass[] lockk;
    public GameObject[] tulisan,karakter,gembok,warning;
    public Button[] nav;
    private int showup,level,highscore;

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("Achive", 0);
        highscore = PlayerPrefs.GetInt("highscore", 0);
 
        foreach(lockclass a in lockk)
        {
            if (level == 7) 
            {

                a.unLocked = true;

                if (highscore >= a.target)
                    a.unLocked = true;
                else
                    a.unLocked = false;
            }

            else
            {
                if (a.index == 0)
                    a.unLocked = true;
                else
                    a.unLocked = false;
            }
        }
            
    }

    private void Update()
    {
        buttonNav();
       // cekBuka();
    }

    public void gantiKarakter(string arah)
    {
        if(arah == "right")
        {
            showup++;

            tulisan[showup].SetActive(true);
            tulisan[showup - 1].SetActive(false);
            
            karakter[showup].SetActive(true);
            karakter[showup - 1].SetActive(false);

            warning[showup - 1].SetActive(false);

            if (!lockk[showup].unLocked)
            {
                warning[showup].SetActive(true);gembok[0].SetActive(true); nav[2].interactable = false;
            }
            else
            {
                warning[showup].SetActive(false); gembok[0].SetActive(false); nav[2].interactable = true;
            }
                

        }
        else
        {
            showup--;

            tulisan[showup].SetActive(true);
            tulisan[showup + 1].SetActive(false);

            karakter[showup].SetActive(true);
            karakter[showup + 1].SetActive(false);

            warning[showup + 1].SetActive(false);

            if (!lockk[showup].unLocked)
            {
                warning[showup].SetActive(true); gembok[0].SetActive(true); nav[2].interactable=false;
            }
            else
            {
                warning[showup].SetActive(false); gembok[0].SetActive(false); nav[2].interactable = true;
            }

        }

        Debug.Log(showup);
    }

    private void buttonNav()
    {
        // RIGHT BUTTON
        if (showup == 3)
        {
           nav[0].interactable = false;
        }
        else
        {
            nav[0].interactable = true;
        }
        // LEFT BUTTON


        if (showup == 0)
        {

            nav[1].interactable = false;
        }

        else
        {
            nav[1].interactable = true;
        }
    }

    public void cekBuka()
    {

        for (int i = 1; i <= lockk.Length; i++)
        {
            gembok[0].SetActive(true);

        }

        for (int i = 1; i <= 1; i++)
        {
            gembok[0].SetActive(false);
        }

    }

    public void PilihKarakter()
    {
        PlayerPrefs.SetInt("karakter",showup);
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelSekarang"));
    }
}

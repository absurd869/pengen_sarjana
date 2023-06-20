using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Button[] button;

    private void Start()
    {
        StartCoroutine(wait());
    }

    public void PlayGame(int sceneID)
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        //SceneManager.LoadScene(sceneID);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }

    private IEnumerator wait()
    {
        Debug.Log("INI");

        foreach (Button a in button)
        {
            a.interactable = false;
        }

        yield return new WaitForSeconds(0.1f);

        foreach (Button a in button)
        {
            a.interactable = true;
        }
    }
}

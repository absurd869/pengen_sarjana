using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoins : MonoBehaviour
{
    // Update is called once per frame

    public static int TrgtGold;
    private int ObjGold,LevelSekarang;

    private void Start()
    {
        ObjGold = ObjectiveController.ObjGoldCoins;
        //TrgtGold = 0;
        LevelSekarang = PlayerPrefs.GetInt("LevelSekarang");
    }
    void Update()
    {
        transform.Rotate(0 ,0, 50 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    //private void OnCollissionEnter()
    {

       // if (other.tag == "Player")
            if (other.CompareTag("Player"))
            {
            //FindObjectOfType<AudioManager>().Play("Item");

            if (LevelSekarang == 1)
            {
                Level_1.GoldOfCoins += 1;
                FindObjectOfType<AudioManager>().Play("Item");
                Destroy(gameObject);
            }
            
            
            else
            {

                if (TrgtGold < ObjGold)
                {
                    FindObjectOfType<AudioManager>().Play("Item");
                    TrgtGold += 1;
                    Destroy(gameObject);

                }
            }

           // Debug.Log("GOLD = " + PlayerManager.Toga);
            
        }
            
        
        
    }
}

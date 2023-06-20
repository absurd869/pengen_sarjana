using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoins : MonoBehaviour
{
    public static int TrgtSilver;
    private int ObjSilver;

    private void Start()
    {
        ObjSilver = ObjectiveController.ObjSilverCoins;
        //TrgtGold = 0;
       // LevelSekarang = PlayerPrefs.GetInt("LevelSekarang");
    }

    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    //private void OnCollissionEnter()
    {

        //if (other.CompareTag("Player")) 
            if (other.tag == "Player")
        {

            if (TrgtSilver < ObjSilver)
            {
                FindObjectOfType<AudioManager>().Play("Item");
                TrgtSilver += 1;
                Destroy(gameObject);

            }

            // Debug.Log("GOLD = " + PlayerManager.Toga);
            //Destroy(gameObject);
        }



    }
}

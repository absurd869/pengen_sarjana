using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jurnal : MonoBehaviour
{
    public static int TrgtJurnal;
    private int ObjJurnal;

    private void Start()
    {
        ObjJurnal = ObjectiveController.ObjJurnal;
        //TrgtJurnal = 0;
        //LevelSekarang = PlayerPrefs.GetInt("LevelSekarang");
    }
    void Update()
    {
        transform.Rotate(0, 1, 0 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    //private void OnCollissionEnter()
    {
        //if (other.tag == "Player")
            if (other.CompareTag("Player"))
            {
            //FindObjectOfType<AudioManager>().Play("Item");

                if (TrgtJurnal < ObjJurnal)
                {
                    FindObjectOfType<AudioManager>().Play("Item");
                    TrgtJurnal += 1;
                Destroy(gameObject);
                }
            }
    }
}

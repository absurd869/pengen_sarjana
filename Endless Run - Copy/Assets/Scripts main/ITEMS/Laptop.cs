using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    public static int TrgtLaptop;
    private int ObjLaptop;

    private void Start()
    {
        ObjLaptop = ObjectiveController.ObjLaptop;
        //TrgtLaptop = 0;
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

            if (TrgtLaptop < ObjLaptop)
            {
                FindObjectOfType<AudioManager>().Play("Item");
                TrgtLaptop += 1;
                Destroy(gameObject);
            }
        }
    }
}

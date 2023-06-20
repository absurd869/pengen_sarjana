using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toga : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0 ,0.9f, 0 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Player")
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Toga");
            PlayerManager.Toga += 1;
            //PlayerManager.
           // Debug.Log("Toga = " + PlayerManager.Toga);
            Destroy(gameObject);
        }
        
    }
}

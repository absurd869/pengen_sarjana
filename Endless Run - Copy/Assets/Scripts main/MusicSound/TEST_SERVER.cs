using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class TEST_SERVER : MonoBehaviour
{
    // Start is called before the first frame update
    public void CekKoneksi()
    {
        LootLockerSDKManager.StartGuestSession("Player", (response) =>
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
    }
}

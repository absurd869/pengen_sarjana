using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{

    public static int ObjGoldCoins,ObjSilverCoins,ObjJurnal,ObjLaptop;

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("LevelSekarang") == 1)
        {
            ObjGoldCoins = 24;
        }


        else if (PlayerPrefs.GetInt("LevelSekarang") == 2)
        {
            ObjGoldCoins = 20;
            ObjSilverCoins = 4;
        }

        else if (PlayerPrefs.GetInt("LevelSekarang") == 3)
        {
            ObjGoldCoins = 18;
            ObjSilverCoins = 6;

        }

        else if (PlayerPrefs.GetInt("LevelSekarang") == 4)
        {
            ObjGoldCoins = 15;
            ObjSilverCoins = 5;
            ObjJurnal = 4;

        }

        else if (PlayerPrefs.GetInt("LevelSekarang") == 5)
        {
            ObjGoldCoins = 10;
            ObjSilverCoins = 5;
            ObjJurnal = 5;
            ObjLaptop = 4;

        }

        else if (PlayerPrefs.GetInt("LevelSekarang") == 6)
        {
            ObjGoldCoins = 5;
            ObjSilverCoins = 5;
            ObjJurnal = 10;
            ObjLaptop = 4;

        }

        else if (PlayerPrefs.GetInt("LevelSekarang") == 7)
        {
            ObjJurnal= 21;
            ObjLaptop = 4;

        }


    }


}

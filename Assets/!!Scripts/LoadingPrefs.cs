using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("FirstTime", 0) == 0)
        {
            //LoadTesting.ReviewLevel = 0;
            PlayerPrefs.SetInt("Stage1", 1);
            PlayerPrefs.SetInt("Stage2", 0); ///chnage to 0
            PlayerPrefs.SetInt("Stage3", 0);
            //PlayerPrefs.SetInt("Level1", 1); ///change to 1
           // PlayerPrefs.SetInt("Level2", 1); ///change to 1
            PlayerPrefs.SetInt("Level3", 1);
            PlayerPrefs.SetInt("FirstTime", 1);
            PlayerPrefs.SetInt("Review", 0);
           // PlayerPrefs.SetInt("Sound", 1);
           //PlayerPrefs.SetInt("Music", 1);
            PlayerPrefs.SetInt("Removeads", 0);
           // PlayerPrefs.SetString("Steering", "Large");
           //PlayerPrefs.SetInt("Credits", 0);
            PlayerPrefs.SetString("Car1Material", "100000");
            PlayerPrefs.SetInt("Car1MaterialRecent", 0);
            PlayerPrefs.SetString("Car2Material", "100000");
            PlayerPrefs.SetInt("Car2MaterialRecent", 0);
            PlayerPrefs.SetInt("PlayerImages", 0);
           // PlayerPrefs.SetInt("MPCredits",0); //winnerpanel
            PlayerPrefs.SetInt("MPLooserCredit", 0); //WinnerPanel
        } 
    }
}

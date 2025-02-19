using UnityEngine;
using Firebase;
using Firebase.Analytics;

public class FirebaseHandler : MonoBehaviour
{
    public static FirebaseHandler Instance;

    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;


            DontDestroyOnLoad(this);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Call This Function In Level Fail Or Complete...
    /// </summary>
    /// <param name="modeName"></param>
    /// <param name="stageNum"></param>
    /// <param name="levelNo"></param>
    /// <param name="levelStatus"></param>
    //public void LogCustomEvent(string modeName, int stageNum, int levelNo, string levelStatus)
    //{
    //    Debug.Log("Selected Mode: "+ modeName + " Stage Num: " + stageNum + " Level Num: " + levelNo + " Level Status: " + levelStatus);
    //    FirebaseAnalytics.LogEvent("Selected Mode: " + modeName + " Stage Num: " + stageNum + " Level Num: " + levelNo + " Level Status: " + levelStatus);
    //}

    public void LogCustomEvent(int modeName,  int levelNo, string levelStatus, int car)
    {
        Debug.Log("Selected Mode: " + modeName + " Level Num: " + levelNo + " Level Status: " + levelStatus + " Car: " + car);
        FirebaseAnalytics.LogEvent("Selected Mode: " + modeName + " Level Num: " + levelNo + " Level Status: " + levelStatus);
    }
    //public void LogCustomEvent(string modeName,  int CarNo, string CarSkinColor,int levelNo)
    //{
    //    Debug.Log("Selected Mode: " + modeName + " Selected CarNum: " + CarNo + "SelectedCarSkinColor: " + CarSkinColor + " InLevel Num: " + levelNo);
    //    FirebaseAnalytics.LogEvent("Selected Mode: " + modeName + " Selected CarNum: " + CarNo + "SelectedCarSkinColor: " + CarSkinColor + " InLevel Num: " + levelNo);
    //}

}

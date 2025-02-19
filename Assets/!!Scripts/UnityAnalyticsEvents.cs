using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class UnityAnalyticsEvents : MonoBehaviour
{
    void Awake()
    {
        GameStartEvent();
        //DontDestroyOnLoad(this);
    }
    public static void GameStartEvent()
    {
        AnalyticsEvent.GameStart();
    }
    public static void LevelStartEvent(string levelNum)
    {
        AnalyticsEvent.LevelStart(levelNum, new Dictionary<string, object>());
    }
    public static void LevelCompleteEvent(string levelNum)
    {
        AnalyticsEvent.LevelComplete(levelNum, new Dictionary<string, object>());
    }
    public static void LevelFailed(string levelNum)
    {
        AnalyticsEvent.LevelFail(levelNum, new Dictionary<string, object>());
    }
    public static void ScreenVisit(string screenName)
    {
        AnalyticsEvent.ScreenVisit(screenName, new Dictionary<string, object>());
    }
    public static void CustomEvent(string eventName,string eventType,int eventData)
    {
        //  Use this call for wherever a player triggers a custom event
        AnalyticsEvent.Custom(eventName, new Dictionary<string, object> 
        {
            { eventType, eventData }
        });
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using System.Threading.Tasks;
using System;

public class FirebaseManager : MonoBehaviour
{
    public static FirebaseManager Instance;

    public static bool isInitialized = false, isVariablesFetched = false;
    
    public string crossPromotionStoreLink, crossPromotionImageLink;
    public int adsPriority;
    bool isStartInitializeFirebase = false;
    // Start is called before the first frame update
    void Start()
    {
        //Create Singleton Of FirebaseManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        isInitialized = false;
        isVariablesFetched = false;

        //StartCoroutine(InitFirebase());
        //FireBaseInitilization();
    }
    //IEnumerator InitFirebase()
    //{
    //    yield return new WaitUntil(() => AdsManager.isNetConnected);
    //    FireBaseInitilization();
    //}
    private void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            isStartInitializeFirebase = false;
            isInitialized = false;
            isVariablesFetched = false;
        }
        else
        {
            if (isStartInitializeFirebase == false)
            {
                FireBaseInitilization();
                isStartInitializeFirebase = true;
            }
        }
    }

    private void FireBaseInitilization()
    {

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                // Crashlytics will use the DefaultInstance, as well;
                // this ensures that Crashlytics is initialized.
                FirebaseApp app = FirebaseApp.DefaultInstance;


                // Set a flag here for indicating that your project is ready to use Firebase.
                print("Firebase Successfully Initialized...");

                isInitialized = true;
            }
            else
            {
                Debug.LogError(string.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                isInitialized = false;
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

   
    public void LogCustomEvent(string modeName, string levelStatus, int levelNo)
    {
        Debug.Log(modeName + "_" + levelStatus + "_" + levelNo);
        FirebaseAnalytics.LogEvent(modeName + "_" + levelStatus + "_" + levelNo);
    }
    public void LogCustomEvent(string eventName)
    {
        Debug.Log(eventName);
        FirebaseAnalytics.LogEvent(eventName);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    string LoadedScene;
    public GameObject ClearPanel, FailPanel, PausePanel, RateUsPanel;
    public Text LevelText, WinPanelWinCredit, WinPanelWinGold, WinPanelLooseCredit, loosePanelWinCredit, LoosePanelLooseCredit;
    public int StageNumber;
    bool once;
    public int[] Stage1RewardCash, Stage2RewardCash,MPReward;
    public int[] Stage1RewardGold, Stage2RewardGold,MPRewardGold;
    public AudioClip PassSound, FailSound,CoinCollect, hitsound, btnclicksound, reverseSound;
    
    private GameObject CarAi;
    public bool ReplayCheck = false;

    public GameObject controlGamePlay;
    [SerializeField] public Transform Player;
    [SerializeField] public Transform RespawnPlayerCar;

    public static string ModeName;
    public RCC_MobileButtons changeControl;
    public Text showCollisiontext;
    public RCC_Camera RCCCamera;
    public GameObject Cam;
    public GameObject[] stars;

    public GameObject startEngine;
    public GameObject startEngineoff;

    public Text completeCash;
    public Text completeGold;
    AudioSource audio;
    public AudioSource source;
    public GameObject skipPanel;
    public GameObject startbtnfirstanim;
    public GameObject LevelPauseBuyButton;
    public GameObject LevelCompleteBuyButton;  
    public GameObject LevelFailedBuyButton; 

    public Scrollbar gearscrollbar;
    void Start()
    {
        try { 
        instance = this;

        once = true;
        LoadedScene = SceneManager.GetActiveScene().name;
        audio = GetComponent<AudioSource>();
        if (LoadedScene == "MultiPlayerMode")
        {          
            ModeName = "MultiPlayer";
           // FirebaseHandler.Instance.LogCustomEvent(ModeName, (PlayerPrefs.GetInt("MutiPlayerLevels") + 1), "Started");
           // FirebaseHandler.Instance.LogCustomEvent("MultiPlayerMode", 1, PlayerPrefs.GetString("Car_1_Color_"), (PlayerPrefs.GetInt("MutiPlayerLevels")+1));
        }
        if(PlayerPrefs.GetInt("FirstTimePlay") == 1)
        {
            startbtnfirstanim.SetActive(false);
        }
         LevelText.text = "" + (LoadTesting.level + 1);
        if (RCC_Settings.Instance.mobileController != RCC_Settings.MobileController.TouchScreen)
        {
            arrow.SetActive(false);
            steering.SetActive(true);
        }
        else
        {
            arrow.SetActive(true);
            steering.SetActive(false);
        }
        audio.volume = PlayerPrefs.GetFloat("CurVol");
        AudioListener.volume = PlayerPrefs.GetFloat("musicVol");
            if(!AdsManager.Instance.isAdsPurchased)
            {
                AdsManager.Instance.ShowBottomAdaptiveBanner();
            }
    } catch { }
    }
    void Update()
    {
        try {
        if (Player == null) 
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (MterialChanging.GameOver && once)
        {
            once = false;
            RCC_SceneManager.Instance.activePlayerVehicle.canControl = false;
            GameManager.instance.controlGamePlay.SetActive(false);
            MterialChanging.GameOver = false;         
            if (RCCCamera)
            {
                if (RCCCamera.GetComponent<RCC_Camera>())
                    RCCCamera.GetComponent<RCC_Camera>().enabled = false;
                if (RCCCamera.GetComponent<RCC_CameraCarSelection>())
                    RCCCamera.GetComponent<RCC_CameraCarSelection>().enabled = true;


            }
                source.clip = FailSound;
                source.PlayOneShot(FailSound);
            StartCoroutine(WaitFuncFail());
            
           

        }
    } catch { }
        //    if (FinishPoint.LevelClear && once)
        //{



            //    once = false;
            //    UnlockNextLevel();
            //    RCC_SceneManager.Instance.activePlayerVehicle.canControl = false;
            //    RCC_SceneManager.Instance.activePlayerCanvas.controllerButtons.SetActive(false);
            //    FinishPoint.LevelClear = false;
            //    //carDrivebyOwn.instance.StopAllCoroutines();
            //    StartCoroutine(WaitFuncClear());
            //    if (SceneManager.GetActiveScene().name=="GamePlay") {
            //        CreditTextClear.text = Stage1Reward[LoadTesting.level - 1].ToString(); //"" + PlayerPrefs.GetInt("Credits");
            //    }
            //    else if (SceneManager.GetActiveScene().name == "GamePlay2")
            //    {
            //        CreditTextClear.text = Stage2Reward[LoadTesting.level - 1].ToString(); //"" + PlayerPrefs.GetInt("Credits");
            //    }
            //    StageTextClear.text = "Stage " + StageNumber;
            //    LevelTextClear.text = "" + LoadTesting.level;  
            //}
    }
    //////////////////////////////////////////
    ///
    public void PauseButton()
    {
        try { 
            Time.timeScale = 0f;
       // RCC_SceneManager.Instance.activePlayerCanvas.controllerButtons.SetActive(false);
            controlGamePlay.SetActive(false);
            PausePanel.SetActive(true);
            if (PlayerPrefs.GetInt("unlockeverything")== 1)
            {
                LevelPauseBuyButton.SetActive(false);
            }
             audio.Stop();
            if (source.isPlaying)
                source.mute = true;
        }
        catch { }
        try {
            ///AdsManager.Instance.ShowUnity();
            AdsManager.Instance.ShowInterstitial();
        } catch { }
    }
    public void ResumeButton()
    {
        try { 
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        GameManager.instance.controlGamePlay.SetActive(true);
        audio.Play();
            if (source.mute)
                source.mute = false;
        } catch { }
    }

    public void MenuButton()
    {
        try { 
        Time.timeScale = 1;
            //AdsManager.Instance.ShowUnity();
            AdsManager.Instance.ShowInterstitial();
            SceneManager.LoadScene("MainMenu");
        if (!PlayerPrefs.HasKey("megapack")) 
        {
            PlayerPrefs.SetInt("megapack", 1);
        }
    } catch { }
    }

    public void Replay()
    {
        try { 
        Time.timeScale = 1;
        ReplayCheck = true;        
        ClearPanel.SetActive(false);
        FailPanel.SetActive(false);
       // RCC_SceneManager.Instance.activePlayerCanvas.controllerButtons.SetActive(true);
        GameManager.instance.controlGamePlay.SetActive(true);
        carDrivebyOwn.instance.Reset();
    } catch { }
    }
    public void Restart()
    {
        try {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        catch { }
        try {
            //AdsManager.Instance.ShowUnity();
            AdsManager.Instance.ShowInterstitial();
        } catch { }
    }
    public void NextButtonClassic()
    {
        try { 
        Time.timeScale = 1;
        if (LoadedScene == "GamePlay")
        {
                if (LevelSelection.selectedLevel < 19)
                {
                    LevelSelection.selectedLevel += 1;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                else 
                {
                    SceneManager.LoadScene("MainMenu");
                    PlayerPrefs.SetInt("opennextpanel", 1);
                }
        }
            //AdsManager.Instance.ShowUnity();
            AdsManager.Instance.ShowInterstitial();
        } catch { }
    }
    public void NextButtonModern()
    {
        try { 
        Time.timeScale = 1;       
        if (LoadedScene == "GamePlay2")
        {
            if (LevelSelection.selectedLevel < 14)
            {
                LevelSelection.selectedLevel += 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
                    PlayerPrefs.SetInt("opennextpanel2", 1);
            }
        }
        }
        catch { }
        try {
            //AdsManager.Instance.ShowUnity();

            AdsManager.Instance.ShowInterstitial();
        } catch { }
    }
    public void UnlockNextLevel()
    {
        try {
        if (PlayerPrefs.GetInt("Stage_" + MenuManger.selectedstage + "_Level_" + (LoadTesting.instance.totallevel)) != 1)
        {
            PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_" + (LevelSelection.selectedLevel + 1), 1);
        }
    } catch { }
    }
   
    IEnumerator WaitFuncFail()
    {
      
        if (SceneManager.GetActiveScene().name != "MultiPlayerMode")
        {
            if (PlayerPrefs.GetInt("unlockeverything") == 1 || PlayerPrefs.GetInt("UnlockAllLevels")== 1)
            {
                LevelFailedBuyButton.SetActive(false);
            }
            
            yield return new WaitForSeconds(4f);
            FailPanel.SetActive(true);
            FirebaseHandler.Instance.LogCustomEvent(MenuManger.selectedstage, LevelSelection.selectedLevel, "Failed", PlayerPrefs.GetInt("Player"));
        }
    }
    IEnumerator WaitFuncClear()
    {
        if (SceneManager.GetActiveScene().name != "MultiPlayerMode")
        {
            yield return new WaitForSeconds(4f);
            if (LoadTesting.level % 3 == 0 && PlayerPrefs.GetInt("Review") == 0)
            {
                RateUsPanel.SetActive(true);
            }
            else
            {
                ClearPanel.SetActive(true);
                if (PlayerPrefs.GetInt("unlockeverything") == 1 || PlayerPrefs.GetInt("UnlockAllCar") == 1)
                {
                    LevelCompleteBuyButton.SetActive(false);
                }
               
                for (int i= 0; i < TimeStar.instance.countstar; i++)
                {
                    stars[i].SetActive(true);
                }
                if (PlayerPrefs.GetInt("Stage_" + MenuManger.selectedstage + "_Level_" + LevelSelection.selectedLevel + "_Stars") <= TimeStar.instance.countstar)
                {
                    PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_" + LevelSelection.selectedLevel + "_Stars", TimeStar.instance.countstar);
                }
                FirebaseHandler.Instance.LogCustomEvent(MenuManger.selectedstage, LevelSelection.selectedLevel, "Completed", PlayerPrefs.GetInt("Player"));
            }
        }
    
    }
    public void PlayButtonSound()
    {
        try {
            //source.clip = btnclicksound;
            source.PlayOneShot(btnclicksound);
        }
        catch { }
    }
    public void OnPressRateUSButton()
    {
        try { 
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.gameslobby.carparking.driving.game.simulator&hl=en_US");
            RateUsPanel.SetActive(false);
            ClearPanel.SetActive(true);
                if (PlayerPrefs.GetInt("unlockeverything") == 1 || PlayerPrefs.GetInt("UnlockAllCar") == 1)
                {
                    LevelCompleteBuyButton.SetActive(false);
                }
                
                // ClearPanel.GetComponent<Animator>().Play("Exit");
                PlayerPrefs.SetInt("Review", 1);

            for (int i = 0; i < TimeStar.instance.countstar; i++)
            {
                stars[i].SetActive(true);
            }
            if (PlayerPrefs.GetInt("Stage_" + MenuManger.selectedstage + "_Level_" + LevelSelection.selectedLevel + "_Stars") <= TimeStar.instance.countstar)
            {
                PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_" + LevelSelection.selectedLevel + "_Stars", TimeStar.instance.countstar);
            }
        }
        else
        {
            NoInternet.SetActive(true);
            NoInternettext.text = "INTERNET NOT AVAILABLE.";
            //StartCoroutine(noInternetstop(2.0f));
        }
    } catch { }
    }
    public void OnPressLaterButton()
    {
        try { 
        RateUsPanel.SetActive(false);
        ClearPanel.SetActive(true);
            if (PlayerPrefs.GetInt("unlockeverything") == 1 || PlayerPrefs.GetInt("UnlockAllCar") == 1)
            {
                LevelCompleteBuyButton.SetActive(false);
            }
            
            for (int i = 0; i < TimeStar.instance.countstar; i++)
        {
            stars[i].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Stage_" + MenuManger.selectedstage + "_Level_" + LevelSelection.selectedLevel + "_Stars") <= TimeStar.instance.countstar)
        {
   
            PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_" + LevelSelection.selectedLevel + "_Stars", TimeStar.instance.countstar);
        }
    } catch { }
    }
    public void SkipButton()
    {
        try {

            if (Application.internetReachability != NetworkReachability.NotReachable)
            {

                if (AdsManager.Instance.isAdmobRewardedReady())
                {
                    AdsManager.Instance.ShowAdmobRewardedAd();
                }
                else
                {
                    NoInternet.SetActive(true);
                    NoInternettext.text = "REWARD NOT AVAILABLE THIS TIME.";
                    // StartCoroutine(noInternetstop(2.0f));
                }

            }
            else
            {
                NoInternet.SetActive(true);
                NoInternettext.text = "INTERNET NOT AVAILABLE.";
                // StartCoroutine(noInternetstop(2.0f));
            }
    } catch { }

    }
    public void Skipped() 
    {
        try {
        Time.timeScale = 1;
        FinishPoint.LevelClear = true;
        UnlockNextLevel();
            if (LevelSelection.selectedLevel < LoadTesting.instance.totallevel)
            {
                LevelSelection.selectedLevel += 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        catch { }
    }

    public void FinalStar1()
    {
        try {
        // Debug.LogError("ddd"+ PlayerCarScript.instance.CollectStarsCount);
        if (PlayerCarScript.instance.CollectStarsCount <= 3)
        {

            for (int i = 0; i <= PlayerCarScript.instance.CollectStarsCount - 1; i++)
            {
                MultiplayerLevelSelection.instance.PlayerWinPanelStar[i].SetActive(true);
                print("Player WinCar " + PlayerCarScript.instance.CollectStarsCount);
            }
            for (int i = 0; i <= StarManager.instance.CollectStarsCount - 1; i++)
            {
                MultiplayerLevelSelection.instance.OppWinPanelStars[i].SetActive(true);
                print("AICarLoose " + StarManager.instance.CollectStarsCount);
            }
        }
    } catch { }
    }

    public void FinalStar()
    {
        try { 
        Invoke("FinalStar1",.5f);
    } catch { }
    }
    public void FailPanelStars()
    {
        try { 
        Invoke("FiledAfterOneSec",.5f);
    } catch { }
    }
    void FiledAfterOneSec()
    {
        try {

        if (StarManager.instance.CollectStarsCount >= 3)
        {


            for (int i = 0; i <= StarManager.instance.CollectStarsCount - 1; i++)
            {
                MultiplayerLevelSelection.instance.OppLoosePanelStars[i].SetActive(true);
                print("AICar Winner" + StarManager.instance.CollectStarsCount);
            }
            for (int i = 0; i <= PlayerCarScript.instance.CollectStarsCount - 1; i++)
            {
                MultiplayerLevelSelection.instance.PlayerLoosePanelStars[i].SetActive(true);
                print("Player Loose " + PlayerCarScript.instance.CollectStarsCount);
            }


        }
    } catch { }
    }
        public void CoinSound()
    {
        try {
            source.clip = CoinCollect;
            source.PlayOneShot(CoinCollect,1f);
        }
        catch { }
    }   
    public void LevelWinsound()
    {
        try {
            audio.volume = 0.2f;
            source.clip = PassSound;
            source.PlayOneShot(PassSound);
    } catch { }
    }
    public void Hitsound()
    {
        try {
            source.clip = hitsound;
            source.PlayOneShot(hitsound);
    } catch { }
    }    
    public void LevelComplete() 
    {
        try {
            if (PlayerPrefs.GetInt("unlockeverything") == 1 || PlayerPrefs.GetInt("UnlockAllCar")== 1)
            {
                    LevelCompleteBuyButton.SetActive(false);
            }
            {
                LevelCompleteBuyButton.SetActive(true);
            }
            if (FinishPoint.LevelClear && once)
        {

            once = false;
            UnlockNextLevel();
           // RCC_SceneManager.Instance.activePlayerVehicle.canControl = false;
            GameManager.instance.controlGamePlay.SetActive(false);
            FinishPoint.LevelClear = false;
            //carDrivebyOwn.instance.StopAllCoroutines();
            StartCoroutine(WaitFuncClear());
                if (SceneManager.GetActiveScene().name == "GamePlay")
                {
                    completeCash.text = (Stage1RewardCash[LevelSelection.selectedLevel]).ToString();
                    completeGold.text = (Stage1RewardGold[LevelSelection.selectedLevel]).ToString();
                    PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + Stage1RewardCash[LevelSelection.selectedLevel]);
                    PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + Stage1RewardGold[LevelSelection.selectedLevel]);
                }
                else if (SceneManager.GetActiveScene().name == "GamePlay2")
                {
                    completeCash.text = (Stage2RewardCash[LevelSelection.selectedLevel]).ToString();
                    completeGold.text = (Stage2RewardGold[LevelSelection.selectedLevel]).ToString();
                    PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + Stage2RewardCash[LevelSelection.selectedLevel]);
                    PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + Stage2RewardGold[LevelSelection.selectedLevel]);
                }
                

            }
        }
        catch { }
    }
    public GameObject arrow;
    public GameObject steering;

    public void SwitchControl() 
    {
        try { 
        if (RCC_Settings.Instance.mobileController != RCC_Settings.MobileController.TouchScreen) 
        {
            RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.TouchScreen;
            arrow.SetActive(true);
            steering.SetActive(false);
        }
        else 
        {
            RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.SteeringWheel;
            arrow.SetActive(false);
            steering.SetActive(true);
        }
    } catch { }
    }
    public GameObject NoInternet;
    public Text NoInternettext;
    public void DoubleCash() 
    {
        try {
            if (Application.internetReachability != NetworkReachability.NotReachable)
            {
                if (AdsManager.Instance.isAdmobRewardedReady())
                {
                    AdsManager.Instance.ShowAdmobRewardedAd();
                }
                else
                {
                    NoInternet.SetActive(true);
                    NoInternettext.text = "REWARD NOT AVAILABLE THIS TIME.";
                    //StartCoroutine(noInternetstop(2.0f));
                }

            }
            else
            {
                NoInternet.SetActive(true);
                NoInternettext.text = "INTERNET NOT AVAILABLE.";
                // StartCoroutine(noInternetstop(2.0f));
            }
    } catch { }
    }
    //IEnumerator noInternetstop(float timer)
    //{
    //    yield return new WaitForSecondsRealtime(timer);
    //    NoInternet.SetActive(false);
    //}
    public void GivenCashDouble() 
    {
        try { 
        PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + (Stage2RewardCash[LevelSelection.selectedLevel] * 2));
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + (Stage2RewardGold[LevelSelection.selectedLevel] * 2));
        }
        catch { }
    }

    public void skipedLevel() 
    {
        
        if (skipPanel.activeInHierarchy)
        {
            Cam_Move_Anim.instance.stopCam();
        }
  
    }
   
    public void FirstTimePlay() 
    {
        try { 
        PlayerPrefs.SetInt("FirstTimePlay", 1);
    } catch { }
    }

    public void unlockallcars() 
    {
        try { 
        MenuManger.Instance.UnlockVehicles();
    } catch { }
    }
    public void unlockall()
    {
        try { 
               MenuManger.Instance.UnlockAll();
    } catch { }
    }
    public void unlockallLevels()
    {
        try { 
        for (int i=0; i < LevelSelection.instance.stages[MenuManger.selectedstage - 1].levels.Length; i++)
            PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i, 1);

            PlayerPrefs.SetInt("UnlockAllLevels", 1);
        }
        catch { }
    }

    public void changeGear() 
    {
        try { 

        if (Player.GetComponent<RCC_CarControllerV3>().direction == 1)
        {
            StartCoroutine(Player.GetComponent<RCC_CarControllerV3>().ChangeGear(-1));
            gearscrollbar.value = 1;
            
        }

        else 
        {
            StartCoroutine(Player.GetComponent<RCC_CarControllerV3>().ChangeGear(1));
            gearscrollbar.value = 0;
        }
        }
        catch { }
    }
}

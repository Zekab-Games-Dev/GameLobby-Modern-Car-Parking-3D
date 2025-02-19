using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    public static bool LevelClear;
    public bool WinPanel = false;
    public bool LoosePanel = false;
    bool once = false;
    public AudioClip PassSound;
    public GameObject fX1;
    public GameObject fX2;
    // Use this for initialization
    void Start()
    {
        LevelClear = false;
    }
    bool triggered = false;
    public int AsignReward()
    {
        int rew = 0;
        triggered = true;
        int rewardIndex = 0;
        for (int level = 0; level < MultiplayerLevelSelection.instance.TotalLevels.Length; level++)
        {
            if (MultiplayerLevelSelection.instance.TotalLevels[level].activeSelf)
            {
                rewardIndex = level;
            }
        }
        rew = GameManager.instance.MPReward[rewardIndex];
        return rew;
    }


    private void OnTriggerEnter(Collider other)
    {
        int rewardIndex = 0;
        if (SceneManager.GetActiveScene().name == "MultiPlayerMode")
        {
            for (int level = 0; level < MultiplayerLevelSelection.instance.TotalLevels.Length; level++)
            {
                if (MultiplayerLevelSelection.instance.TotalLevels[level].activeSelf)
                {
                    rewardIndex = level;
                }
            }
        }

        once = true;
        if ( other.gameObject.tag == "RedAICAr" && GameManager.instance.Player.gameObject.GetComponent<PlayerCarScript>().CollectStarsCount == 3)
        {
            WinPanel = true;
            GameManager.instance.LevelWinsound();
            GameManager.instance.ClearPanel.SetActive(true);
            GameManager.instance.FinalStar();
            //PlayerPrefs.SetInt("MPCredits", PlayerPrefs.GetInt("MPCredits") + AsignReward());
            //GameManager.instance.WinPanelWinCredit.text = "" + PlayerPrefs.GetInt("MPCredits"); //Credit
            //PlayerPrefs.SetInt("MPLooserCredit", PlayerPrefs.GetInt("MPLooserCredit") + Mathf.RoundToInt(AsignReward() * 0.2f));
            //GameManager.instance.WinPanelLooseCredit.text = "" + PlayerPrefs.GetInt("MPLooserCredit"); //Credit
            carDrivebyOwn.instance.isBraking = true;
            carDrivebyOwn.instance.isDriving = false;
            carDrivebyOwn.instance.currentSpeed = 0;
            RCC_SceneManager.Instance.activePlayerVehicle.canControl = false;

            return;
        }

        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name == "MultiPlayerMode")
            {
                WinPanel = true;
                GameManager.instance.LevelWinsound();
                GameManager.instance.ClearPanel.SetActive(true);
                GameManager.instance.FinalStar();
                if (!triggered)
                {
                    triggered = true;
                    PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + AsignReward());
                    PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + GameManager.instance.MPRewardGold[rewardIndex]);
                }
                GameManager.instance.WinPanelWinCredit.text = "" + GameManager.instance.MPReward[rewardIndex];
                GameManager.instance.WinPanelWinGold.text = "" + GameManager.instance.MPRewardGold[rewardIndex];
                int re =  Mathf.RoundToInt(AsignReward() );
                if (StarManager.instance.CollectStarsCount == 0)
                {
                    re = Mathf.RoundToInt(re * .1f);
                }
                else if (StarManager.instance.CollectStarsCount==1)
                {
                    re = Mathf.RoundToInt(re * .15f);
                }
                else if (StarManager.instance.CollectStarsCount == 2)
                {
                    re = Mathf.RoundToInt(re * .25f);
                }
                else if (StarManager.instance.CollectStarsCount == 3)
                {
                    re = Mathf.RoundToInt(re * 0.3f);
                }
               //  PlayerPrefs.SetInt("Credits", re);
                GameManager.instance.WinPanelLooseCredit.text = re.ToString(); //Credit
                RCC_SceneManager.Instance.activePlayerVehicle.canControl = false;
                carDrivebyOwn.instance.isBraking = true;
                carDrivebyOwn.instance.isDriving = false;
                carDrivebyOwn.instance.currentSpeed = 0;
                PlayerPrefs.SetInt("MutiPlayerLevels", PlayerPrefs.GetInt("MutiPlayerLevels") + 1);
                // FirebaseHandler.Instance.LogCustomEvent(GameManager.ModeName, (PlayerPrefs.GetInt("MutiPlayerLevels") + 1), "PlayerWin");

            }
            else if (SceneManager.GetActiveScene().name == "GamePlay" || SceneManager.GetActiveScene().name == "GamePlay2")
            {
                LevelClear = true;
                TimeStar.instance.counter = true;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                if(fX1 !=null && fX2 != null)
                {
                    fX1.SetActive(true);
                    fX2.SetActive(true);
                }
                GameManager.instance.LevelWinsound();
                if (GameManager.instance.RCCCamera)
                {
                    if (GameManager.instance.RCCCamera.GetComponent<RCC_Camera>())
                        GameManager.instance.RCCCamera.GetComponent<RCC_Camera>().enabled = false;
                    if (GameManager.instance.RCCCamera.GetComponent<RCC_CameraCarSelection>())
                        GameManager.instance.RCCCamera.GetComponent<RCC_CameraCarSelection>().enabled = true;
                   

                }
                GameManager.instance.LevelComplete();
              //  FirebaseHandler.Instance.LogCustomEvent(GameManager.ModeName, LoadTesting.level, "Completed");
            }
        }
        if (other.gameObject.tag == "RedAICAr")
        {
            LoosePanel = true;
            GameManager.instance.LevelWinsound();
            GameManager.instance.FailPanel.SetActive(true);
            GameManager.instance.FailPanelStars();
            PlayerPrefs.SetInt("MPLooserCredit", PlayerPrefs.GetInt("MPLooserCredit") + AsignReward());
            
            GameManager.instance.loosePanelWinCredit.text = "" +GameManager.instance.MPReward[rewardIndex];

            int re=Mathf.RoundToInt(AsignReward());
            if (PlayerCarScript.instance.CollectStarsCount == 0)
            {
                re = Mathf.RoundToInt(re * .1f);

             

            }
            else if (PlayerCarScript.instance.CollectStarsCount == 1)
            {
                re = Mathf.RoundToInt(re * .15f);
           
            }
            else if (PlayerCarScript.instance.CollectStarsCount == 2)
            {
                re = Mathf.RoundToInt(re * .25f);
              
            }
            //else if (PlayerCarScript.instance.CollectStarsCount == 3)
            //{
            //    re = Mathf.RoundToInt(re * 0.3f);

            //}
            PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits") + re);
            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + re);
            //PlayerPrefs.SetInt("Credits", re);
            GameManager.instance.LoosePanelLooseCredit.text = "" + re; //Credit
            //if (!triggered)
            //{
            //    triggered = true;
            //    PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + AsignReward());
            //    PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + GameManager.instance.MPRewardGold[rewardIndex]);
            //}

            RCC_SceneManager.Instance.activePlayerVehicle.canControl = false;
           // FirebaseHandler.Instance.LogCustomEvent(GameManager.ModeName, (PlayerPrefs.GetInt("MutiPlayerLevels")+1), "PlayerLose");

        }

        if (GameManager.instance.ReplayCheck == true)
        {
            if (other.gameObject.tag == "Player")
            {
               // RCC_SceneManager.Instance.activePlayerCanvas.controllerButtons.SetActive(false);
                GameManager.instance.controlGamePlay.SetActive(false);
                GameManager.instance.ClearPanel.SetActive(true);
            }
        }
    }
}
      
    


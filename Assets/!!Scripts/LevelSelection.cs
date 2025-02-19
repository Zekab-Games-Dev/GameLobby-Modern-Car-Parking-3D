using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    public StageInfo[] stages;

    public static LevelSelection instance;
    public bool Stage3, MultiPlayer;
    int temp;
    public GameObject LoadingScreen;
    public static string SceneName;
    public int count;
    private void Awake()
    {

        LevelUnlocking();
    }
    void Start()
    {
        try
        {
            instance = this;

            for (int i = 1; i <= stages.Length; i++)
            {
                if (PlayerPrefs.HasKey("Stage_" + i + "_UnlockAll") == false)
                {
                    PlayerPrefs.SetInt("Stage_" + 1 + "_UnlockAll", 0);
                }
            }
            if (PlayerPrefs.GetInt("Stage_" + 1 + "_UnlockAll") == 1 && PlayerPrefs.GetInt("Stage_" + 2 + "_UnlockAll") == 1)
            {
                MenuManger.Instance.levelbtn.interactable = false;
            }
            
        }
        catch { }
    }

    public static int selectedLevel = 0;
    public static float[] currentLevelStarsTime;
    public void OnPressButton(int a)
    {
        try
        {
            selectedLevel = a;
            if (MenuManger.selectedstage == 1)
            {
                LoadingScreen.SetActive(true);
                SceneName = "GamePlay";
            }
            if (MenuManger.selectedstage == 2)
            {

                LoadingScreen.SetActive(true);
                SceneName = "GamePlay2";
            }
            if (Stage3)
            {
                temp = PlayerPrefs.GetInt("Level3");
            }
        }
        catch { }
        try
        {
            //AdsManager.Instance.ShowInterstitial();
            if (!AdsManager.Instance.isAdsPurchased)
            {
                AdsManager.Instance.ShowInterstitial();
            }
        }
        catch { }
    }
    public void LevelUnlocking()
    {
        try { 
        if (Stage3)
        {
            temp = PlayerPrefs.GetInt("Level3");
           // StageText.text = "Stage 3";
        }
        }
        catch { }

    }
    public void Selection ()
    {
        try {

            set_Scroll_val();

        if (PlayerPrefs.GetInt("Stage_" + 1 + "_UnlockAll") == 1)
        {
            MenuManger.Instance.levelbtnclassic.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Stage_" + 2 + "_UnlockAll") == 1)
        {
            MenuManger.Instance.levelbtnmodern.SetActive(false);
        }

        for (int i = 0; i < stages[MenuManger.selectedstage - 1].levels.Length; i++)
        {
            if (!PlayerPrefs.HasKey("Stage_" + MenuManger.selectedstage + "_Level_" + i))
            {
                if (i == 0)
                {
                    PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i, 1);
                    if(!PlayerPrefs.HasKey("Stage_" + MenuManger.selectedstage + "_Level_"+ i +"_Stars"))
                    {
                        PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i + "_Stars", 0);
                    }
                    if (!PlayerPrefs.HasKey("Stage_" + MenuManger.selectedstage + "_Level_progress"))
                    {
                        PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_progress", 0);
                    }
                    stages[MenuManger.selectedstage - 1].levels[i].levelButtton.interactable = true;
                    stages[MenuManger.selectedstage - 1].levels[i].levelLock.SetActive(false);
                    int starsCount = PlayerPrefs.GetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i + "_Stars");
                    for (int j = 0; j < starsCount; j++)
                    {
                        stages[MenuManger.selectedstage - 1].levels[i].stars[j].SetActive(true);
                    }
                    currentLevelStarsTime = stages[MenuManger.selectedstage - 1].levels[i].starsTime;
                }
                else
                {
                    PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i, 0);
                    if (!PlayerPrefs.HasKey("Stage_" + MenuManger.selectedstage + "_Level_" + i + "_Stars"))
                    {
                        PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i + "_Stars", 0);
                    }
                    if (!PlayerPrefs.HasKey("Stage_" + MenuManger.selectedstage + "_Level_progress"))
                    {
                        PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_progress", 0);
                    }
                    stages[MenuManger.selectedstage - 1].levels[i].levelButtton.interactable = false;
                    stages[MenuManger.selectedstage - 1].levels[i].levelLock.SetActive(true);
                }
            }
            else
            {
                if(PlayerPrefs.GetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i)==1)
                {
                    stages[MenuManger.selectedstage - 1].levels[i].levelButtton.interactable = true;
                    stages[MenuManger.selectedstage - 1].levels[i].levelLock.SetActive(false);
                    int starsCount = PlayerPrefs.GetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i + "_Stars");
                    for (int j = 0; j < starsCount; j++)
                    {
                        stages[MenuManger.selectedstage - 1].levels[i].stars[j].SetActive(true);
                    }
                    stages[MenuManger.selectedstage - 1].levels[i].levelHitInfo.enabled = true;
                    stages[MenuManger.selectedstage - 1].levels[i].levelHitInfo.text = PlayerPrefs.GetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i + "_Hits").ToString();
                    currentLevelStarsTime = stages[MenuManger.selectedstage - 1].levels[i].starsTime;
                }
                else
                {
                    stages[MenuManger.selectedstage - 1].levels[i].levelButtton.interactable = false;
                    stages[MenuManger.selectedstage - 1].levels[i].levelLock.SetActive(true);
                    stages[MenuManger.selectedstage - 1].levels[i].levelHitInfo.enabled = false;
                }
                //print(selectedLevel);
                //count++;
               // stages[MenuManger.selectedstage - 1].levelprogress.text = ((selectedLevel / 15) * 100) + "%".ToString();
            }

        }
        }
        catch { }

    }
    public void UnLockAllCurrentStageLevels()
    {
        try
        {
            for (int i = 0; i < stages[MenuManger.selectedstage - 1].levels.Length; i++)
            {
                stages[MenuManger.selectedstage - 1].levels[i].levelButtton.interactable = true;
                stages[MenuManger.selectedstage - 1].levels[i].levelLock.SetActive(false);
                int starsCount = PlayerPrefs.GetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i + "_Stars");
                for (int j = 0; j < starsCount; j++)
                {
                    stages[MenuManger.selectedstage - 1].levels[i].stars[j].SetActive(true);
                }
                stages[MenuManger.selectedstage - 1].levels[i].levelHitInfo.enabled = true;
                stages[MenuManger.selectedstage - 1].levels[i].levelHitInfo.text = PlayerPrefs.GetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i + "_Hits").ToString();
                PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i, 1);
                
            }
            PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_UnlockAll", 1);
            if (MenuManger.selectedstage == 1)
            {
                MenuManger.Instance.unlockModernMode.SetActive(false);
                MenuManger.Instance.levelbtnclassic.SetActive(false);
            }
            else if (MenuManger.selectedstage == 2) 
            {
                MenuManger.Instance.unlockMultiplayerMode.SetActive(false);
                MenuManger.Instance.levelbtnmodern.SetActive(false);
            }
           

        }
        catch
        {

        }
    }
    public void UnLockAllLevels()
    {
        try
        {
            for (int i = 0; i < stages.Length; i++)
            {
                for (int j = 0; j < stages[i].levels.Length; j++)
                {
                    stages[i].levels[j].levelButtton.interactable = true;
                    stages[i].levels[j].levelLock.SetActive(false);
                    int starsCount = PlayerPrefs.GetInt("Stage_" + (i+1) + "_Level_" + j + "_Stars");
                    for (int k = 0; k < starsCount; k++)
                    {
                        stages[i].levels[j].stars[k].SetActive(true);
                    }
                    stages[i].levels[j].levelHitInfo.enabled = true;
                    stages[i].levels[j].levelHitInfo.text = PlayerPrefs.GetInt("Stage_" + (i+1) + "_Level_" + j + "_Hits").ToString();
                    PlayerPrefs.SetInt("Stage_" + (i+1) + "_Level_" + j, 1);

                }
                PlayerPrefs.SetInt("Stage_" + (i+1)+ "_UnlockAll", 1);

            }

            MenuManger.Instance.levelbtn.interactable = false;

        }
        catch
        {

        }
    }

    void set_Scroll_val()
    {
        try
        {
            int counter = 0;

            for (int i = 0; i < stages[MenuManger.selectedstage-1].levels.Length; i++)
            {

                if (PlayerPrefs.GetInt("Stage_" + MenuManger.selectedstage + "_Level_" + i) == 1)
                {
                    counter++;
                }
            }
            Debug.Log(counter);
            if (counter > 0 && counter <= 4)
            {
                stages[MenuManger.selectedstage - 1].scroll_Object.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(3244.75f, 0.0f);
            }
            else if (counter >= 5 && counter <= 8)
            {
                stages[MenuManger.selectedstage - 1].scroll_Object.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(1640.661f, 0.0f);
            }
            else if (counter >= 9 && counter <= 12)
            {
                stages[MenuManger.selectedstage - 1].scroll_Object.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-31.08588f, 0.0f);
            }
            else if (counter >= 13 && counter <= 15)
            {
                stages[MenuManger.selectedstage - 1].scroll_Object.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1653.388f, 0.0f);
            }
            else if (counter >= 16 && counter <= 20)
            {
                stages[MenuManger.selectedstage - 1].scroll_Object.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-2982.195f, 0.0f);
            }
        }
        catch { }

    }
   
}
[System.Serializable]
public class StageInfo
{
    public string stageNum;
    public GameObject scroll_Object;
    public LevelInfo[] levels;
   // public Text levelprogress;
}
[System.Serializable]
public class LevelInfo
{
    public string levelNum;
    public Button levelButtton;
    public GameObject levelLock;
    public GameObject[] stars;
    public float[] starsTime;
    public Text levelHitInfo;
    
}


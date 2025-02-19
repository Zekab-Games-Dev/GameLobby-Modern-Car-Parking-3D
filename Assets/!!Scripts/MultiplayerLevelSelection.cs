using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiplayerLevelSelection : MonoBehaviour         //Daniyal
{
    public static MultiplayerLevelSelection instance;
    public GameObject[] TotalLevels;
    public GameObject[] PlayerWinPanelStar, OppWinPanelStars, PlayerLoosePanelStars, OppLoosePanelStars;
    public GameObject LoadingCanvas, WinPanelBox, LooseBoximg, OppWinImgBox, OppLooseImgBox;
    public Text WinTextBox, LooseTextBox;
    public Text OppWinText, OppLooseText;
    public Sprite[] Images = new Sprite[8];
    public Sprite[] OppImages = new Sprite[7];
    public GameObject[] Players;
    public GameObject[] leveltransform;
    public GameObject nextpanel;
    int i = 0;
    void Start()
    {
        try { 
        //PlayerPrefs.SetInt("MutiPlayerLevels",22);
        //Debug.Log("lEVEL " + PlayerPrefs.GetInt("MutiPlayerLevels", 0));
        i = PlayerPrefs.GetInt("Player", 0);
        Players[i].SetActive(true);
        Players[i].transform.position = leveltransform[PlayerPrefs.GetInt("MutiPlayerLevels", 0)].transform.position;
        Players[i].transform.rotation = leveltransform[PlayerPrefs.GetInt("MutiPlayerLevels", 0)].transform.rotation;
        instance = this;
        LoadLevels();
        Win_LoosePic();
        }
        catch { }
    }
   

    public void LoadLevels()
    {
        try { 
            int randIndex = Random.Range(0, 15);
            for (int i = 0; i < TotalLevels.Length; i++)
            {
                if (PlayerPrefs.GetInt("MutiPlayerLevels", 0) <= 15)
                {
                    if (i == PlayerPrefs.GetInt("MutiPlayerLevels", 0))
                    {
                        TotalLevels[i].SetActive(true);
                        GameManager.instance.Player = FindObjectOfType<PlayerCarScript>().transform;
                    }
                    else
                    {
                        TotalLevels[i].SetActive(false);
                    }
                }
                else
                {
                    if (i == randIndex)
                    {
                        TotalLevels[i].SetActive(true);
                        GameManager.instance.Player = FindObjectOfType<PlayerCarScript>().transform;
                }
                    else
                    {
                        TotalLevels[i].SetActive(false);
                    }
                }
            }
        }
        catch { }
    }
    
    public void OnNext()
    {
        try {
            //AdsIds.Instance.UnityAdmob();
            //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            GameManager.instance.ClearPanel.SetActive(true);
            nextpanel.SetActive(true);
        Time.timeScale = 1;
       // if (PlayerPrefs.GetInt("MutiPlayerLevels") <= 15)
       // {
            //PlayerPrefs.SetInt("MutiPlayerLevels", PlayerPrefs.GetInt("MutiPlayerLevels") + 1);
       // }
        FirebaseHandler.Instance.LogCustomEvent(3, PlayerPrefs.GetInt("MutiPlayerLevels"), "Completed", PlayerPrefs.GetInt("Player"));
        }
        catch { }
    }
    public void Win_LoosePic()
    {
        try { 
        WinPanelBox.GetComponent<Image>().sprite = Images[PlayerPrefs.GetInt("avatar")];   // Win Panel images && Names
        LooseBoximg.GetComponent<Image>().sprite = Images[PlayerPrefs.GetInt("avatar")];
        WinTextBox.text = PlayerPrefs.GetString("username");
        LooseTextBox.text = PlayerPrefs.GetString("username");

        OppWinImgBox.GetComponent<Image>().sprite = OppImages[PlayerPrefs.GetInt("OpponentImg")];    // OpponentWin Panel images && Names
        OppLooseImgBox.GetComponent<Image>().sprite = OppImages[PlayerPrefs.GetInt("OpponentImg")];
        OppWinText.text = PlayerPrefs.GetString("OpponentName");
        OppLooseText.text = PlayerPrefs.GetString("OpponentName");
        }
        catch { }
    }
    IEnumerator LevelLoad(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            yield return null;
        }
    }

    public void BackToMainMenu()
    {
        try { 
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
            //AdsManager.Instance.ShowUnity();
            AdsManager.Instance.ShowInterstitial();
        }
        catch { }
    }
    public void OnRestart()
    {
        try { 
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        catch { }
    }

}

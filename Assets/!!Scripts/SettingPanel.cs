using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    public GameObject Music, SteeringLargeSelected, SteeringMediumSelected, SteeringSmallSelected,SoundOn,SoundOff,MusicOn,MusicOff;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioListener.volume = 1.0f;
            SoundOff.SetActive(true);
            SoundOn.SetActive(false);
        }
        else
        {
            SoundOff.SetActive(false);
            SoundOn.SetActive(true);
            AudioListener.volume = 0.0f;

        }
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            MusicOff.SetActive(true);
            MusicOn.SetActive(false);
            Music.SetActive(true);
        }
        else
        {
            MusicOff.SetActive(false);
            MusicOn.SetActive(true);
            Music.SetActive(false);
            //GarageMusic.SetActive(false);
        }
        if (PlayerPrefs.GetString("Steering") == "Medium")
        {
            SteeringLargeSelected.SetActive(false);
            SteeringMediumSelected.SetActive(true);
            SteeringSmallSelected.SetActive(false);
        }
        if (PlayerPrefs.GetString("Steering") == "Large")
        {
            SteeringLargeSelected.SetActive(true);
            SteeringMediumSelected.SetActive(false);
            SteeringSmallSelected.SetActive(false);
        }
        if (PlayerPrefs.GetString("Steering") == "Small")
        {
            SteeringLargeSelected.SetActive(false);
            SteeringMediumSelected.SetActive(false);
            SteeringSmallSelected.SetActive(true);
        }
    }

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {

    }

    /////////////////////////////////////////////////////
    ///
    public void OnPressSoundOnButton()
    {
        PlayerPrefs.SetInt("Sound", 1);
        //settings.SFXVolume = 1;
        //settings.MusicVolume = 0.7f;
        //Camera.GetComponent<AudioListener>().enabled = true;
        AudioListener.volume = 1.0f;
    }
    public void OnPressSoundOffButton()
    {
        PlayerPrefs.SetInt("Sound", 0);
        //settings.SFXVolume = 0;
        //settings.MusicVolume = 0f;
        AudioListener.volume = 0.0f;
    }
    public void OnPressMusicOnButton()
    {
        PlayerPrefs.SetInt("Music", 1);
        //settings.MusicVolume = 0.7f;
        Music.SetActive(true);
    }
    public void OnPressMusicOffButton()
    {
        PlayerPrefs.SetInt("Music", 0);
        //settings.MusicVolume = 0f;
        Music.SetActive(false);
        //GarageMusic.SetActive(false);
    }
    //public void OnPressSteeringLargeButton()
    //{
    //    PlayerPrefs.SetString("Steering", "Large");
    //    SteeringLargeSelected.SetActive(true);
    //    SteeringMediumSelected.SetActive(false);
    //    SteeringSmallSelected.SetActive(false);
    //    if (RCC_SceneManager.Instance.activePlayerCanvas)
    //    {
    //       // RCC_SceneManager.Instance.activePlayerCanvas.gameObject.GetComponent<RCC_MobileButtons>().steeringWheel.steeringWheelRect.localScale = new Vector2(1.25f, 1.25f);
    //        //RCC_SceneManager.Instance.activePlayerCanvas.gameObject.GetComponent<RCC_MobileButtons>().steeringWheel.steeringWheelRect.sizeDelta = new Vector2(550f, 550f);

    //    }
    //}
    //public void OnPressSteeringMediumButton()
    //{
    //    PlayerPrefs.SetString("Steering", "Medium");
    //    SteeringLargeSelected.SetActive(false);
    //    SteeringMediumSelected.SetActive(true);
    //    SteeringSmallSelected.SetActive(false);
    //    if (RCC_SceneManager.Instance.activePlayerCanvas)
    //    {
    //        RCC_SceneManager.Instance.activePlayerCanvas.gameObject.GetComponent<RCC_MobileButtons>().steeringWheel.steeringWheelRect.localScale = new Vector2(1f, 1f);
    //    }
    //}
    //public void OnPressSteeringSmallButton()
    //{
    //    PlayerPrefs.SetString("Steering", "Small");
    //    SteeringLargeSelected.SetActive(false);
    //    SteeringMediumSelected.SetActive(false);
    //    SteeringSmallSelected.SetActive(true);
    //    if (RCC_SceneManager.Instance.activePlayerCanvas)
    //    {
    //        RCC_SceneManager.Instance.activePlayerCanvas.gameObject.GetComponent<RCC_MobileButtons>().steeringWheel.steeringWheelRect.localScale = new Vector2(0.75f, 0.75f);
    //    }
    //}
}

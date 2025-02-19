using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScripts : MonoBehaviour
{
    public GameObject FireWorks1, FireWorks2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClosePanelEvent()
    {
        this.gameObject.SetActive(false);
    }
    public void DisableBack()
    {
        //this.gameObject.GetComponent<LevelSelection>().BackButton.GetComponent<Button>().interactable = false;
        //this.gameObject.GetComponent<LevelSelection>().InAppButton.GetComponent<Button>().interactable = false;
        //this.gameObject.GetComponent<LevelSelection>().InAppButton1.GetComponent<Button>().interactable = false;
    }
    public void EnableBack()
    {
        //this.gameObject.GetComponent<LevelSelection>().BackButton.GetComponent<Button>().interactable = true;
        //this.gameObject.GetComponent<LevelSelection>().InAppButton.GetComponent<Button>().interactable = true;
        //this.gameObject.GetComponent<LevelSelection>().InAppButton1.GetComponent<Button>().interactable = true;
    }
    public void EnableParticles()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void EnableBox()
    {
        //this.gameObject.GetComponent<InApp>().Box.SetActive(true);
    }
    public void SetTimeZero()
    {
        Time.timeScale = 0;
    }
    public void SetTimeOne()
    {
        Time.timeScale = 1;
    }
    //public void PlayButtonSound(AudioClip sound)
    //{
    //    MenuManger.Instance.GetComponent<AudioSource>().PlayOneShot(sound);
    //}
    public void HideInappFailPnel()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
        //if (MenuManger.Instance.Garage1.activeInHierarchy)
        //{
        //    MenuManger.Instance.Car1.SetActive(true);

        //}
        //if (MenuManger.Instance.Garage2.activeInHierarchy)
        //{
        //    MenuManger.Instance.Car2.SetActive(true);
        //}
    }
    public void HideStage2ClearPanel()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
    public void Stage2ClearFire()
    {
        FireWorks1.SetActive(true);
        FireWorks2.SetActive(true);
    }

}

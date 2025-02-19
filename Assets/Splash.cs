using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject splash;
    public GameObject userinfo;
    void Start()
    {
        StartCoroutine(SplashStart());
       // splash.transform.GetChild(0).set
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SplashStart()
    {
        yield return new WaitForSecondsRealtime(10f);
        if (PlayerPrefs.GetInt("userInformation") != 1)
        {
            userinfo.SetActive(true);
            splash.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

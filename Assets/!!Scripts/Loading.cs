using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    //AsyncOperation asyncOperation;
    //public GameObject LoadingBar;
    public Image loadingImage;
        // Start is called before the first frame update
    void Start()
    {
      // StartCoroutine(LoadingScreen(LevelSelection.SceneName));
    }

    // Update is called once per frame
    void Update()
    {
        if (loadingImage.fillAmount != 1)
        {
            loadingImage.fillAmount += Time.deltaTime * 0.3f;
            if (loadingImage.fillAmount == 1)
            {
                LoadingScreen(LevelSelection.SceneName);
            }
        }
    }
        void LoadingScreen(string _scene)
        {
           SceneManager.LoadSceneAsync(_scene);

        }
        //IEnumerator LoadingScreen(string _scene)
        //{
        //    yield return new WaitForSeconds(1f);
        //    asyncOperation = SceneManager.LoadSceneAsync(_scene);
        //    while (!asyncOperation.isDone)
        //    {
        //        LoadingBar.GetComponent<Image>().fillAmount = asyncOperation.progress + 0.1f;

        //        yield return null;
        //    }

        //}
    }

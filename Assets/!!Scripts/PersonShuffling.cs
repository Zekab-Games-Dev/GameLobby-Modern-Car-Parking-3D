using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PersonShuffling : MonoBehaviour
{
    public static PersonShuffling instance;
    public Sprite[] sprites = new Sprite[0];
    public string[] text;
    public Image image;
    public Text nameBox;
    public GameObject Anim;
    public GameObject LoadingPanel;
    public bool LevelCheck;
    AsyncOperation asyncOperation;
    public GameObject LoadingBar;
    public int randNo;
    public Text playerName;
    public Image[] avatar;
    string namedefault = "GUEST";
    void Start()
    {
       
        instance = this;
        LevelCheck = false;
        MultiplayerRun();
    }
    public void MultiplayerRun()
    {
        try
        {
            // if(MenuManger.Instance.Multiplayer.activeInHierarchy==true)
            // {
            Anim.gameObject.GetComponent<Animation>();
            StartCoroutine("ShowRandomImage");
            playerName.text = PlayerPrefs.GetString("username", namedefault);
            avatar[PlayerPrefs.GetInt("avatar", 0)].enabled = true;
            // }
        }
        catch { }
    
    }
    public IEnumerator ShowRandomImage()
    {
        StartCoroutine(StopRandomImage());
        while (true)
        {
            randNo = Random.Range(0, sprites.Length);
            image.sprite = sprites[randNo];
            if (randNo == 0 || randNo == 1)
            {
                nameBox.text = text[Random.Range(0, 7)];
            }
            else {
                nameBox.text = text[Random.Range(7, text.Length)];
            }
            image.enabled = true;
            nameBox.enabled = true;
            yield return new WaitForSeconds(0.2f);
            image.enabled = false;
            nameBox.enabled = false;
        }
    }
    public IEnumerator StopRandomImage()
    {
        yield return new WaitForSeconds(5f);
        LevelCheck = true;
        StopCoroutine("ShowRandomImage");

        PlayerPrefs.SetInt("OpponentImg", randNo);
        PlayerPrefs.SetString("OpponentName", nameBox.text);

        Anim.gameObject.GetComponent<Animation>().enabled = false;
        yield return new WaitForSeconds(2f);
        if (LevelCheck == true)
        {
            StartCoroutine("LoadingScreen", "MultiPlayerMode");
            LoadingPanel.SetActive(true);
            LevelCheck = false;
        }
    }

    IEnumerator LoadingScreen(string _scene)
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(_scene);
        while (!asyncOperation.isDone)
        {
            LoadingBar.GetComponent<Image>().fillAmount = asyncOperation.progress + 0.1f;

            yield return null;
        }

    }

}

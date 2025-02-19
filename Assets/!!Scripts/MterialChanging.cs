using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MterialChanging : MonoBehaviour {
    public static MterialChanging instance;
    public Material atlas, red;
    bool repeat;
    static bool repeat1;
    public static bool GameOver;
    public static int collisionCount;
     // Use this for initialization
    void Start () {
        try {
            instance = this;
            repeat = true;
            repeat1 = true;
            GameOver = false;
            collisionCount = 0;
        }
        catch
        { }
    }
	
    void OnCollisionEnter(Collision collision)
    {
        try
        {
            if (collision.gameObject.tag == "Player")
            {
                if (SceneManager.GetActiveScene().name == "MultiPlayerMode")
                {
                    Debug.Log("CHanged");
                    InvokeRepeating("ChangeMaterial", 0f, 0.75f);
                    //RCC_SceneManager.Instance.activePlayerVehicle.canControl = true;
                    // RCC_SceneManager.Instance.activePlayerCanvas.controllerButtons.SetActive(true);
                    GameManager.instance.controlGamePlay.SetActive(true);
                    PlayerCarScript.instance.SpawnCar();
                    Invoke("nnn", 2);
                    //GameManager.instance.Player.transform.position = GameManager.instance.RespawnPlayerCar.transform.position;

                }
                else if (SceneManager.GetActiveScene().name == "GamePlay" || SceneManager.GetActiveScene().name == "GamePlay2")
                {


                    if (repeat1)
                    {
                        InvokeRepeating("ChangeMaterial", 0f, 0.75f);
                        repeat1 = false;
                        collisionCount++;
                        GameManager.instance.Hitsound();
                        PlayerPrefs.SetInt("Stage_" + MenuManger.selectedstage + "_Level_" + LevelSelection.selectedLevel + "_Hits", collisionCount);
                        GameManager.instance.showCollisiontext.text = collisionCount.ToString();
                        if (collisionCount == 3)
                        {
                            GameOver = true;                           
                            TimeStar.instance.counter = true;
                           
                        }
                        Invoke("nnn", 2);
                       
                    }
                }
                if (GameManager.instance.ReplayCheck == true)
                {
                    if (collision.gameObject.tag == "Player")
                    {
                        GameManager.instance.controlGamePlay.SetActive(false);
                        GameManager.instance.FailPanel.SetActive(true);
                    }
                }
            }
        }
        catch { }
    }
    void OnCollisionExit(Collision collision)
    {
        try { 
        if (collision.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name == "MultiPlayerMode")
            {

            }
            else if (SceneManager.GetActiveScene().name == "GamePlay" || SceneManager.GetActiveScene().name == "GamePlay2")
            {
                if (!repeat1)
                {
                    repeat1 = true;
                    nnn();
                }
            }
        }
    }
        catch { }
    }
        void nnn()
    {
        try
        {
            CancelInvoke("ChangeMaterial");
            this.GetComponent<MeshRenderer>().material = atlas;
            repeat = true;
        }
        catch { }
    }

    void ChangeMaterial()
    {
        try
        {
            if (!FinishPoint.LevelClear)
            {
                if (this.GetComponent<MeshRenderer>() != null)
                {
                    if (repeat)
                    {
                        this.GetComponent<MeshRenderer>().material = red;
                        repeat = false;
                    }
                    else
                    {
                        this.GetComponent<MeshRenderer>().material = atlas;
                        repeat = true;
                    }
                    // nnn();
                }
                else
                {
                    nnn();
                }
            }
        }
        catch { }
    }
}

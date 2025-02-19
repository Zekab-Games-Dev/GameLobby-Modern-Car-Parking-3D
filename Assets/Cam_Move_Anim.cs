using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cam_Move_Anim : MonoBehaviour
{
    public Transform[] targets;
    public float speed;
    private int index = 0;
    Transform cubercc;
   public static bool is_move, is_move_false;
    public static Cam_Move_Anim instance;
    string LoadedScene;
    private void Awake() {
        instance=this;
    }
    private void Start()
    {
        is_move = true;
        if (GameManager.instance.controlGamePlay.activeInHierarchy)
        {
            GameManager.instance.controlGamePlay.SetActive(false);
        }
        //LevelFail.instance.failDummy.SetActive (true);
        //GameManager.instance.Cam.SetActive (false);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        if(is_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, targets[index].position, step);
            if (Vector3.Distance(transform.position, targets[index].position) < 0.05f)
            {
                if (index == targets.Length - 1)
                {
                    is_move_false = true;
                    is_move = false;
                   stopCam();
                }
                else
                {
                    index++;
                  
                }
            }
        }
    }
    public void stopCam()
    {
        transform.gameObject.SetActive(false);
		//LevelFail.instance.failDummy.SetActive (false);
        transform.GetComponent<Camera>().enabled = false;
		GameManager.instance.Cam.SetActive (true);
        GameManager.instance.controlGamePlay.SetActive(true);
        GameManager.instance.skipPanel.SetActive(false);
		//GameManager.instance.Player = GameObject.FindGameObjectWithTag ("Player");
        //Invoke("activeCAm", 0.01f);
        is_move = false;
        LoadedScene = SceneManager.GetActiveScene().name;
        if (LoadedScene == "MultiPlayerMode") {
            carDrivebyOwn.instance.isDriving = true;
        }
      //  GameManager.instance.skipBtn.SetActive(false);
    }

}

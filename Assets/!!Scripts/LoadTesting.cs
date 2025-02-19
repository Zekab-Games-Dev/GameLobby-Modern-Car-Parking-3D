using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadTesting : MonoBehaviour {

    public static LoadTesting instance;
    public static int level;
    public GameObject[] CarPrefab;
    public GameObject[] LevelPrefab;
    public Transform[] CarTransform;
    public int totallevel = 0;
    int i = 0;
    string LoadedScene;
    private void Awake()
    {
        
            instance = this;
            i = PlayerPrefs.GetInt("Player", 0);
            LoadedScene = SceneManager.GetActiveScene().name;
            if (LoadedScene == "GamePlay")
            {
                //level = PlayerPrefs.GetInt("Level", 0);
                level = LevelSelection.selectedLevel;
            }
            else if (LoadedScene == "GamePlay2")
            {
                //level = PlayerPrefs.GetInt("2Level2", 0);
                level = LevelSelection.selectedLevel;
            }

            LevelPrefab[level].SetActive(true);
           // Instantiate(LevelPrefab[level]);
           GameObject obj= Instantiate(CarPrefab[i], CarTransform[level].position, CarTransform[level].rotation);
        obj.SetActive(true);
            //UnityAnalyticsEvents.LevelStartEvent("1-" + level);

        
    }
}

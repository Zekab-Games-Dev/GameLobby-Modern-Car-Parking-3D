using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestButton : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPressButton(int a)
    {
        if (a > 15)
        {
            LoadTesting.level = a;
            SceneManager.LoadSceneAsync("GamePlay2");
        }
        else
        {
            LoadTesting.level = a;
            SceneManager.LoadSceneAsync("GamePlay");
        }
        
        

    }
}

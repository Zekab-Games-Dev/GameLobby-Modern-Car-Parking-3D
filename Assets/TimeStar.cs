using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStar : MonoBehaviour
{
    // Start is called before the first frame update
    public static TimeStar instance = null;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public int countstar;
    public  bool counter;
    public Text showtime;
    public float time;
    void Start()
    {
        try { 
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
            instance = this;
        }
        counter = true;
        countstar = 3;
        }
        catch { }
    }

    // Update is called once per frame
    void Update()
    {
        try { 
        if (!counter)
        {
            time += Time.deltaTime * 1;
            showtime.text = time.ToString("f1");
            if (time >= LevelSelection.currentLevelStarsTime[0] && countstar == 3)
            {
                Star1.SetActive(false);
                countstar = 2;
               
            }
            if (time >= LevelSelection.currentLevelStarsTime[1] && countstar == 2)
            {
                Star2.SetActive(false);
                countstar = 1;
            }

        }
        }
        catch { }
    }
  
}

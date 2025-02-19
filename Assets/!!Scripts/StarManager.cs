using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public static StarManager instance;
    public int CollectStarsCount = 0;
    bool once = false;
    public GameObject[] stars;
    public void Start()
    {
        try
        {
            instance = this;
        }
        catch { }
    }
    public void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.gameObject.tag == "Star")
            {
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                //if () { 
                //bool 
                //Debug.LogError("Collided");
                print("Player" + CollectStarsCount);
                if (CollectStarsCount <= 2)
                {
                    CollectStarsCount++;
                    Destroy(other.gameObject);
                    print("StarCollect" + CollectStarsCount);
                    for (int i = 0; i < CollectStarsCount; i++)
                    {
                        stars[i].SetActive(true);
                    }
                }

            }
        }
        catch { }
    }   
    }

        


           
  





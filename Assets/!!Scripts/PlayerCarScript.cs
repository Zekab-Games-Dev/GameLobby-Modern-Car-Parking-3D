using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarScript : MonoBehaviour
{
    public static PlayerCarScript instance;
    public  int CollectStarsCount = 0;
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
            if (other.gameObject.tag == "PlayerStar")
            {
                print("Player" + CollectStarsCount);
                if (CollectStarsCount <= 2)
                {
                    if (other.gameObject.GetComponent<CoinRotate>() != null)
                    {
                        Vector3 ro = other.gameObject.GetComponent<CoinRotate>().startRot;

                        GameManager.instance.RespawnPlayerCar.transform.position = other.gameObject.transform.position;
                        GameManager.instance.RespawnPlayerCar.transform.eulerAngles = new Vector3(GameManager.instance.RespawnPlayerCar.transform.eulerAngles.x, ro.y, GameManager.instance.RespawnPlayerCar.transform.eulerAngles.z);
                    }
                    CollectStarsCount++;
                    for (int i = 0; i < CollectStarsCount; i++)
                    {
                        stars[i].SetActive(true);
                    }
                    GameManager.instance.CoinSound();
                    Destroy(other.gameObject);
                    // Debug.LogError("eulR" + ro);

                }

            }
        }
        catch { }
    }

    IEnumerator EngineStart()
    {
        yield return new WaitForSeconds(0f);
        GameManager.instance.Player.transform.gameObject.GetComponent<RCC_CarControllerV3>().direction = 1;
    }

    public void SpawnCar()
    {
        try
        {
            if (CollectStarsCount == 1)
            {
                Debug.Log("Car Spawned");
                GameManager.instance.Player.transform.position = GameManager.instance.RespawnPlayerCar.transform.position + new Vector3(0, 0.5f, 0);
                GameManager.instance.Player.transform.eulerAngles = new Vector3(GameManager.instance.Player.transform.eulerAngles.x, GameManager.instance.RespawnPlayerCar.transform.eulerAngles.y, GameManager.instance.Player.transform.eulerAngles.z);
               // StartCoroutine(EngineStart());
            }

            if (CollectStarsCount == 2)
            {
                Debug.Log("Car Spawned");
                GameManager.instance.Player.transform.position = GameManager.instance.RespawnPlayerCar.transform.position + new Vector3(0, 0.5f, 0);
                GameManager.instance.Player.transform.eulerAngles = new Vector3(GameManager.instance.Player.transform.eulerAngles.x, GameManager.instance.RespawnPlayerCar.transform.eulerAngles.y, GameManager.instance.Player.transform.eulerAngles.z);
               // StartCoroutine(EngineStart());
            }
        }
        catch { }
    }
}

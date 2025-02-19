using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnPoint : MonoBehaviour
{
    GameObject PlayerCar,AICar;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        PlayerCar = GameObject.FindGameObjectWithTag("Player");
        PlayerCar.transform.position = transform.position;
        PlayerCar.transform.rotation = transform.rotation;
        AICar = GameObject.FindGameObjectWithTag("RedAICAr");
        AICar.transform.position = transform.position;
        AICar.transform.rotation = transform.rotation;
    }
}

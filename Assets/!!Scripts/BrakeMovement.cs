using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeMovement : MonoBehaviour {
    private RCC_CarControllerV3 carController;
    // Use this for initialization
    void Start () {
        carController = GetComponentInParent<RCC_CarControllerV3>();
    }
	
	// Update is called once per frame
	void Update () {
        if (carController.brakeInput > 0)
        {
            
            this.GetComponent<WheelCollider>().suspensionDistance = 0.25f;
        }
        else
        {
            this.GetComponent<WheelCollider>().suspensionDistance = 0.2f;
        }
    }
}

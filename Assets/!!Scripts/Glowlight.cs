using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowlight : MonoBehaviour
{
    private RCC_CarControllerV3 carController;
    Color DefaultColor;
    Color RedColor;
    Color WhiteColor;
    public Material WhiteMaterial,DefaultMaterial,RedMaterial;
    // Use this for initialization
    void Start()
    {
        
        DefaultColor = new Color(0.1254902f, 0.6078432f, 0.4784314f,0.75f);
        RedColor = new Color(1f,0f,0f,0.75f);
        WhiteColor = new Color(0.1345f,0.4117f,0.4528f,0.75f);
        carController = GetComponentInParent<RCC_CarControllerV3>();
    }

    // Update is called once per frame
    void Update()
    {

        if (carController.direction == -1)
        {
            //this.GetComponent<MeshRenderer>().material.color=
            this.GetComponent<MeshRenderer>().material = WhiteMaterial;

            if (carController.brakeInput > 0)
            {

                this.GetComponent<MeshRenderer>().material = RedMaterial;
            }
            else
            {
                this.GetComponent<MeshRenderer>().material = WhiteMaterial;
            }
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = DefaultMaterial;
            if (carController.brakeInput > 0)
            {

                this.GetComponent<MeshRenderer>().material = RedMaterial;
            }
            else
            {
                this.GetComponent<MeshRenderer>().material = DefaultMaterial;
            }
        }

    }
}

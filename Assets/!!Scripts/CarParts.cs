using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CarParts : MonoBehaviour
{
    public Material [] Car1Materials, Car2Materials, Tyre1Materials, Tyre2Materials, PlaneMaterials;
    public MeshRenderer[] Parts;
    public MeshRenderer[] Tyres;
    public GameObject ColorPlane;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "GamePlay" ) 
        {
            ChangeCar1Material(Car1Materials[PlayerPrefs.GetInt("Car1MaterialRecent")]);
            ChangeTyre1Material(Tyre1Materials[PlayerPrefs.GetInt("Car1MaterialRecent")]); 
        }
        if(SceneManager.GetActiveScene().name == "MultiPlayerMode")
        {
            ChangeCar1Material(Car1Materials[PlayerPrefs.GetInt("Car1MaterialRecent")]);
            ChangeTyre1Material(Tyre1Materials[PlayerPrefs.GetInt("Car1MaterialRecent")]); 
        }
        if (SceneManager.GetActiveScene().name == "GamePlay2")
        {
            ChangeCar1Material(Car2Materials[PlayerPrefs.GetInt("Car2MaterialRecent")]);
            ChangeTyre2Material(Tyre2Materials[PlayerPrefs.GetInt("Car2MaterialRecent")]); 
            ColorPlane.gameObject.GetComponent<Glowlight>().DefaultMaterial = PlaneMaterials[PlayerPrefs.GetInt("Car2MaterialRecent")];
        }

    }

    public void ChangeCar1Material(Material mat)
    {

        for (int i = 0; i < Parts.Length; i++)
        {

            Material[] materials = Parts[i].materials;
            materials[0] = mat;
            Parts[i].materials = materials;
        }
    }

    public void ChangeTyre1Material(Material mat)
    {
        for (int i = 0; i < Tyres.Length; i++)
        {
            Material[] materials = Tyres[i].materials;
            materials[1] = mat;
            Tyres[i].materials = materials;
        }
    }
    public void ChangeTyre2Material(Material mat)
    {
        for (int i = 0; i < Tyres.Length; i++)
        {
            Material[] materials = Tyres[i].materials;
            materials[2] = mat;
            Tyres[i].materials = materials;
        }
    }
}

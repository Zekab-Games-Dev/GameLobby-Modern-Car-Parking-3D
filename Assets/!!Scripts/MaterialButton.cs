using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialButton : MonoBehaviour
{
    //public static MaterialButton Instance;
    public string Color;
    public bool Locked,selected;
    public GameObject LockedImage;
    public int price;
    private void Awake()
    {
        //Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        if (Locked)
            LockedImage.SetActive(true);
        else
            LockedImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Locked)
            LockedImage.SetActive(true);
        else
            LockedImage.SetActive(false);
    }
    public void SetColorName()                    //Daniyal
    {
        if (!Locked)
        {
          //  PlayerPrefs.SetString("Car_" + MenuManger.CarNumber + "_Color_", Color);
            print("FirstCarColor" + Color);
        }
        
    }
}

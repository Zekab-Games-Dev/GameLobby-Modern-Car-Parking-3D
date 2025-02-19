using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Garage : MonoBehaviour
{
    public static Garage instance;
    public int tempColor,tempNumber;
    public MaterialButton[] Materialbuttons;
    public Material[] Car1Material;
    public Material[] Tyre1Material;
    public GameObject Car1Panel, Car2panel, BuyPanel,Particles,InAppPanel, UnlockSkinButton, UnlockSkinPanel;
    public CarParts Car1, Car2;
    public CarParts Car1Prefab, Car2Prefab;
    public Sprite simple, selected;
    public Text StageText, LevelText, CreditText;
    public string MaterialColor,MatColor;
    public AudioClip ButtonBuy, ButtonInApp;
    private void Awake()
    {
  
        //PlayerPrefs.SetInt("Credits", 1700);
        //PlayerPrefs.SetString("Car1Material", "100000");
        //PlayerPrefs.SetInt("Car1MaterialRecent", 0);

        MatColor = PlayerPrefs.GetString("Car1Material");
        //if (MatColor == "111111")
        //{
        //    InAppButton.SetActive(false);
        //}
        for(int i=0; i<MatColor.Length; i++)
        {
            
            if (char.GetNumericValue(MatColor[i]) == 0 )
            {
                Materialbuttons[i].Locked = true;
                
            }
            else
            {
                Materialbuttons[i].Locked = false;
                
            }
                
        }
        for(int i=0; i< Materialbuttons.Length; i++)
        {
            if(i== PlayerPrefs.GetInt("Car1MaterialRecent"))
            {
                Materialbuttons[i].gameObject.GetComponent<Image>().sprite = selected;
            }
            else
            {
                Materialbuttons[i].gameObject.GetComponent<Image>().sprite = simple;
            }
        }
        OnPressColorButtonCar1(PlayerPrefs.GetInt("Car1MaterialRecent"));
        SpriteSwap(PlayerPrefs.GetInt("Car1MaterialRecent"));
        print(tempColor);
        //OnPressColorButtonCar1(Materialbuttons[tempColor].Color);
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
      //  StageText.text = MenuManger.Instance.StageText.text;
       // LevelText.text = MenuManger.Instance.LevelText.text;
    }

    // Update is called once per frame
    void Update()
    {
        CreditText.text = "" + PlayerPrefs.GetInt("Credits");
        if (PlayerPrefs.GetString("Car1Material") == "111111")
        {
            UnlockSkinButton.SetActive(false);
        }
        else
            UnlockSkinButton.SetActive(true);

        //if(MenuManger.Instance.NetFailPanel.activeInHierarchy== false)
        //{
        //    Car1.gameObject.SetActive(true);
        //}
    }

    public void OnPressColorButtonCar1(int color)
    {
        
        ChangeCar1Material(Car1Material[color]);
        ChangeTyre1Material(Tyre1Material[color]);
    }
    public void SpriteSwap(int number)
    {
        for (int i = 0; i < Materialbuttons.Length; i++)
        {
            if (i == number)
            {
                Materialbuttons[i].gameObject.GetComponent<Image>().sprite = selected;
            }
            else
            {
                Materialbuttons[i].gameObject.GetComponent<Image>().sprite = simple;
            }
        }
        tempNumber = number;
        if (Materialbuttons[number].Locked == false)
        {
            ChangePrefabCar1Material(Car1Material[number]);
            ChangePrefabTyre1Material(Tyre1Material[number]);
            PlayerPrefs.SetInt("Car1MaterialRecent", number);
            BuyPanel.SetActive(false);
        }
        //BuyColorCar1();

        

    }
    public void BuyColorCar1()
    {
        for (int i = 0; i < Materialbuttons.Length; i++)
        {
            if (Materialbuttons[i].gameObject.GetComponent<Image>().sprite == selected)
            {
                tempColor = i;
            }
        }
        if (PlayerPrefs.GetInt("Credits") >= Materialbuttons[tempColor].price)
        {
            PlayerPrefs.SetInt("Car1MaterialRecent", tempColor);
            string TempMaterial = PlayerPrefs.GetString("Car1Material");
            char[] CharArray = TempMaterial.ToCharArray();

            for (int i = 0; i < TempMaterial.Length; i++)
            {
                if (i == tempColor)
                {
                    CharArray[i] = '1';
                    Materialbuttons[i].Locked = false;
                    PlayerPrefs.SetString("Car_" + "_Color_", Materialbuttons[i].Color);      //Daniyal
                }
            }
            TempMaterial = new string(CharArray);
            PlayerPrefs.SetString("Car1Material", TempMaterial);
            print("TEMP MATERIAL  " + TempMaterial);
            BuyPanel.SetActive(false);
            ChangePrefabCar1Material(Car1Material[tempColor]);
            ChangePrefabTyre1Material(Tyre1Material[tempColor]);
            Particles.SetActive(true);
            PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits") - Materialbuttons[tempColor].price);
            MenuManger.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(ButtonBuy);


        }
        else
        {
           // MenuManger.Instance.CheckConnection();
            InAppPanel.SetActive(true);
            Car1.gameObject.SetActive(false);
            MenuManger.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(ButtonInApp);
        }
    }
    public void ChangeCar1Material(Material mat)
    {
        
        for (int i=0; i<Car1.Parts.Length; i++)
        {
            
            Material[] materials = Car1.Parts[i].materials;
            materials[0] = mat;
            Car1.Parts[i].materials= materials;
        }
    }
    public void ChangePrefabCar1Material(Material mat)
    {
        for (int i = 0; i < Car1Prefab.Parts.Length; i++)
        {
            Material[] materials = Car1Prefab.Parts[i].sharedMaterials;
            materials[0] = mat;
            Car1Prefab.Parts[i].sharedMaterials = materials;
        }
    }
    public void ChangeTyre1Material(Material mat)
    {
        for (int i = 0; i < Car1.Tyres.Length; i++)
        {
            Material[] materials = Car1.Tyres[i].materials;
            materials[1] = mat;
            Car1.Tyres[i].materials = materials;
        }
    }
    public void ChangePrefabTyre1Material(Material mat)
    {
        for (int i = 0; i < Car1Prefab.Tyres.Length; i++)
        {
            Material[] materials = Car1Prefab.Tyres[i].sharedMaterials;
            materials[1] = mat;
            Car1Prefab.Tyres[i].sharedMaterials = materials;
        }
    }
    public void CheckPrice(int price)
    {
        BuyPanel.SetActive(false);
        print("tempnumber  " + tempNumber);
        if (Materialbuttons[tempNumber].Locked==true)
        {
            BuyPanel.SetActive(true);
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < Materialbuttons.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("Car1MaterialRecent"))
            {
                Materialbuttons[i].gameObject.GetComponent<Image>().sprite = selected;
            }
            else
            {
                Materialbuttons[i].gameObject.GetComponent<Image>().sprite = simple;
            }
        }
        OnPressColorButtonCar1(PlayerPrefs.GetInt("Car1MaterialRecent"));
        if (PlayerPrefs.GetString("Car1Material") == "111111")
        {
            UnlockSkinButton.SetActive(false);
        }
        else
            UnlockSkinButton.SetActive(true);
    }
    public void OnDisable()
    {
        BuyPanel.SetActive(false);
        UnlockSkinButton.SetActive(false);
    }
    public void OnPressCancelButton()
    {
        if(this.gameObject.activeInHierarchy)
        {
            Car1.gameObject.SetActive(true);
            if (PlayerPrefs.GetString("Car1Material") == "111111")
            {
                UnlockSkinButton.SetActive(false);
            }
            else
                UnlockSkinButton.SetActive(true);
        }
    

    }
    public void UnlockAllSkin()
    {
        if (this.gameObject.activeInHierarchy)
        {
            print("car 1 function");
            PlayerPrefs.SetString("Car1Material", "111111");
            PlayerPrefs.SetInt("Removeads", 1);
            MatColor = PlayerPrefs.GetString("Car1Material");
            UnlockSkinButton.SetActive(false);
            UnlockSkinPanel.SetActive(false);
            BuyPanel.SetActive(false);
            Car1.gameObject.SetActive(true);
            Particles.SetActive(true);
            for (int i = 0; i < MatColor.Length; i++)
            {
                Materialbuttons[i].Locked = false;
            }
        }
           
    }
}

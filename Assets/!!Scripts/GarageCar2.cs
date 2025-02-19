using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GarageCar2 : MonoBehaviour
{
    public int tempColor, tempNumber;
    public MaterialButton[] Materialbuttons;
    public Material[] CarMaterial;
    public Material[] TyreMaterial;
    public Material[] PlaneMaterial;
    public GameObject  BuyPanel, Particles, InAppPanel,UnlockSkinButton, UnlockSkinPanel;
    public CarParts Car;
    public CarParts CarPrefab;
    public Sprite simple, selected;
    public Text StageText, LevelText, CreditText;
    public string MaterialColor, MatColor;
    public GameObject UnlockText;
    public AudioClip ButtonBuy, ButtonInApp;
    
    private void Awake()
    {
        //PlayerPrefs.SetInt("Credits", 10000);
        //PlayerPrefs.SetString("Car2Material", "100000");
        //PlayerPrefs.SetInt("Car2MaterialRecent", 0);


        MatColor = PlayerPrefs.GetString("Car2Material");
        //if (MatColor == "111111")
        //{
        //    InAppButton.SetActive(false);
        //}
        for (int i = 0; i < MatColor.Length; i++)
        {

            if (char.GetNumericValue(MatColor[i]) == 0)
            {
                Materialbuttons[i].Locked = true;

            }
            else
            {
                Materialbuttons[i].Locked = false;

            }

        }
        for (int i = 0; i < Materialbuttons.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("Car2MaterialRecent"))
            {
                Materialbuttons[i].gameObject.GetComponent<Image>().sprite = selected;
            }
            else
            {
                Materialbuttons[i].gameObject.GetComponent<Image>().sprite = simple;
            }
        }
        OnPressColorButtonCar(PlayerPrefs.GetInt("Car2MaterialRecent"));
        SpriteSwap(PlayerPrefs.GetInt("Car2MaterialRecent"));
        print(tempColor);
        //OnPressColorButtonCar1(Materialbuttons[tempColor].Color);
    }

    // Start is called before the first frame update
    void Start()
    {
       // StageText.text = MenuManger.Instance.StageText.text;
        //LevelText.text = MenuManger.Instance.LevelText.text;
    }

    // Update is called once per frame
    void Update()
    {
        CreditText.text = "" + PlayerPrefs.GetInt("Credits");
        if (PlayerPrefs.GetInt("Stage2") == 0 || PlayerPrefs.GetString("Car2Material") == "111111")
        {
            UnlockSkinButton.SetActive(false);
        }
        else
        
            UnlockSkinButton.SetActive(true);
        
        //if (MenuManger.Instance.NetFailPanel.activeInHierarchy == false)
        //{
        //    Car.gameObject.SetActive(true);
        //}
    }

    public void OnPressColorButtonCar(int color)
    {

        ChangeCar1Material(CarMaterial[color]);
        ChangeTyre1Material(TyreMaterial[color]);
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
            ChangePrefabCar1Material(CarMaterial[number]);
            ChangePrefabTyre1Material(TyreMaterial[number]);
            ChangePrefabPlaneMaterial(PlaneMaterial[number]);
            PlayerPrefs.SetInt("Car2MaterialRecent", number);
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
            PlayerPrefs.SetInt("Car2MaterialRecent", tempColor);
            string TempMaterial = PlayerPrefs.GetString("Car2Material");
            char[] CharArray = TempMaterial.ToCharArray();

            for (int i = 0; i < TempMaterial.Length; i++)
            {
                if (i == tempColor)
                {
                    CharArray[i] = '1';
                    Materialbuttons[i].Locked = false;
                  //  PlayerPrefs.SetString("Car_" + MenuManger.CarNumber + "_Color_", Materialbuttons[i].Color);     // Daniyal
                }
            }
            TempMaterial = new string(CharArray);
            PlayerPrefs.SetString("Car2Material", TempMaterial);
            print("TEMP MATERIAL  " + TempMaterial);
            BuyPanel.SetActive(false);
            ChangePrefabCar1Material(CarMaterial[tempColor]);
            ChangePrefabTyre1Material(TyreMaterial[tempColor]);
            ChangePrefabPlaneMaterial(PlaneMaterial[tempColor]);
            Particles.SetActive(true);
            PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits") - Materialbuttons[tempColor].price);
            MenuManger.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(ButtonBuy);
        }
        else
        {
          //  MenuManger.Instance.CheckConnection();
            InAppPanel.SetActive(true);
            Car.gameObject.SetActive(false);
            MenuManger.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(ButtonInApp);
        }
    }
    public void ChangeCar1Material(Material mat)
    {

        for (int i = 0; i < Car.Parts.Length; i++)
        {

            Material[] materials = Car.Parts[i].materials;
            materials[0] = mat;
            Car.Parts[i].materials = materials;
        }
    }
    public void ChangePrefabCar1Material(Material mat)
    {
        for (int i = 0; i < CarPrefab.Parts.Length; i++)
        {
            Material[] materials = CarPrefab.Parts[i].sharedMaterials;
            materials[0] = mat;
            CarPrefab.Parts[i].sharedMaterials = materials;
        }
    }
    public void ChangeTyre1Material(Material mat)
    {
        for (int i = 0; i < Car.Tyres.Length; i++)
        {
            Material[] materials = Car.Tyres[i].materials;
            materials[0] = mat;
            Car.Tyres[i].materials = materials;
        }
    }
    public void ChangePrefabTyre1Material(Material mat)
    {
        for (int i = 0; i < CarPrefab.Tyres.Length; i++)
        {
            Material[] materials = CarPrefab.Tyres[i].sharedMaterials;
            materials[0] = mat;
            CarPrefab.Tyres[i].sharedMaterials = materials;
        }
    }
    public void ChangePrefabPlaneMaterial(Material mat)
    {
          
            //Material material = CarPrefab.ColorPlane.gameObject.GetComponent<Glowlight>().DefaultMaterial;
            //material = mat;
            CarPrefab.ColorPlane.gameObject.GetComponent<Glowlight>().DefaultMaterial = mat;
        
    }
    public void CheckPrice(int price)
    {
        BuyPanel.SetActive(false);
        if (Materialbuttons[tempNumber].Locked == true)
        {
            BuyPanel.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Stage2") == 0)
        {
            //BuyPanel.GetComponentInChildren<Button>().interactable = false;
            BuyPanel.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("Stage2") == 0)
        {
            UnlockText.SetActive(true);
        }
        for (int i = 0; i < Materialbuttons.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("Car2MaterialRecent"))
            {
                Materialbuttons[i].gameObject.GetComponent<Image>().sprite = selected;
            }
            else
            {
                Materialbuttons[i].gameObject.GetComponent<Image>().sprite = simple;
            }
        }
        OnPressColorButtonCar(PlayerPrefs.GetInt("Car2MaterialRecent"));
        if (PlayerPrefs.GetInt("Stage2") == 0 || PlayerPrefs.GetString("Car2Material") == "111111")
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
        UnlockText.SetActive(false);
    }
    public void OnPressCancelButton()
    {
        if (this.gameObject.activeInHierarchy)
        {
            Car.gameObject.SetActive(true);
            if (PlayerPrefs.GetString("Car2Material") == "111111")
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
            print("car 2 function");
            PlayerPrefs.SetString("Car2Material", "111111");
            PlayerPrefs.SetInt("Removeads", 1);
            MatColor = PlayerPrefs.GetString("Car2Material");
            UnlockSkinButton.SetActive(false);
            UnlockSkinPanel.SetActive(false);
            BuyPanel.SetActive(false);
            Car.gameObject.SetActive(true);
            Particles.SetActive(true);
            for (int i = 0; i < MatColor.Length; i++)
            {
                Materialbuttons[i].Locked = false;
            }
            
        }
    }
}

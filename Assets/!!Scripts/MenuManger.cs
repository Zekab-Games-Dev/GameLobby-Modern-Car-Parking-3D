using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ServerTime;
using UnityEngine.SceneManagement;



    public class MenuManger : MonoBehaviour
    {
        public GameObject Exit, Multiplayer, Level1Selection, Level2Selection,mainPanel, dailyRewardPanel;
        public static MenuManger Instance;
        public Sprite SimpleSprite, SelectedSprite;
        public Text[] CashText;
        public Text[] GoldText;
        public static bool LevelSelection1, LevelSelection2, Stage2Clear;
        public Sprite[] MainImages= new Sprite[7];
        public GameObject ByDefaultImage,MpPanelUBox;
        public GameObject[] Player;                   
        public GameObject[] MenuAds;
        public GameObject[] ModeAds;

        public Toggle steeringToggle;
        public Toggle arrowToggle;
        public Toggle leftControlToggle;
        public Toggle rightControlToggle;
        public Text nameText;
        public Text nameText2;
        public GameObject[] avatar;
        public GameObject PleaseUnloclclassictext;
        public GameObject PleaseUnloclmoderntext;

        public GameObject unlockModernMode;
        public GameObject unlockMultiplayerMode;

        [HideInInspector]
        public int carIndex;
        public GameObject no_coinPanel;
        public GameObject garragePanel;

        public GameObject[] colorSets, colorSet1, colorSet2, colorSet3, colorSet4, colorSet5, colorSet6;
        public GameObject[] rimSets, rimSet1, rimSet2, rimSet3, rimSet4, rimSet5, rimSet6;
        public GameObject[] car1RimModel, car2RimModel, car3RimModel, car4RimModel, car5RimModel, car6RimModel, carBody;
        public GameObject[] decalSets, decalSet1, decalSet2, decalSet3, decalSet4, decalSet5, decalSet6;   
        public Material[] carBodyMat, carDecals, carDecals1, carDecals2, carDecals3, carDecals4, carDecals5;
        public Color[] colorCode1, colorCode2, colorCode3, colorCode4, colorCode5, colorCode6;

        public GameObject decalPlayBtn, decalCoinBtn, decalAdBtn, decalIapBtn;
        public GameObject rimAdBtn, rimCoinBtn, rimPlayBtn, rimIapBtn;
        public GameObject coinWarning, adWarning;
        Material carDefaultMat;

        public GameObject colorAdBtn, colorCoinBtn, colorPlayBtn, colorIapBtn;

        public GameObject removeAdsButton;
        public Button removeAdsButton2;

        public GameObject levelbtnclassic;
        public GameObject levelbtnmodern;
        public Button levelbtn;
        public Button unlockallbtn;

        int selectedCustomize;

    public GameObject megapackbutton;
    public GameObject megaPackpanel;
    public GameObject carLockpanel;

    public GameObject colorPanel;
    public GameObject DecalPanel;
    public GameObject RimPanel;

    public Animator anim1;
    public Animator anim2;

   // private static bool bannerShown=false;

    void Start()
        {
       
        Instance = this;
         //PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 1000);
       // PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Cash") + 1000);
        LoadProfile();
        CustomAds.instance.callAds(MenuAds);
        ControlOnStart();
        if (PlayerPrefs.GetInt("Removeads") == 1)
        {
            removeAdsButton.SetActive(false);
            removeAdsButton2.interactable = false;
        }
        showLastSelectedCar();
        //if (PlayerPrefs.GetInt("Stage_" + 1 + "_Level_" + 10) == 1)
        //{
        //    unlockModernMode.SetActive(false);
        //    levelbtnclassic.SetActive(false);
        //}
        if (PlayerPrefs.GetInt("Stage_" + 2 + "_Level_" + 10) == 1)
        {
            unlockMultiplayerMode.SetActive(false);
            levelbtnmodern.SetActive(false);
           
        }
        if (PlayerPrefs.GetInt("unlockeverything") == 1) 
        {
            unlockallbtn.interactable = false;
            levelbtn.interactable = false;
            megapackbutton.SetActive(false);
        }
        if (PlayerPrefs.GetInt("unlockeverything",0) != 1)
        {
            if (PlayerPrefs.GetInt("megapack", 0) == 1 && PlayerPrefs.GetInt("opennextpanel") == 0 && PlayerPrefs.GetInt("opennextpanel2") == 0) 
            {
                Invoke("showpack", 2f);
            }
        }
        unlockColors();
        unlockRims();
        unlockDecals();
        setIAPButtons();
        //if(PlayerPrefs.GetInt("opennextpanel",0) == 1) 
        //{
        //    mainPanel.SetActive(false);
        //    modePanel.SetActive(true);
        //    PlayerPrefs.SetInt("opennextpanel", 0);
        //    if (!anim1.enabled)
        //    {
        //        anim1.enabled = true;
        //    }
        //}
        //else if (PlayerPrefs.GetInt("opennextpanel2", 0) == 1)
        //{
        //    mainPanel.SetActive(false);
        //    modePanel.SetActive(true);
        //    PlayerPrefs.SetInt("opennextpanel2", 0);
        //    if (!anim2.enabled)
        //    {
        //        anim2.enabled = true;
        //    }
        //}


        //if(bannerShown==false && FirebaseManager.Instance.isAdmob)
        //{
        //    AdsManager.Instance.InitialzeAdmobBannerAd();
        //    bannerShown = true;
        //}
        if (!AdsManager.Instance.isAdsPurchased)
        {
            AdsManager.Instance.ShowBottomAdaptiveBanner();
        }

    }
    int counter = 0;
   
    public void showpack()
        {
            try { 
        if (!dailyRewardPanel.activeInHierarchy)
        {
            megaPackpanel.SetActive(true);
        }
        }
        catch { }
    }

   
        void Update()
        {
        try { 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
            if (Exit.activeInHierarchy)
            {
                Exit.SetActive(false);
            }
            else 
            {
                Exit.SetActive(true);
            }
                
            }
        for (int i=0;i<CashText.Length; i++) 
        {
            CashText[i].text = PlayerPrefs.GetInt("Cash").ToString();
            GoldText[i].text = PlayerPrefs.GetInt("Gold").ToString();
        }
        }
        catch { }

    }
  
        public void MultiplayerButton()                       // Daniyal
        {
        try { 
        if (PlayerPrefs.GetInt("Stage_" + 2 + "_Level_" + 10)  == 1) 
        {
            Multiplayer.SetActive(true);
            modePanel.SetActive(false);
                if (anim2.enabled)
                {
                    anim2.enabled = true;
                }
                // Multiplayer.GetComponent<Animator>().Play("SettingsPanel");
            }
        else
        {
            if (!PleaseUnloclmoderntext.activeInHierarchy)
            {
                PleaseUnloclmoderntext.SetActive(true);
                Invoke("offtext", 1f);
            }
        }
        }
        catch { }
    }
        

    public static int selectedstage = 0;
        public void Stage1Button()
        {
        try { 
        selectedstage = 1;
        Level1Selection.SetActive(true);
        modePanel.SetActive(false);
        LevelSelection.instance.Selection();
        }
        catch { }
    }

        public void Stage2Button()
        {
        try { 
       // if (PlayerPrefs.GetInt("Stage_" + 1 + "_Level_" + 10) == 1)
       // {
            selectedstage = 2;
            Level2Selection.SetActive(true);
            modePanel.SetActive(false);
            LevelSelection.instance.Selection();
                if (anim1.enabled)
                {
                    anim1.enabled = false;
                }
         //   }
       // else
       // {
        //    if (!PleaseUnloclclassictext.activeInHierarchy)
         //   {
          //      PleaseUnloclclassictext.SetActive(true);
          //      Invoke("offtext", 1f);
         //   }
       // }
        }
        catch { }

    }
        void offtext() 
        {
        try { 
            if (PleaseUnloclclassictext.activeInHierarchy)
            {
                PleaseUnloclclassictext.SetActive(false);
            }
            else if (PleaseUnloclmoderntext.activeInHierarchy)
            {
                PleaseUnloclmoderntext.SetActive(false);
            }
        }
        catch { }
    }
        public GameObject modePanel;
         public void showLastSelectedCar()
        {
        try { 
            if (!PlayerPrefs.HasKey("Player"))
            {
                carIndex = 0;
            }
            else
            {
                carIndex = PlayerPrefs.GetInt("Player");
            }
            foreach (GameObject cars in Player)
            {
                cars.SetActive(false);
            }
            Player[carIndex].SetActive(true);
            if (Player[0].activeInHierarchy)
            {
                purchaseBtn.SetActive(false);
                selectBtn.SetActive(true);
                UnlockallCars.SetActive(false);
            }
            unlockCar();
        }
        catch { }
    }
        public void SelectCar() //open level selection panel
        {
        try { 
                PlayerPrefs.SetInt("Player", carIndex);
                garragePanel.SetActive(false);
                modePanel.SetActive(true);
                CancelInvoke("OpenCarPanel");
                CustomAds.instance.stopAds();
                CustomAds.instance.callAds(ModeAds);

        }
        catch { }
    }
    public void Next() //show next car
    {
        try { 
            if (carIndex < Player.Length - 1)
            {
                carIndex++;
            }
            else
            {
                carIndex = 0;
            }           
            activateCurrentCar();
        }
        catch { }
    }
        public void Previous() //show previous car
        {
        try { 
                if (carIndex > 0)
                {
                    carIndex--;
                }
                else
                {
                    carIndex = Player.Length - 1;
                }          
                activateCurrentCar();
        }
        catch { }
    }

            void activateCurrentCar() //show current car
            {
        try { 
                foreach (GameObject cars in Player) 
                {
                    cars.SetActive(false);
                }
                Player[carIndex].SetActive(true);
            if (Player[0].activeInHierarchy)
            {
                purchaseBtn.SetActive(false);
                selectBtn.SetActive(true);
                UnlockallCars.SetActive(false);
            }
            //if (Player[3].activeInHierarchy && !PlayerPrefs.GetInt("Player" + carIndex).Equals(1)) 
            //{
            //    carLockpanel.SetActive(true);
            //}
        
        unlockCar();
        }
        catch { }
    }
    public void purchaseCar() //purchase current car
    {
        try
        {
            int coinsget = PlayerPrefs.GetInt("Cash");
            int goldget = PlayerPrefs.GetInt("Gold");
            int price = _price();
            switch (carIndex) 
            {
                case 1:
                    if (coinsget >= price)
                    { //buy car
                        PlayerPrefs.SetInt("Player" + carIndex, 1);
                        coinsget = coinsget - price;
                        PlayerPrefs.SetInt("Cash", coinsget);
                        unlockCar();
                    }
                    else
                    { //not enough coins
                        no_coinPanel.SetActive(true);
                        Invoke("deactive_not_coin", 1f);
                    }
                    break;
                case 2:
                    if (goldget >= price)
                    { //buy car
                        PlayerPrefs.SetInt("Player" + carIndex, 1);
                        goldget = goldget - price;
                        PlayerPrefs.SetInt("Gold",goldget);
                        unlockCar();
                    }
                    else
                    { //not enough coins
                        no_coinPanel.SetActive(true);
                        Invoke("deactive_not_coin", 1f);
                    }
                    break;
                case 3:
                    if (coinsget >= price)
                    { //buy car
                        PlayerPrefs.SetInt("Player" + carIndex, 1);
                        coinsget = coinsget - price;
                        PlayerPrefs.SetInt("Cash", coinsget);
                        unlockCar();
                    }
                    else
                    { //not enough coins
                        no_coinPanel.SetActive(true);
                        Invoke("deactive_not_coin", 1f);
                    }
                    break;
                case 4:
                    if (goldget >= price)
                    { //buy car
                        PlayerPrefs.SetInt("Player" + carIndex, 1);
                        goldget = goldget - price;
                        PlayerPrefs.SetInt("Gold", goldget);
                        unlockCar();
                    }
                    else
                    { //not enough coins
                        no_coinPanel.SetActive(true);
                        Invoke("deactive_not_coin", 1f);
                    }
                    break;
                case 5:
                    if (coinsget >= price)
                    { //buy car
                        PlayerPrefs.SetInt("Player" + carIndex, 1);
                        coinsget = coinsget - price;
                        PlayerPrefs.SetInt("Cash",coinsget);
                        unlockCar();
                    }
                    else
                    { //not enough coins
                        no_coinPanel.SetActive(true);
                        Invoke("deactive_not_coin", 1f);
                    }
                    break;
            }
            
        }
        catch
        {

        }
    }
    void unlockCar() //set car status
    {
        try
        {
            if (PlayerPrefs.GetInt("Player" + carIndex).Equals(1))
            {
                selectBtn.SetActive(true);
                purchaseBtn.SetActive(false);
                UnlockallCars.SetActive(false);
                // Day_Counter_btn.SetActive(false);
            }
            else if (carIndex > 0)
            {
                selectBtn.SetActive(false);
                purchaseBtn.SetActive(true);
                UnlockallCars.SetActive(true);
                if (carIndex <= 5)
                {
                    showPrice();
                }
            }
            setIAPButtons();
        }
        catch { }
        
    }
    public void UnlockVehicles()
    {
        try
        {
            for (int i = 1; i < Player.Length; i++)
            {
                PlayerPrefs.SetInt("Player" + i, 1);
                PlayerPrefs.SetInt("Get_vehical", 1);
            }
            PlayerPrefs.SetInt("UnlockAllCar", 1);
            UnlockallCars.SetActive(false);
            UnlockallCars2.interactable = false;
            purchaseBtn.SetActive(false);
            selectBtn.SetActive(true);
        }
        catch
        {

        }
    }
    public Text carPriceTxt;
    public GameObject selectBtn;
    public GameObject purchaseBtn;
    public GameObject UnlockallCars;
    public Button UnlockallCars2;
    void showPrice() //set price text
    {
        try { 
        if (carIndex == 0 || carIndex == 1 || carIndex == 3 || carIndex == 5)
        {
            carPriceTxt.text = _price() + " CASH";
        }
        else if(carIndex == 2 || carIndex == 4)
        {
            carPriceTxt.text = _price() + " GOLD";
        }
        }
        catch { }
    }
    int _price() //get current car price
    {      
            int[] price = new int[] { 0, 2000, 1500, 7000, 3000, 10000 };
            return price[carIndex];      
        
    }
    void deactive_not_coin()
    {
        try
        {
            no_coinPanel.SetActive(false);
        }
        catch
        {
        }
    }

    public void OnQuitYes()
        {
        try { 
            Application.Quit();
        }
        catch { }
    }  
            
        public void BuyingCashPack1()
        {
        try { 
            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 1500);
              }
        catch { }
        }
        public void BuyingCashPack2()
        {
        try { 
            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 3500);
        }
        catch { }
    }
        public void BuyingCashPack3()
        {
        try { 
            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 6000);
        }
        catch { }
    }
        public void BuyingCashPack4()
        {
        try { 
            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 11500);
        }
        catch { }
    }
        public void BuyingGoldPack1()
        {
        try { 
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 750);
        }
        catch { }
    }
        public void BuyingGoldPack2()
        {
        try { 
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 1750);
        }
        catch { }
    }
        public void BuyingGoldPack3()
        {
        try { 
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 2500);
        }
        catch { }
    }
        public void BuyingGoldPack4()
        {
        try { 
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 3200);
        }
        catch { }
    }
        public void RemoveAds()
        {
        try { 
            PlayerPrefs.SetInt("Removeads", 1);
            AdsManager.Instance.isAdsPurchased = true;
            AdsManager.Instance.RemoveAllBanners();
            removeAdsButton.SetActive(false);
            removeAdsButton2.interactable = false;
        }
        catch { }
    }    
    public void UnlockAll()
    {
        try
        {
            for (int i = 1; i < Player.Length; i++)
            {
                PlayerPrefs.SetInt("Player" + i, 1);
                PlayerPrefs.SetInt("Get_vehical", 1);
            }
            UnlockallCars.SetActive(false);
            UnlockallCars2.interactable = false;
            PlayerPrefs.SetInt("Removeads", 1);
            AdsManager.Instance.isAdsPurchased = true;
            AdsManager.Instance.RemoveAllBanners();
            //AdsManager.Instance.DestroyInterstitial();
            removeAdsButton.SetActive(false);
            removeAdsButton2.interactable = false;
            levelbtn.interactable = false;
            LevelSelection.instance.UnLockAllLevels();
            unlockallbtn.interactable = false;
            PlayerPrefs.SetInt("unlockeverything",1);
            PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 2000);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 500);
            unlockModernMode.SetActive(false);
            unlockMultiplayerMode.SetActive(false);
        }
        catch
        {

        }
    }

    public void OpenPanel(GameObject Panel) 
        {
        try { 
            if (Panel != null)
            {
                Panel.SetActive(true);
            }
        }
        catch { }
    }
        public void ClosePanel(GameObject Panel)
        {
        try { 
            if (Panel != null)
            {
                Panel.SetActive(false);
            }
        }
        catch { }
    }
    public GameObject noInternet;
        public void OpenUrl(string url)
        {
        try { 
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            Application.OpenURL(url);
        }
        else 
        {
                noInternet.SetActive(true);
                NoInternettext.text = "INTERNET NOT AVAILABLE.";
                // StartCoroutine(noInternetstop(2.0f));
            }
        }
        catch { }
    }
    //IEnumerator noInternetstop(float timer) 
    //{
    //    yield return new WaitForSecondsRealtime(timer);
    //    noInternet.SetActive(false);
    //}

    public void Play() 
    {
        try { 
            garragePanel.SetActive(true);
            mainPanel.SetActive(false);
            CancelInvoke("showpack");
        if (count % 3 == 0 && !PlayerPrefs.GetInt("Player" + carIndex).Equals(1))
        {
            Invoke("OpenCarPanel", 1f);

        }
            showLastSelectedCar();
            count++;
        CustomAds.instance.stopAds();
        CustomAds.instance.callAds(ModeAds);
        }
        catch { }
    }
    public void ModeBack()
    {
        try { 
        modePanel.SetActive(false);
        garragePanel.SetActive(true);
        CustomAds.instance.stopAds();
        CustomAds.instance.callAds(MenuAds);

            AdsManager.Instance.ShowInterstitial();
            }
            catch { }
        
    }
    public void LoadProfile() 
    {
        try { 
        nameText.text = PlayerPrefs.GetString("username", "GUEST");
        foreach (GameObject av in avatar) 
        {
            av.SetActive(false);
        }
        avatar[PlayerPrefs.GetInt("avatar")].SetActive(true);
        }
        catch { }
    }
    public void ArrowControl() 
    {
        try { 
        RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.TouchScreen;
        }
        catch { }
    }
    public void SteeringControl()
    {
        try { 
        RCC_Settings.Instance.mobileController = RCC_Settings.MobileController.SteeringWheel;
        }
        catch { }
    }
    public void ControlSide(int value)
    {
        try { 
        PlayerPrefs.SetInt("ControlSide",value);
        }
        catch { }
    }
    void ControlOnStart()
    {
        try { 
        if (RCC_Settings.Instance.mobileController == RCC_Settings.MobileController.TouchScreen)
        {
            arrowToggle.isOn = true;
            steeringToggle.isOn = false;
        }
        else
        {
            steeringToggle.isOn = true;
            arrowToggle.isOn = false;
        }
        if (PlayerPrefs.GetInt("ControlSide", 0) == 0) 
        {
            leftControlToggle.isOn = true;
            rightControlToggle.isOn = false;
        }
        else 
        {
            rightControlToggle.isOn = true;
            leftControlToggle.isOn = false;
        }
        }
        catch { }
    }

    public void buyColor()
    {
        try { 
            rewardColorIap();
        }
        catch { }
    }
    public void buyRim()
    {
        try
        {
            rewardRimsIap();
        }
          
        catch { }
    }
    public void buyDecal()
    {
        try { 
            rewardDecalIap();
        }
        catch { }
    }
    public void openColorPanel()
    {
        try { 
        for (int i = 0; i < colorSets.Length; i++)
        {
            colorSets[i].SetActive(false);
        }
        UnlockallCars.SetActive(false);
        colorSets[carIndex].SetActive(true);
        colorPlayBtn.SetActive(true);
        colorPanel.SetActive(true);
        checkColorIap();
        }
        catch { }
    }
    void checkColorIap()
    {
        try { 
        bool purchased = true;
        for (int i = 1; i < 6; i++)
        {
            if (PlayerPrefs.GetInt("Car" + carIndex + "Color" + i) == 0)
            {
                purchased = false;
            }
        }
        colorIapBtn.SetActive(!purchased);
        }
        catch { }
    }
    public Text colorText;
    public int[] colorPrice;
    public Text DecalText;
    public int[] DecalPrice;
    public Text RimText;
    public int[] RimPrice;
    public void colorClicked(int index)
    {
        try { 
        selectedCustomize = index;
        if (PlayerPrefs.GetInt("Car" + carIndex + "Color" + index) == 1) //color purchased already
        {
            PlayerPrefs.SetInt("Car" + carIndex + "SelectedColor", selectedCustomize);
            if (PlayerPrefs.GetInt("Car" + (carIndex + 1) + "DecalSelected") != -1)
            {
                removeDecal();
            }
            setCarColor();
            colorCoinBtn.SetActive(false);
            colorAdBtn.SetActive(false);
            colorPlayBtn.SetActive(true);
            PlayerPrefs.SetInt("Car" + (carIndex + 1) + "DecalSelected", -1);
        }
        else
        {
            if (index == 0 || index == 1 || index == 2)
            {
                colorCoinBtn.SetActive(true);
                colorText.text = colorPrice[index] + " CASH";
                colorAdBtn.SetActive(false);
                colorPlayBtn.SetActive(false);
            }
            if ( index == 3 || index == 5)
            {
                colorCoinBtn.SetActive(true);
                colorText.text = colorPrice[index] + " GOLD";
                colorAdBtn.SetActive(false);
                colorPlayBtn.SetActive(false);
            }
            else if (index == 4 )
            {
                colorCoinBtn.SetActive(false);
                colorAdBtn.SetActive(true);
                colorPlayBtn.SetActive(false);
            }
                if (PlayerPrefs.GetInt("Car" + (carIndex + 1) + "DecalSelected") != -1)
                {
                    removeDecal();
                }
                setCarColor();
        }
        }
        catch { }
    }
    void setCarColor()
    {
        try { 
        Material[] mat = carBody[carIndex].GetComponent<MeshRenderer>().materials;

        if (carIndex == 0)
        {
            carBodyMat[carIndex].color = colorCode1[selectedCustomize];
            mat[0].color = colorCode1[selectedCustomize];
        }
        else if (carIndex == 1)
        {
            carBodyMat[carIndex].color = colorCode2[selectedCustomize];
            mat[0].color = colorCode2[selectedCustomize];
        }
        else if (carIndex == 2)
        {
            carBodyMat[carIndex].color = colorCode3[selectedCustomize];
            mat[0].color = colorCode3[selectedCustomize];
        }
        else if (carIndex == 3)
        {
            carBodyMat[carIndex].color = colorCode4[selectedCustomize];
            mat[0].color = colorCode4[selectedCustomize];
        }
        else if (carIndex == 4)
        {
            carBodyMat[carIndex].color = colorCode5[selectedCustomize];
            mat[0].color = colorCode5[selectedCustomize];
        }
        else if (carIndex == 5)
        {
            carBodyMat[carIndex].color = colorCode6[selectedCustomize];
            mat[0].color = colorCode6[selectedCustomize];
        }
        }
        catch { }
    }
    public void selectColorCoin()
    {
        try { 
        int coinss = PlayerPrefs.GetInt("Cash");
        int gold = PlayerPrefs.GetInt("Gold");
        if (coinss >= colorPrice[selectedCustomize] && (selectedCustomize == 0 || selectedCustomize == 1 || selectedCustomize == 2))
        {
            if (PlayerPrefs.GetInt("Car" + carIndex + "Color" + selectedCustomize) == 0)
            {
                coinss -= colorPrice[selectedCustomize];
                PlayerPrefs.SetInt("Cash", coinss);
               // coins.text = coinss + "";
                PlayerPrefs.SetInt("Car" + carIndex + "Color" + selectedCustomize, 1);
                rewardColorAd();
            }
        }
        else if (gold >= colorPrice[selectedCustomize] && (selectedCustomize == 3 || selectedCustomize == 5))
        {
            if (PlayerPrefs.GetInt("Car" + carIndex + "Color" + selectedCustomize) == 0)
            {
                gold -= colorPrice[selectedCustomize];
                PlayerPrefs.SetInt("Gold", gold);
                // coins.text = coinss + "";
                PlayerPrefs.SetInt("Car" + carIndex + "Color" + selectedCustomize, 1);
                rewardColorAd();
            }
        }
        else
        {
            coinWarning.SetActive(true);
            Invoke("disableCoinWarning", 1.5f);
        }
        }
        catch { }
    }
    public void setColorAd()
    {
        try {
            if (Application.internetReachability != NetworkReachability.NotReachable)
            {
                if (AdsManager.Instance.isAdmobRewardedReady())
                {
                    AdsManager.Instance.ShowAdmobRewardedAd();
                    colorAdBtn.GetComponent<Button>().interactable = false;
                    StartCoroutine(enableBtn(colorAdBtn));
                }
                else
                {
                    noInternet.SetActive(true);
                    NoInternettext.text = "REWARD NOT AVAILABLE THIS TIME.";
                }
            }
            else
            {
                noInternet.SetActive(true);
                NoInternettext.text = "INTERNET NOT AVAILABLE";
            }

        }
        catch { }
    }
    public void closeColorPanel()
    {
        try {
            if (PlayerPrefs.GetInt("Car" + carIndex + "Decal" + selectedCustomize) != 1)
            {
                if (PlayerPrefs.GetInt("Car" + carIndex + "Color" + selectedCustomize) != 1)
                {
                    selectedCustomize = PlayerPrefs.GetInt("Car" + carIndex + "SelectedColor");
                    setCarColor();

                    //if (PlayerPrefs.GetInt("Car" + carIndex + "Decal" + selectedCustomize) != 1)
                    //{
                    //    // setCarColor();
                    //    selectedCustomize = PlayerPrefs.GetInt("Car" + carIndex + "SelectedColor");
                    //    removeDecal();
                    //}
                    //else
                    //    setCarColor();
                    // removeDecal();
                }
            }
                if (colorIapBtn.activeInHierarchy)
                {
                    colorIapBtn.SetActive(false);
                }
                colorPanel.SetActive(false);
        }
        catch { }
    }
    public void rewardColorAd()
    {
        try { 
        PlayerPrefs.SetInt("Car" + (carIndex + 1) + "DecalSelected", -1);
        PlayerPrefs.SetInt("Car" + carIndex + "Color" + selectedCustomize, 1);
        PlayerPrefs.SetInt("Car" + carIndex + "SelectedColor", selectedCustomize);
        if (PlayerPrefs.GetInt("DecalSelected") == 1)
        {
            removeDecal();
        }
        setCarColor();
        if (carIndex == 0)
        {
            colorSet1[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 1)
        {
            colorSet2[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 2)
        {
            colorSet3[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 3)
        {
            colorSet4[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 4)
        {
            colorSet5[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 5)
        {
            colorSet6[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        colorCoinBtn.SetActive(false);
        colorAdBtn.SetActive(false);
        colorPlayBtn.SetActive(true);
        checkColorIap();
        }
        catch { }
    }
    public void rewardColorIap()
    {
        try { 
        if (carIndex == 0)
        {
            for (int i = 0; i < colorSet1.Length; i++)
            {
                colorSet1[i].transform.GetChild(0).gameObject.SetActive(false);
                PlayerPrefs.SetInt("Car0Color" + i, 1);
            }
        }
        else if (carIndex == 1)
        {
            for (int i = 0; i < colorSet2.Length; i++)
            {
                colorSet2[i].transform.GetChild(0).gameObject.SetActive(false);
                PlayerPrefs.SetInt("Car1Color" + i, 1);
            }
        }
        else if (carIndex == 2)
        {
            for (int i = 0; i < colorSet3.Length; i++)
            {
                colorSet3[i].transform.GetChild(0).gameObject.SetActive(false);
                PlayerPrefs.SetInt("Car2Color" + i, 1);
            }
        }
        else if (carIndex == 3)
        {
            for (int i = 0; i < colorSet4.Length; i++)
            {
                colorSet4[i].transform.GetChild(0).gameObject.SetActive(false);
                PlayerPrefs.SetInt("Car3Color" + i, 1);
            }
        }
        else if (carIndex == 4)
        {
            for (int i = 0; i < colorSet5.Length; i++)
            {
                colorSet5[i].transform.GetChild(0).gameObject.SetActive(false);
                PlayerPrefs.SetInt("Car4Color" + i, 1);
            }
        }
        else if (carIndex == 5)
        {
            for (int i = 0; i < colorSet6.Length; i++)
            {
                colorSet6[i].transform.GetChild(0).gameObject.SetActive(false);
                PlayerPrefs.SetInt("Car5Color" + i, 1);
            }
        }
        colorCoinBtn.SetActive(false);
        colorAdBtn.SetActive(false);
        colorPlayBtn.SetActive(true);
        colorIapBtn.SetActive(false);
        }
        catch { }
    }
    void unlockColors()
    {
        try { 
        PlayerPrefs.SetInt("Car0Color0", 1);
        PlayerPrefs.SetInt("Car1Color0", 1);
        PlayerPrefs.SetInt("Car2Color0", 1);
        PlayerPrefs.SetInt("Car3Color0", 1);
        PlayerPrefs.SetInt("Car4Color0", 1);
        PlayerPrefs.SetInt("Car5Color0", 1);
        if (!PlayerPrefs.HasKey("Car0SelectedColor"))
        {
            PlayerPrefs.SetInt("Car0SelectedColor", 0);
        }
        if (!PlayerPrefs.HasKey("Car1SelectedColor"))
        {
            PlayerPrefs.SetInt("Car1SelectedColor", 0);
        }
        if (!PlayerPrefs.HasKey("Car2SelectedColor"))
        {
            PlayerPrefs.SetInt("Car2SelectedColor", 0);
        }
        if (!PlayerPrefs.HasKey("Car3SelectedColor"))
        {
            PlayerPrefs.SetInt("Car3SelectedColor", 0);
        }
        if (!PlayerPrefs.HasKey("Car4SelectedColor"))
        {
            PlayerPrefs.SetInt("Car4SelectedColor", 0);
        }
        if (!PlayerPrefs.HasKey("Car5SelectedColor"))
        {
            PlayerPrefs.SetInt("Car5SelectedColor", 0);
        }
        for (int i = 0; i < colorSet1.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car0Color" + i) == 1)
            {
                colorSet1[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < colorSet2.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car1Color" + i) == 1)
            {
                colorSet2[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < colorSet3.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car2Color" + i) == 1)
            {
                colorSet3[i].transform.GetChild(0).gameObject.SetActive(false);

            }
        }
        for (int i = 0; i < colorSet4.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car3Color" + i) == 1)
            {
                colorSet4[i].transform.GetChild(0).gameObject.SetActive(false);

            }
        }
        for (int i = 0; i < colorSet5.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car4Color" + i) == 1)
            {
                colorSet5[i].transform.GetChild(0).gameObject.SetActive(false);

            }
        }
        for (int i = 0; i < colorSet6.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car5Color" + i) == 1)
            {
                colorSet6[i].transform.GetChild(0).gameObject.SetActive(false);

            }
        }
        for (int i = 0; i < Player.Length; i++)
        {               
                if (PlayerPrefs.GetInt("Car" + (i + 1) + "DecalSelected") != 1)
                {
                    int selectedCustomizee = PlayerPrefs.GetInt("Car" + i + "SelectedColor");
                    if (i == 0)
                    {
                        carBodyMat[i].color = colorCode1[selectedCustomizee];
                    }
                    else if (i == 1)
                    {
                        carBodyMat[i].color = colorCode2[selectedCustomizee];
                    }
                    else if (i == 2)
                    {
                        carBodyMat[i].color = colorCode3[selectedCustomizee];
                    }
                    else if (i == 3)
                    {
                        carBodyMat[i].color = colorCode4[selectedCustomizee];
                    }
                    else if (i == 4)
                    {
                        carBodyMat[i].color = colorCode5[selectedCustomizee];
                    }
                    else if (i == 5)
                    {
                        carBodyMat[i].color = colorCode5[selectedCustomizee];
                    }
                    else if (i == 6)
                    {
                        carBodyMat[i].color = colorCode6[selectedCustomizee];
                    }
                }
        }
        }
        catch { }

    }
    public void openDecalPanel()
    {
        try { 
        for (int i = 0; i < decalSets.Length; i++)
        {
            decalSets[i].SetActive(false);
        }
        DecalPanel.SetActive(true);
        UnlockallCars.SetActive(false);
        decalSets[carIndex].SetActive(true);
        decalPlayBtn.SetActive(true);

        if (carIndex == 0)
        {
            carDefaultMat = carBody[carIndex].GetComponent<MeshRenderer>().materials[0];
        }
        else
        {
            carDefaultMat = carBody[carIndex].GetComponent<MeshRenderer>().materials[0];
        }
        checkDecalIap();
        }
        catch { }
    }   
     public void checkDecalIap()
    {
        try { 
        bool purchased = true;
        for (int i = 1; i < 5; i++)
        {
            if (PlayerPrefs.GetInt("Car" + carIndex + "Decal" + i) == 0)
            {
                purchased = false;
            }
        }
        decalIapBtn.SetActive(!purchased);
        }
        catch { }
    }
    void unlockDecals()
    {
        try { 
        for (int i = 0; i < decalSet1.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car0Decal" + i) == 1) //locks
            {
                decalSet1[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < decalSet2.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car1Decal" + i) == 1)
            {
                decalSet2[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < decalSet3.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car2Decal" + i) == 1)
            {
                decalSet3[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < decalSet4.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car3Decal" + i) == 1)
            {
                decalSet4[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < decalSet5.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car4Decal" + i) == 1)
            {
                decalSet5[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < decalSet6.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car5Decal" + i) == 1)
            {
                decalSet6[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < Player.Length; i++)
        {
            if (PlayerPrefs.HasKey("Car" + (i + 1) + "DecalSelected"))
            {
                int decalSelected = PlayerPrefs.GetInt("Car" + (i + 1) + "DecalSelected");
                if (decalSelected != -1)
                {
                    Material[] mat = carBody[i].GetComponent<MeshRenderer>().materials;
                    if (i == 0)
                    {
                        mat[0] = carDecals[decalSelected];
                    }
                    else if(i == 1)
                    {
                        mat[0] = carDecals1[decalSelected];
                    }
                    else if (i == 2)
                    {
                        mat[0] = carDecals2[decalSelected];
                    }
                    else if (i == 3)
                    {
                        mat[0] = carDecals3[decalSelected];
                    }
                    else if (i == 4)
                    {
                        mat[0] = carDecals4[decalSelected];
                    }
                    else if (i == 5)
                    {
                        mat[0] = carDecals5[decalSelected];
                    }
                    carBody[i].GetComponent<MeshRenderer>().materials = mat;
                }
            }
                else 
                {
                    PlayerPrefs.SetInt("Car" + (i + 1) + "DecalSelected", -1);
                }
            }
        }
        catch { }
    }
    public void decalClicked(int index)
    {
        try { 
        selectedCustomize = index;
        if (PlayerPrefs.GetInt("Car" + carIndex + "Decal" + index) == 1) //color purchased already
        {
            //Material[] mat = carBody[carIndex].GetComponent<MeshRenderer>().materials;
            //if (carIndex == 0)
            //{
            //    mat[0] = carDecals[selectedCustomize];
                PlayerPrefs.SetInt("Car" + (carIndex + 1) + "DecalSelected", selectedCustomize);
            //}
            //else if (carIndex == 1)
            //{
            //    mat[0] = carDecals1[selectedCustomize];
            //    PlayerPrefs.SetInt("Car2DecalSelected", selectedCustomize);
            //}
            //else if (carIndex == 2)
            //{
            //    mat[0] = carDecals2[selectedCustomize];
            //    PlayerPrefs.SetInt("Car3DecalSelected", selectedCustomize);
            //}
            //else if (carIndex == 3)
            //{
            //    mat[0] = carDecals3[selectedCustomize];
            //    PlayerPrefs.SetInt("Car4DecalSelected", selectedCustomize);
            //}
            //else if (carIndex == 4)
            //{
            //    mat[0] = carDecals4[selectedCustomize];
            //    PlayerPrefs.SetInt("Car5DecalSelected", selectedCustomize);
            //}
            //else if (carIndex == 5)
            //{
            //    mat[0] = carDecals5[selectedCustomize];
            //    PlayerPrefs.SetInt("Car6DecalSelected", selectedCustomize);
            //}
            changedecal();
            //carBody[carIndex].GetComponent<MeshRenderer>().materials = mat;
            decalAdBtn.SetActive(false);
            decalCoinBtn.SetActive(false);
            decalPlayBtn.SetActive(true);
        }
        else
        {
            //Material[] mat = carBody[carIndex].GetComponent<MeshRenderer>().materials;
            //if (carIndex == 0)
            //{
            //    mat[0] = carDecals[selectedCustomize];
            //}

            //carBody[carIndex].GetComponent<MeshRenderer>().materials = mat;
            if (index == 0 || index == 1 || index == 3 )
            {
                decalCoinBtn.SetActive(true);
                decalAdBtn.SetActive(false);
                decalPlayBtn.SetActive(false);
                DecalText.text = DecalPrice[selectedCustomize] + " CASH";
            }
            else if ( index == 2 || index == 5)
            {
                decalCoinBtn.SetActive(true);
                decalAdBtn.SetActive(false);
                decalPlayBtn.SetActive(false);
                DecalText.text = DecalPrice[selectedCustomize] + " GOLD";
            }
            else if (index == 4)
            {
                decalCoinBtn.SetActive(false);
                decalAdBtn.SetActive(true);
                decalPlayBtn.SetActive(false);
            }
            changedecal();
        }
        }
        catch { }
    }
        void changedecal() 
        {
        try
        {
            Material[] mat = carBody[carIndex].GetComponent<MeshRenderer>().materials;
            if (carIndex == 0)
            {
                mat[0] = carDecals[selectedCustomize];
                // PlayerPrefs.SetInt("Car1DecalSelected", selectedCustomize);
            }
            else if (carIndex == 1)
            {
                mat[0] = carDecals1[selectedCustomize];
                //PlayerPrefs.SetInt("Car2DecalSelected", selectedCustomize);
            }
            else if (carIndex == 2)
            {
                mat[0] = carDecals2[selectedCustomize];
                // PlayerPrefs.SetInt("Car3DecalSelected", selectedCustomize);
            }
            else if (carIndex == 3)
            {
                mat[0] = carDecals3[selectedCustomize];
                // PlayerPrefs.SetInt("Car4DecalSelected", selectedCustomize);
            }
            else if (carIndex == 4)
            {
                mat[0] = carDecals4[selectedCustomize];
                // PlayerPrefs.SetInt("Car5DecalSelected", selectedCustomize);
            }
            else if (carIndex == 5)
            {
                mat[0] = carDecals5[selectedCustomize];
                // PlayerPrefs.SetInt("Car6DecalSelected", selectedCustomize);
            }
            carBody[carIndex].GetComponent<MeshRenderer>().materials = mat;
        
          }
        catch { }
    }
    public void selectDecalCoin()
    {
        try { 
        int coinss = PlayerPrefs.GetInt("Cash");
        int gold = PlayerPrefs.GetInt("Gold");
        if (coinss >= DecalPrice[selectedCustomize] && (selectedCustomize == 0 ||selectedCustomize == 1 || selectedCustomize == 3))
        {
            if (PlayerPrefs.GetInt("Car" + carIndex + "Decal" + selectedCustomize) == 0)
            {
                coinss -= DecalPrice[selectedCustomize];
                PlayerPrefs.SetInt("Cash",  coinss);
                PlayerPrefs.SetInt("Car" + carIndex + "Decal" + selectedCustomize, 1);
                rewardDecalAd();
            }
        }
       else if (gold >= DecalPrice[selectedCustomize] && (selectedCustomize == 2 || selectedCustomize == 5))
        {
            if (PlayerPrefs.GetInt("Car" + carIndex + "Decal" + selectedCustomize) == 0)
            {
                gold -= DecalPrice[selectedCustomize];
                PlayerPrefs.SetInt("Gold", gold);
                PlayerPrefs.SetInt("Car" + carIndex + "Decal" + selectedCustomize, 1);
                rewardDecalAd();
            }
        }
        else
        {
            coinWarning.SetActive(true);
            Invoke("disableCoinWarning", 1.5f);
        }
        }
        catch { }
    }

    public void setDecalAd()
    {
        try {
            if (Application.internetReachability != NetworkReachability.NotReachable)
            {
                if (AdsManager.Instance.isAdmobRewardedReady())
                {

                    AdsManager.Instance.ShowAdmobRewardedAd();
                    decalAdBtn.GetComponent<Button>().interactable = false;
                    StartCoroutine(enableBtn(decalAdBtn));
                }
                else
                {
                    noInternet.SetActive(true);
                    NoInternettext.text = "REWARD NOT AVAILABLE THIS TIME.";
                }
                }
                else
                {
                    noInternet.SetActive(true);
                    NoInternettext.text = "INTERNET NOT AVAILABLE";
                }
            }
        catch { }
    }
    public void rewardDecalAd()
    {
        try { 
        PlayerPrefs.SetInt("Car" + carIndex + "Decal" + selectedCustomize, 1);
        PlayerPrefs.SetInt("Car" + (carIndex + 1) + "DecalSelected", selectedCustomize);
        Material[] mat = carBody[carIndex].GetComponent<MeshRenderer>().materials;
        if (carIndex == 0)
        {
            mat[0] = carDecals[selectedCustomize];
            decalSet1[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 1)
        {
            mat[0] = carDecals1[selectedCustomize];
            decalSet2[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 2)
        {
            mat[0] = carDecals2[selectedCustomize];
            decalSet3[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 3)
        {
            mat[0] = carDecals3[selectedCustomize];
            decalSet4[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 4)
        {
            mat[0] = carDecals4[selectedCustomize];
            decalSet5[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 5)
        {
            mat[0] = carDecals5[selectedCustomize];
            decalSet6[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        carBody[carIndex].GetComponent<MeshRenderer>().materials = mat;
        decalCoinBtn.SetActive(false);
        decalAdBtn.SetActive(false);
        decalPlayBtn.SetActive(true);
        checkDecalIap();
        }
        catch { }
    }
   
    public void removeDecal()
    {
        try { 
        Material[] mat = carBody[carIndex].GetComponent<MeshRenderer>().materials;
        if (carIndex == 0)
        {
            mat[0] = carBodyMat[carIndex];
        }
        else
        {
            mat[0] = carBodyMat[carIndex];
        }
        carBody[carIndex].GetComponent<MeshRenderer>().materials = mat;
        PlayerPrefs.SetInt("Car" + (carIndex + 1) + "DecalSelected", -1);
        }
        catch { }
    }
    public void closeDecal()
    {
        try { 
        if (PlayerPrefs.GetInt("Car" + carIndex + "Decal" + selectedCustomize) != 1)
        {
            if (PlayerPrefs.GetInt("Car" + (carIndex + 1) + "DecalSelected") != 1)
            {
                PlayerPrefs.SetInt("Car" + (carIndex + 1) + "DecalSelected", -1);
            }
            Material[] mat = carBody[carIndex].GetComponent<MeshRenderer>().materials;
            if (carIndex == 0)
            {
                mat[0] = carDefaultMat;
            }
            else
            {
                mat[0] = carDefaultMat;
            }
            carBody[carIndex].GetComponent<MeshRenderer>().materials = mat;
        }
        if (decalIapBtn.activeInHierarchy)
        {
            decalIapBtn.SetActive(false);
        }
        DecalPanel.SetActive(false);
        }
        catch { }
    }
    public void rewardDecalIap()
    {
        try { 
        if (carIndex == 0)
        {
            for (int i = 0; i < decalSet1.Length; i++)
            {
                PlayerPrefs.SetInt("Car0Decal" + i, 1);
                decalSet1[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else if (carIndex == 1)
        {
            for (int i = 0; i < decalSet2.Length; i++)
            {
                PlayerPrefs.SetInt("Car1Decal" + i, 1);
                decalSet2[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else if (carIndex == 2)
        {
            for (int i = 0; i < decalSet3.Length; i++)
            {
                PlayerPrefs.SetInt("Car2Decal" + i, 1);
                decalSet3[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else if (carIndex == 3)
        {
            for (int i = 0; i < decalSet4.Length; i++)
            {
                PlayerPrefs.SetInt("Car3Decal" + i, 1);
                decalSet4[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else if (carIndex == 4)
        {
            for (int i = 0; i < decalSet5.Length; i++)
            {
                PlayerPrefs.SetInt("Car4Decal" + i, 1);
                decalSet5[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else if (carIndex == 5)
        {
            for (int i = 0; i < decalSet6.Length; i++)
            {
                PlayerPrefs.SetInt("Car5Decal" + i, 1);
                decalSet6[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        decalIapBtn.SetActive(false);
        decalCoinBtn.SetActive(false);
        decalAdBtn.SetActive(false);
        decalPlayBtn.SetActive(true);
        }
        catch { }
    }

    public void openRimPanel()
    {
        try { 
        for (int i = 0; i < rimSets.Length; i++)
        {
            rimSets[i].SetActive(false);
        }
        RimPanel.SetActive(true);
        UnlockallCars.SetActive(false);
        rimSets[carIndex].SetActive(true);
        rimPlayBtn.SetActive(true);
        checkRimIap();
        }
        catch { }
    }
    void checkRimIap()
    {
        try { 
        bool purchased = true;
        for (int i = 1; i < 6; i++)
        {
            if (PlayerPrefs.GetInt("Car" + carIndex + "Rim" + i) == 0)
            {
                purchased = false;
            }
        }
        rimIapBtn.SetActive(!purchased);
        }
        catch { }
    }
    public void rimClicked(int index)
    {
        try { 
        selectedCustomize = index;
        if (PlayerPrefs.GetInt("Car" + carIndex + "Rim" + index) == 1) 
        {
            changeRim();
            PlayerPrefs.SetInt("Car" + (carIndex + 1) + "RimSelected", selectedCustomize);
            rimAdBtn.SetActive(false);
            rimCoinBtn.SetActive(false);
            rimPlayBtn.SetActive(true);
        }
        else
        {
            if (index == 0 || index == 1 || index == 2)
            {
                rimCoinBtn.SetActive(true);
                rimAdBtn.SetActive(false);
                RimText.text = RimPrice[selectedCustomize]+" CASH";
                rimPlayBtn.SetActive(false);
                
            }
            else if (index == 3 || index == 4 )
            {
                rimCoinBtn.SetActive(true);
                rimAdBtn.SetActive(false);
                RimText.text = RimPrice[selectedCustomize] + " GOLD";
                rimPlayBtn.SetActive(false);
            }
            else if (index == 5)
            {
                rimCoinBtn.SetActive(false);
                rimAdBtn.SetActive(true);
                rimPlayBtn.SetActive(false);
            }
            changeRim();
        }
        }
        catch { }
    }
    void changeRim()
    {
        try { 
        if (carIndex == 0)
        {
            for (int i = 0; i < car1RimModel.Length; i++)
            {
                car1RimModel[i].SetActive(false);
            }
            car1RimModel[selectedCustomize].SetActive(true);
        }
        else if (carIndex == 1)
        {
            for (int i = 0; i < car2RimModel.Length; i++)
            {
                car2RimModel[i].SetActive(false);
            }
            car2RimModel[selectedCustomize].SetActive(true);
        }
        else if (carIndex == 2)
        {
            for (int i = 0; i < car3RimModel.Length; i++)
            {
                car3RimModel[i].SetActive(false);
            }
            car3RimModel[selectedCustomize].SetActive(true);
        }
        else if (carIndex == 3)
        {
            for (int i = 0; i < car4RimModel.Length; i++)
            {
                car4RimModel[i].SetActive(false);
            }
            car4RimModel[selectedCustomize].SetActive(true);
        }
        else if (carIndex == 4)
        {
            for (int i = 0; i < car5RimModel.Length; i++)
            {
                car5RimModel[i].SetActive(false);
            }
            car5RimModel[selectedCustomize].SetActive(true);
        }
        else if (carIndex == 5)
        {
            for (int i = 0; i < car6RimModel.Length; i++)
            {
                car6RimModel[i].SetActive(false);
            }
            car6RimModel[selectedCustomize].SetActive(true);
        }
        }
        catch { }
    }
    public void selectRimCoin()
    {
        try { 
        int coinss = PlayerPrefs.GetInt("Cash");
        int gold = PlayerPrefs.GetInt("Gold");
        if (coinss >= RimPrice[selectedCustomize] && (selectedCustomize == 0 || selectedCustomize == 1 || selectedCustomize == 2))
        {
            if (PlayerPrefs.GetInt("Car" + carIndex + "Rim" + selectedCustomize) == 0)
            {
                coinss -= RimPrice[selectedCustomize];
                PlayerPrefs.SetInt("Cash", coinss);
                //coins.text = coinss + "";
                PlayerPrefs.SetInt("Car" + carIndex + "Rim" + selectedCustomize, 1);
                rewardRimAd();
            }
        }
        else if (gold >= RimPrice[selectedCustomize] && (selectedCustomize == 3 || selectedCustomize == 4))
        {
            if (PlayerPrefs.GetInt("Car" + carIndex + "Rim" + selectedCustomize) == 0)
            {
                gold -= RimPrice[selectedCustomize];
                PlayerPrefs.SetInt("Gold", gold);
                //coins.text = coinss + "";
                PlayerPrefs.SetInt("Car" + carIndex + "Rim" + selectedCustomize, 1);
                rewardRimAd();
            }
        }
        else
        {
            coinWarning.SetActive(true);
            Invoke("disableCoinWarning", 1.5f);
        }
        }
        catch { }
    }
    public void setRimAd()
    {
        try {
            if (Application.internetReachability != NetworkReachability.NotReachable)
            {
                if (AdsManager.Instance.isAdmobRewardedReady())
                {
                    AdsManager.Instance.ShowAdmobRewardedAd();
            rimAdBtn.GetComponent<Button>().interactable = false;
            StartCoroutine(enableBtn(rimAdBtn));
        }
            else
            {
                noInternet.SetActive(true);
                NoInternettext.text = "REWARD NOT AVAILABLE THIS TIME.";
            }
        }
            else
        {
            noInternet.SetActive(true);
            NoInternettext.text = "INTERNET NOT AVAILABLE";
        }
    }
        catch { }
    }
    public void rewardRimAd()
    {
        try { 
        PlayerPrefs.SetInt("Car" + carIndex + "Rim" + selectedCustomize, 1);
        PlayerPrefs.SetInt("Car" + (carIndex + 1) + "RimSelected", selectedCustomize);
        changeRim();
        if (carIndex == 0)
        {
            rimSet1[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 1)
        {
            rimSet2[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 2)
        {
            rimSet3[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 3)
        {
            rimSet4[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 4)
        {
            rimSet5[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (carIndex == 5)
        {
            rimSet6[selectedCustomize].transform.GetChild(0).gameObject.SetActive(false);
        }
        rimAdBtn.SetActive(false);
        rimCoinBtn.SetActive(false);
        rimPlayBtn.SetActive(true);
        checkRimIap();
        }
        catch { }
    }
    public void rewardRimsIap()
    {
        try
        {
            if (carIndex == 0)
            {
                for (int i = 0; i < rimSet1.Length; i++)
                {
                    rimSet1[i].transform.GetChild(0).gameObject.SetActive(false);
                    PlayerPrefs.SetInt("Car0Rim" + i, 1);
                }
            }
            else if (carIndex == 1)
            {
                for (int i = 0; i < rimSet2.Length; i++)
                {
                    rimSet2[i].transform.GetChild(0).gameObject.SetActive(false);
                    PlayerPrefs.SetInt("Car1Rim" + i, 1);
                }
            }
            else if (carIndex == 2)
            {
                for (int i = 0; i < rimSet3.Length; i++)
                {
                    rimSet3[i].transform.GetChild(0).gameObject.SetActive(false);
                    PlayerPrefs.SetInt("Car2Rim" + i, 1);
                }
            }
            else if (carIndex == 3)
            {
                for (int i = 0; i < rimSet4.Length; i++)
                {
                    rimSet4[i].transform.GetChild(0).gameObject.SetActive(false);
                    PlayerPrefs.SetInt("Car3Rim" + i, 1);
                }
            }
            else if (carIndex == 4)
            {
                for (int i = 0; i < rimSet5.Length; i++)
                {
                    rimSet5[i].transform.GetChild(0).gameObject.SetActive(false);
                    PlayerPrefs.SetInt("Car4Rim" + i, 1);
                }
            }
            else if (carIndex == 5)
            {
                for (int i = 0; i < rimSet6.Length; i++)
                {
                    rimSet6[i].transform.GetChild(0).gameObject.SetActive(false);
                    PlayerPrefs.SetInt("Car4Rim" + i, 1);
                }
            }
            rimIapBtn.SetActive(false);
            rimCoinBtn.SetActive(false);
            rimAdBtn.SetActive(false);
            rimPlayBtn.SetActive(true);
        }
        catch { }
    }
    void unlockRims()
    {
        try { 
        PlayerPrefs.SetInt("Car0Rim0", 1);
        PlayerPrefs.SetInt("Car1Rim0", 1);
        PlayerPrefs.SetInt("Car2Rim0", 1);
        PlayerPrefs.SetInt("Car3Rim0", 1);
        PlayerPrefs.SetInt("Car4Rim0", 1);
        PlayerPrefs.SetInt("Car5Rim0", 1);
        for (int i = 0; i < rimSet1.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car0" + "Rim" + i) == 1) //locks
            {
                rimSet1[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            ///active last selected rim model
            if (!PlayerPrefs.HasKey("Car1RimSelected"))
            {
                PlayerPrefs.SetInt("Car1RimSelected", 0);
                car1RimModel[0].SetActive(true);
            }
            else
            {
                for (int j = 0; j < car1RimModel.Length; j++)
                {
                    car1RimModel[j].SetActive(false);
                }
                car1RimModel[PlayerPrefs.GetInt("Car1RimSelected")].SetActive(true);
            }
        }
        for (int i = 0; i < rimSet2.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car1" + "Rim" + i) == 1)
            {
                rimSet2[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            ///active last selected rim model
            if (!PlayerPrefs.HasKey("Car2RimSelected"))
            {
                PlayerPrefs.SetInt("Car2RimSelected", 0);
                car2RimModel[0].SetActive(true);
            }
            else
            {
                for (int j = 0; j < car2RimModel.Length; j++)
                {
                    car2RimModel[j].SetActive(false);
                }
                car2RimModel[PlayerPrefs.GetInt("Car2RimSelected")].SetActive(true);
            }
        }
        for (int i = 0; i < rimSet3.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car2" + "Rim" + i) == 1)
            {
                rimSet3[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            ///active last selected rim model
            if (!PlayerPrefs.HasKey("Car3RimSelected"))
            {
                PlayerPrefs.SetInt("Car3RimSelected", 0);
                car3RimModel[0].SetActive(true);
            }
            else
            {
                for (int j = 0; j < car3RimModel.Length; j++)
                {
                    car3RimModel[j].SetActive(false);
                }
                car3RimModel[PlayerPrefs.GetInt("Car3RimSelected")].SetActive(true);
            }
        }
        for (int i = 0; i < rimSet4.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car3" + "Rim" + i) == 1)
            {
                rimSet4[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            ///active last selected rim model
            if (!PlayerPrefs.HasKey("Car4RimSelected"))
            {
                PlayerPrefs.SetInt("Car4RimSelected", 0);
                car4RimModel[0].SetActive(true);
            }
            else
            {
                for (int j = 0; j < car4RimModel.Length; j++)
                {
                    car4RimModel[j].SetActive(false);
                }
                car4RimModel[PlayerPrefs.GetInt("Car4RimSelected")].SetActive(true);
            }
        }
        for (int i = 0; i < rimSet5.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car4" + "Rim" + i) == 1)
            {
                rimSet5[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            ///active last selected rim model
            if (!PlayerPrefs.HasKey("Car5RimSelected"))
            {
                PlayerPrefs.SetInt("Car5RimSelected", 0);
                car5RimModel[0].SetActive(true);
            }
            else
            {
                for (int j = 0; j < car5RimModel.Length; j++)
                {
                    car5RimModel[j].SetActive(false);
                }
                car5RimModel[PlayerPrefs.GetInt("Car5RimSelected")].SetActive(true);
            }
        }
        for (int i = 0; i < rimSet6.Length; i++)
        {
            if (PlayerPrefs.GetInt("Car5" + "Rim" + i) == 1)
            {
                rimSet6[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            ///active last selected rim model
            if (!PlayerPrefs.HasKey("Car6RimSelected"))
            {
                PlayerPrefs.SetInt("Car6RimSelected", 0);
                car6RimModel[0].SetActive(true);
            }
            else
            {
                for (int j = 0; j < car6RimModel.Length; j++)
                {
                    car6RimModel[j].SetActive(false);
                }
                car6RimModel[PlayerPrefs.GetInt("Car6RimSelected")].SetActive(true);
            }
        }
        }
        catch { }
    }
    public void closeRimPanel()
    {
        try { 
        if (PlayerPrefs.GetInt("Car" + carIndex + "Rim" + selectedCustomize) != 1)
        {
            int lastRim = PlayerPrefs.GetInt("Car" + (carIndex + 1) + "RimSelected");
            if (carIndex == 0)
            {
                for (int i = 0; i < car1RimModel.Length; i++)
                {
                    car1RimModel[i].SetActive(false);
                }
                car1RimModel[lastRim].SetActive(true);
            }
            else if (carIndex == 1)
            {
                for (int i = 0; i < car2RimModel.Length; i++)
                {
                    car2RimModel[i].SetActive(false);
                }
                car2RimModel[lastRim].SetActive(true);
            }
            else if (carIndex == 2)
            {
                for (int i = 0; i < car3RimModel.Length; i++)
                {
                    car3RimModel[i].SetActive(false);
                }
                car3RimModel[lastRim].SetActive(true);
            }
            else if (carIndex == 3)
            {
                for (int i = 0; i < car4RimModel.Length; i++)
                {
                    car4RimModel[i].SetActive(false);
                }
                car4RimModel[lastRim].SetActive(true);
            }
            else if (carIndex == 4)
            {
                for (int i = 0; i < car5RimModel.Length; i++)
                {
                    car5RimModel[i].SetActive(false);
                }
                car5RimModel[lastRim].SetActive(true);
            }
            else if (carIndex == 5)
            {
                for (int i = 0; i < car6RimModel.Length; i++)
                {
                    car6RimModel[i].SetActive(false);
                }
                car6RimModel[lastRim].SetActive(true);
            }
        }
        if (rimIapBtn.activeInHierarchy)
        {
            rimIapBtn.SetActive(false);
        }
        RimPanel.SetActive(false);
        }
        catch { }
    }
    public void showCoinWarning()
    {
        try { 
        if (coinWarning.activeInHierarchy == false)
        {
            coinWarning.SetActive(true);
            Invoke("disableCoinWarning", 1.5f);
        }
        }
        catch { }
    }

    public void showAdWarning()
    {
        try {
        if (adWarning.activeInHierarchy == false)
        {
            adWarning.SetActive(true);
            Invoke("disableAdWarning", 1.5f);
        }
        }
        catch { }
    }
    void disableAdWarning()
    {
        try { 
        adWarning.SetActive(false);
        }
        catch { }
    }
    void disableCoinWarning()
    {
        try { 
        coinWarning.SetActive(false);
        }
        catch { }
    }
    IEnumerator enableBtn(GameObject btn)
    {
        yield return new WaitForSeconds(1f);
        btn.GetComponent<Button>().interactable = true;
    }


    public void setIAPButtons()
    {
        try
        {
           
            bool unlock = false;
            for (int i = 1; i < Player.Length; i++)
            {
                if (!PlayerPrefs.GetInt("Player" + i).Equals(1))
                {
                    unlock = false;
                    break;
                }
                else
                {
                    unlock = true;
                }
            }
            if (unlock)
            {
                UnlockallCars.SetActive(false);
                UnlockallCars2.interactable = false;
}
           
        }
        catch
        {

        }
    }



    // ADS
    public void ShowAdsInter() 
    {
        try {
            AdsManager.Instance.ShowInterstitial();
           
        }
        catch { }
    }
    public void ShowAdsUnity()
    {
        try {
            //AdsManager.Instance.ShowUnity();
            AdsManager.Instance.ShowInterstitial();
        }
        catch { }
    }
    public Text NoInternettext;
    public void GetFreeCash()
    {
        try { 
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
                if (AdsManager.Instance.isAdmobRewardedReady()) {
                    AdsManager.Instance.ShowAdmobRewardedAd();
                }
                else
                {
                    noInternet.SetActive(true);
                    NoInternettext.text = "REWARD NOT AVAILABLE THIS TIME.";
                    //StartCoroutine(noInternetstop(2.0f));
                }
            }
        else
        {
            noInternet.SetActive(true);
                NoInternettext.text = "INTERNET NOT AVAILABLE.";
            }
        }
        catch { }
    }
    public GameObject ExitPanel;
    public void ExitPanelOn() 
    {
        try { 
        ExitPanel.SetActive(true);
            //AdsManager.Instance.ShowUnity();
            AdsManager.Instance.ShowInterstitial();
        }
        catch { }
    }
    public void ExitPanelOff()
    {
        try { 
        ExitPanel.SetActive(false);
            AdsManager.Instance.ShowInterstitial();
        }
        catch { }
    }
    public static int count=0;
    public void OpenGarrage() 
    {
        try { 
        garragePanel.SetActive(true);
        mainPanel.SetActive(false);
            showLastSelectedCar();
        if (count % 3 == 0  && !PlayerPrefs.GetInt("Player" + carIndex).Equals(1))
        {
            Invoke("OpenCarPanel", 1f);

        }
        count++;
        }
        catch { }
    }

    void OpenCarPanel() 
    {
        try {
            if (PlayerPrefs.GetInt("unlockeverything") == 1 || PlayerPrefs.GetInt("UnlockAllCar") == 1)
            {
                carLockpanel.SetActive(false);
            }
            else
            {
                carLockpanel.SetActive(true);
            }
           
        }
        catch { }
    }
    public void ShowInterstitial()
    {
        AdsManager.Instance.ShowInterstitial();
    }
}


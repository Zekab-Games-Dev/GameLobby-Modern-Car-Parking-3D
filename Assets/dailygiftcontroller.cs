using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//namespace Assets.SimpleAndroidNotifications
//{


    public class dailygiftcontroller : MonoBehaviour
    {
 

        public DateTime lastgiftdatetime;
        public int dayscount;

        private int maxdaycount;
        private bool canusergetgift;

        public string daytext = "DAY";
       // public string gifttext = "";
        public Action<int> onuserwantgift;

        private List<dailybonus> items;
        //public AudioSource source;
       // public MainMenuManager mainscript;

        void Awake()
        {

            load();
            items = new List<dailybonus>(transform.GetComponentsInChildren<dailybonus>());
            daily();

        }

        void save()
        {
        try { 
            PlayerPrefs.SetInt("dayscount", dayscount);
            PlayerPrefs.SetString("lastgiftdatetime", lastgiftdatetime.ToLongDateString());
            Invoke("dailyFalsePanel", 1f);
        }
        catch { }
    }
        void load()
        {
        try { 
            dayscount = PlayerPrefs.GetInt("dayscount");
            
            if (PlayerPrefs.HasKey("lastgiftdatetime"))
                lastgiftdatetime = DateTime.Parse(PlayerPrefs.GetString("lastgiftdatetime"));
            //print(lastgiftdatetime.Day);
           // if(lastgiftdatetime.AddDays(1){
            if (DateTime.Now.AddDays(-1).Day == lastgiftdatetime.Day)
            {
            //LocalNotification.SendNotification(1, 5000, "Title", "Long message text", new Color32(0xff, 0x44, 0x44, 255));
            //var notificationParams = new NotificationParams
            //{
            //    Id = UnityEngine.Random.Range(0, int.MaxValue),
            //    Delay = TimeSpan.FromSeconds(5),
            //    Title = "Daily Bonus!",
            //    Message = "Come and grab your daily Bonus!",
            //    Ticker = "Ticker",
            //    Sound = true,
            //    Vibrate = true,
            //    Light = true,
            //    SmallIcon = NotificationIcon.Message,
            //    SmallIconColor = new Color(0, 0.5f, 0),
            //    LargeIcon = "app_icon"
            //};

            //NotificationManager.SendCustom(notificationParams);
        }
        }
        catch { }
        //  print("ho gyea ha");
        // }
    }
        void setinfos()
        {
        try { 
            for (int i = 0; i < items.Count; i++)
            {
                short status = 0;
                if (dayscount == i && canusergetgift)
                {
                    status = 1;
                }
                else if (dayscount > i)
                {
                    status = 2;

                }
                items[i].setinfo(this, string.Format("{0} {1}", daytext , i+1), string.Format("{0} {1}", (i+1) * 100 +" "+"CASH"+ " "+ i*10 +" GOLD", null), status);
            }
        }
        catch { }

    }

    public void MyStart(Action<int> callback, int maxdayscount = 7)
        {
        try { 
            if (callback != null)
                onuserwantgift = callback;


            if (DateTime.Now.AddDays(-1).Day == lastgiftdatetime.Day && DateTime.Now.AddDays(-1).Month == lastgiftdatetime.Month)
            {
                
                canusergetgift = true;
            
            }
            else if (DateTime.Now.Day == lastgiftdatetime.Day && DateTime.Now.Month == lastgiftdatetime.Month)
            {
                canusergetgift = false;
            
        }
            else
            {

                dayscount = 0;
                canusergetgift = true;
            }
            setinfos();
        }
        catch { }
    }  
        void Start()
        {
           
            StartCoroutine(onetime());
           
        }

        internal void GetGift()
        {
            if (canusergetgift)
            {

                if (onuserwantgift != null)
                    onuserwantgift(dayscount);

                dayscount++;

                if (dayscount == maxdaycount)
                {
                    dayscount = 0;
                }
                lastgiftdatetime = DateTime.Now;
                canusergetgift = false;

            }
            save();
            setinfos();
        }
 
        public void daily()
        {
        try { 
            this.MyStart((day) =>
            {
                switch (day)
                {
                    case 0:
                        PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 100);
                        break;
                    case 1:

                        PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 200);
                        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 10);
                        break;
                    case 2:
                        PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 300);
                        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 20);
                        break;
                    case 3:
                        PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 400);
                        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 30);
                        break;
                    case 4:
                        PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 500);
                        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 40);
                        break;
                    case 5:
                        PlayerPrefs.SetInt("Cash", PlayerPrefs.GetInt("Cash") + 600);
                        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 50);
                        break;


                }
            });
        }
        catch { }
    }

        IEnumerator onetime() 
        {
            yield return new WaitForSeconds(1.8f);
            if (canusergetgift == true)
            {
            MenuManger.Instance.dailyRewardPanel.SetActive(true);  

            }
        }
    void dailyFalsePanel() 
    {
        MenuManger.Instance.dailyRewardPanel.SetActive(false);
    }
      
    }
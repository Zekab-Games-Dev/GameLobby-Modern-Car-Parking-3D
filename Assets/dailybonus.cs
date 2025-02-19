using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//namespace Assets.SimpleAndroidNotifications
//{



    [ExecuteInEditMode]
    public class dailybonus : MonoBehaviour
    {

        void OnEnable()
        {
#if UNITY_EDITOR

            if (day == null)
            {
                day = transform.Find("day").GetComponent<Text>();
            }
            if (giftinfo == null)
            {
                giftinfo = transform.Find("giftinfo").GetComponent<Text>();
            }
            if (giftedpanel == null)
            {
                giftedpanel = transform.Find("giftedpanel").gameObject;
            }
            //if (giftedtext == null)
            //{
            //    giftedtext = transform.Find("giftedtext").gameObject;
            //}
            if (getgiftbutton == null)
            {
                getgiftbutton = transform.Find("getgiftbutton").gameObject;
            }
#endif
        }
        // Use this for initialization
        public dailygiftcontroller controller;
        public Text day;
        public Text giftinfo;

        public GameObject giftedpanel;
       // public GameObject giftedtext;
        public DateTime date;

        public GameObject getgiftbutton;
        private ulong last;
        //public GameObject coinscollect;
      //  public GameObject Close;
        public void setinfo(dailygiftcontroller controller, string daytext, string giftinfo, int status = 0)
        {
            this.controller = controller;
            this.day.text = daytext;
            this.giftinfo.text = giftinfo;

            if (status == 0)
            {
                status0();
            }
            else if (status == 1)
            {
                status1();
            }
            else if (status == 2)
            {
                status2();
            }


        }
        public void onclickgetgift()
        {
            controller.GetGift();
            //coinscollect.SetActive(true);
          //  Close.SetActive(true);
           // Invoke("daly", 2.5f);
        }
        void status0()
        {
            giftedpanel.SetActive(false);
           // giftedtext.SetActive(false);
            giftinfo.enabled = true;
            getgiftbutton.SetActive(false);
           // Close.SetActive(true);
        }
        private void status1()
        {
            giftedpanel.SetActive(false);
          //  giftedtext.SetActive(false);
            giftinfo.enabled = true;
            getgiftbutton.SetActive(true);
            //Close.SetActive(false);
            
        }
        public void status2()
        {
            giftedpanel.SetActive(true);
           // giftedtext.SetActive(true);
           // Close.SetActive(true);
            getgiftbutton.SetActive(false);
           // giftinfo.enabled = false;
            giftinfo.text = "COLLECTED";

        }
     
       

    }

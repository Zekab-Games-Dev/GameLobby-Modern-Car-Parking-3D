using System.Collections.Generic;
using System.Collections;
using System.Text;
using UnityEngine;
namespace ServerTime
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager myinstance = null; // make object of this class
        private string url = "http://www.zekab.com/Time.php"; //this string hold tha value of php time script that save on server
        string TimeData; // this string hold the data the get from internet 
        private string CurrentTime; // this hold the current time
        private string CurrentDate; // this hold the current date
        bool NetConnect = false; // this bool true when net is connect
        Dictionary<string, string> headers = new Dictionary<string, string>(); //hold the value of browsers and need in WWW construtor

        int Month, Day, Year, Hour, Minute, Seconds;
        private void Awake()
        {
            //make sure there is only one instance of this always.
            if (myinstance == null)
            {
                //DontDestroyOnLoad(gameObject);
                myinstance = this;
            }
            //else
            //    Destroy(gameObject);

            

        }

        private void Start()
        {
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            headers.Add("User-Agent", userAgent);
            StartCoroutine(GetTime());
            
        }


        public IEnumerator GetTime()
        {

            WWW _www = new WWW(url, Encoding.UTF8.GetBytes(url), headers);//URLs passed to WWW class must be '%' escaped.
             yield return _www;
            if (string.IsNullOrEmpty(_www.error))
            {
                NetConnect = true;
                //#if ZekabDebugMode
                //                print("Got: " + _www.text);
                //#endif

                //               
                //                TimeData = _www.text;

                //                string[] TimeDataWords = TimeData.Split('/');
                //                CurrentDate = TimeDataWords[0];
                //                CurrentTime = TimeDataWords[1];

                //                string[] SplitDate = CurrentDate.Split('-');
                //                Month = int.Parse(SplitDate[0]);
                //                Day = int.Parse(SplitDate[1]);
                //                Year = int.Parse(SplitDate[2]);

                //                string[] SpliteTime = CurrentTime.Split(':');
                //                Hour = int.Parse(SpliteTime[0]);
                //                Minute = int.Parse(SpliteTime[1]);
                //                Seconds = int.Parse(SpliteTime[2]);
            }
            else
            {
//#if ZekabDebugMode
//                print("Error: " + _www.error);
//#endif

                NetConnect = false;
            }

        }


        public bool IsNetConnect()
        {
            return NetConnect;
        }

        public int GetCurrentDateNow()
        {
            int Date = int.Parse(Month.ToString() + Day.ToString() + Year.ToString());
            return Date;
        }

        public string GetCurrentTimeNow()
        {
            return CurrentTime;
        }

        public int GetMonthNow()
        {
            return Month;
        }

        public int GetDayNow()
        {
            return Day;
        }

        public int GetYearNow()
        {
            return Year;
        }

        public int GetHour()
        {
            return Hour;
        }

        public int GetMinute()
        {
            return Minute;
        }

        public int GetSecond()
        {
            return Seconds;
        }


    }
}



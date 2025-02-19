using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CustomAds : MonoBehaviour {

		public GameObject[] adsSet;
		int adIndex;
		Coroutine adRoutine;
	public static CustomAds instance = null;

    public void Awake()
    {
		
		if (instance == null)
		{
			instance = this;
		}
		else 
		{
			Destroy(this.gameObject);
			instance = this;
		}
    }
    public void callAds (GameObject[] adss) {
			try{
		//	Debug.Log("yaha aya ha");
			if(adRoutine!=null)
			{
				StopCoroutine(adRoutine);
				adRoutine=null;
			}
			adIndex = 0;
			adsSet=adss;
			foreach (GameObject ads in adsSet) {
				ads.SetActive (false);
			}
			adRoutine=StartCoroutine (adsRoutine (0f));
			}
			catch
			{

			}
		}

		public void stopAds()
		{
			try{
			if(adRoutine!=null)
				{
					StopCoroutine(adRoutine);
					adRoutine=null;
				}
			}
			catch{
		
			}
		}
		IEnumerator adsRoutine(float timer) //custom ads animation routine
		{
			yield return new WaitForSecondsRealtime (timer);
			if (adIndex != 0) {
				adsSet [adIndex - 1].SetActive (false);
			}
			else {
				adsSet [adsSet.Length - 1].SetActive (false);
			}
			adsSet [adIndex].SetActive (true);
			if (adIndex < adsSet.Length - 1) {
				adIndex++;
			}
			else {
				adIndex = 0;
			}
			adRoutine=StartCoroutine (adsRoutine (2f));
		}
	

}

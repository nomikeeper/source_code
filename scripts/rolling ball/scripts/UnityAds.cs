using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System;

public class UnityAds : MonoBehaviour {
		

	private int addCheck;
	public Button btn_retry;
	public Button btn_main_menu;

	public InterstitialAd interstitial;
	public bool isShown;

	void Start()
	{
		addCheck = PlayerPrefs.GetInt ("CheckCount", 0);
		RequestInterstitial ();
		isShown = false;
		if (addCheck >= 3) {
			//disableButtons ();
		}
	}

	void Update()
	{
		/*if (addCheck >= 3) 
		{
			ShowAd ();
			if (isShown) {
				//enableButtons ();
			}
		}*/
	}
	public void ShowAd()
		{

		if (interstitial.IsLoaded ()) {
				interstitial.Show ();
			} 
		}
	void RequestInterstitial()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-9430638290326701/2624617074";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}

	public void deleteInterstitial()
	{
		if (addCheck >= 2) {
			addCheck = 0;
			PlayerPrefs.SetInt ("CheckCount", addCheck);
			interstitial.Destroy ();
		} else {
			interstitial.Destroy ();
		}

	}
	/*void disableButtons()
	{
		btn_retry.gameObject.SetActive (false);
		btn_main_menu.gameObject.SetActive (false);
	}
	void enableButtons()
	{
		btn_retry.gameObject.SetActive (true);
		btn_main_menu.gameObject.SetActive (true);
	}*/
}

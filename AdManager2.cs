using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System;

public class AdManager : MonoBehaviour
{
    string App_ID = "ca-app-pub-xxx~xxx";
    string interstitialAd_ID = "ca-app-pub-xxx/xxx";
    string bannerAd_ID = "ca-app-pub-xxx/xxx";

    string testInterstitialAd_ID = "ca-app-pub-3940256099942544/1033173712";
    string testBannerAd_ID = "ca-app-pub-3940256099942544/6300978111";

    private BannerView bannerView;
    private InterstitialAd interstitialAd;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBannerAd();
        this.RequestInterstitialAd();
    }

    private void RequestBannerAd() 
    {
        this.bannerView = new BannerView(testBannerAd_ID, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }

    private void RequestInterstitialAd() 
    {
        this.interstitialAd = new InterstitialAd(testInterstitialAd_ID);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitialAd.LoadAd(request);
    }

    private void Update()
    {
        ShowAd();
    }

    //GameOver or touched obstacle or NextLevel 
    private void ShowAd() 
    {
        if (Player.AdShow) //There's a bool checks for if ad's will be shown
        {
            if (this.interstitialAd.IsLoaded())
            {
                this.interstitialAd.Show();
            }
        }
    }
}
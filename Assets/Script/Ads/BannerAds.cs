using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerAds : MonoBehaviour
{
    private readonly string unitID = "ca-app-pub-5128399712273383~6099942407";
    private string realAd = "ca-app-pub-5128399712273383/4815615045";
    private string testAd = "ca-app-pub-3940256099942544/6300978111";
    private readonly string test_deviceID = "3DCDF03C9AF66E7B";
    public BannerView bannerview;

    public void Start()
    {
        MobileAds.Initialize(

            (initStatus) => InitAd()


            );
    }
    public void InitAd()
    {
        bannerview = new BannerView(testAd, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerview.LoadAd(request);

        showBanner();
    }
    public void showBanner()
    {
        try
        {
            bannerview.Show();
            Debug.Log("show");
        }
        catch
        {
            Debug.Log("보일 광고가 없음");
        }

    }
    public void hideBanner()
    {
        try
        {
            bannerview.Hide();
            Debug.Log("숨김");
        }
        catch
        {
            Debug.Log("숨길 광고가 없음");
        }



    }
}


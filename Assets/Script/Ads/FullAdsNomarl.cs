using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAdsNomarl : MonoBehaviour
{
    private readonly string unitID = "ca-app-pub-5128399712273383~6099942407";
    private string realAd = "ca-app-pub-5128399712273383/5299718825";
    private string testAd = "ca-app-pub-3940256099942544/1033173712";
    public InterstitialAd screenAd=null;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(

             (initStatus) => InitAd()

             );
    }


    public void InitAd()
    {
        screenAd = new InterstitialAd(testAd);
        AdRequest request = new AdRequest.Builder().Build();
        screenAd.LoadAd(request);



    }
    public void show()
    {
        InitAd();
        Debug.Log("전면");
        StartCoroutine("ShowScreenAd");
        InitAd();
    }
    public IEnumerator ShowScreenAd()
    {
        while (!screenAd.IsLoaded())
        {
            Debug.Log("전면실행");
            yield return null;
        }

        screenAd.Show();
    }
}

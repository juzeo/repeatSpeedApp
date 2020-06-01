using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAds : MonoBehaviour
{
   
    //private string realAd = "ca-app-pub-5128399712273383/2773200861";
    private string testAd = "ca-app-pub-3940256099942544/5224354917";
    private readonly string test_deviceID = "3DCDF03C9AF66E7B";

    private RewardedAd rewardAd;

    public void Start()
    {

        rewardAd = new RewardedAd(testAd);
        Handle(rewardAd);
        Load();
    }

    private void Handle(RewardedAd videoAd)
    {

    }

    private void Load()
    {
        AdRequest request = new AdRequest.Builder().Build();
        rewardAd.LoadAd(request);
    }

    public RewardedAd ReloadAd()
    {
        RewardedAd videoAd = new RewardedAd(testAd);
        Handle(videoAd);
        AdRequest request = new AdRequest.Builder().Build();
        videoAd.LoadAd(request);
        return videoAd;
    }

    public void Show()
    {
        StartCoroutine("ShowRewardAd");
    }

    private IEnumerator ShowRewardAd()
    {
        while (!rewardAd.IsLoaded())
        {
            yield return null;
        }
        rewardAd.Show();
    }

}

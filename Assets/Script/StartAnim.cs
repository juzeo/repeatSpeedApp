using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartAnim : MonoBehaviour
{
    public GameObject StartText;
    public float time;
    public GameObject Btns;
    int PlayTime;
    public GameObject timer;
    public GameObject EndText;
    public GameObject returnText;
    public GameObject resultText;
    public BannerAds banner;
    public int adsCount;

    private void Start()
    {

        banner.showBanner();
    }
    // Start is called before the first frame update
    public void startAnim(int time)
    {
        banner.hideBanner();
        Btns.SetActive(false);
        StartText.SetActive(true);
        StartCoroutine("three");
        PlayTime = time;
        
    }

    IEnumerator three()
    {
        StartText.GetComponent<Text>().text = "3";
        time = 0;
        while (time <1f)
        {
            time += Time.deltaTime;
            yield return null;
            
        }

       
          
            StartCoroutine("two");
        
        

    }
    IEnumerator two()
    {
        StartText.GetComponent<Text>().text = "2";
        time = 0;
        while (time < 1f)
        {
            time += Time.deltaTime;
            yield return null;

        }
        StartCoroutine("one");
    }
    IEnumerator one()
    {
        StartText.GetComponent<Text>().text = "1";
        time = 0;
        while (time < 1f)
        {
            time += Time.deltaTime;
            yield return null;

        }
        StartText.SetActive(false);
        timer.SetActive(true);
        
        gameObject.GetComponent<RepeatSpeed>().StartCoroutine("Play",PlayTime);

    }
    public void returnBtn()
    {
        resultText.SetActive(false);
        timer.SetActive(false);
        Btns.SetActive(true);
        returnText.SetActive(false);
    }
    public IEnumerator End()
    {
        adsCount++;
        if (adsCount % 3 == 0)
        {
            GameObject.Find("Ads").GetComponent<FullAdsNomarl>().show();
        }
        banner.showBanner();
        timer.GetComponent<Text>().text = "10.00";
        EndText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
       
        EndText.SetActive(false);
        resultText.SetActive(true);
        returnText.SetActive(true);
        resultTextSet();
    }
    void resultTextSet()
    {
        RepeatSpeed result = gameObject.GetComponent<RepeatSpeed>();
        resultText.GetComponent<Text>().text = result.averTouch.ToString("N2") + " touch/s\n터치 횟수 : " + result.touchCounts;
    }
}

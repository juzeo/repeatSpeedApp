using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepeatSpeed : MonoBehaviour
{
    public bool multipleTouchAble;
    public int touchCounts;
    public Text info;
    public float time;
    public Text Timer;
    public string LeaderBoard;
    public Achivement achivement;
    public float averTouch
    {
        get{
            return touchCounts / time;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        achivement = gameObject.GetComponent<Achivement>();
    }
   
    // Update is called once per frame
    public IEnumerator Play(int time)
    {
        touchCounts = 0;
        this.time = 0;
        while (this.time<time)
        {
            yield return null;
            this.time += Time.deltaTime;
            Timer.text = (this.time).ToString("N2");
            multipleTouchCount();
            touchCount();
            infoText();
        }
        info.text = "";
        gameObject.GetComponent<StartAnim>().StartCoroutine("End");
        changeLeaderBoard(time);
        if (Social.localUser.authenticated == true)
        {

            Social.ReportScore((int)touchCounts, LeaderBoard, (bool success) => { });
            
        }
        achivement.CheckAchivement(averTouch, multipleTouchAble);

    }
    void changeLeaderBoard(int time)
    {
        if (multipleTouchAble == true)
        {
            switch (time)
            {
                case 10:
                    LeaderBoard = "CgkI4ub4wrMNEAIQBQ";
                    break;
                case 20:
                    LeaderBoard = "CgkI4ub4wrMNEAIQBg";
                    break;
                case 30:
                    LeaderBoard = "CgkI4ub4wrMNEAIQBw";
                    break;
                case 60:
                    LeaderBoard = "CgkI4ub4wrMNEAIQCA";
                    break;

            }
        }
        else
        {
            switch (time)
            {
                case 10:
                    LeaderBoard = "CgkI4ub4wrMNEAIQAQ";
                    break;
                case 20:
                    LeaderBoard = "CgkI4ub4wrMNEAIQAg";
                    break;
                case 30:
                    LeaderBoard = "CgkI4ub4wrMNEAIQAw";
                    break;
                case 60:
                    LeaderBoard = "CgkI4ub4wrMNEAIQBA";
                    break;

            }
        }
       
    }

    void infoText()
    {
        int touch = Input.touchCount;
        info.text = "동시 터치 갯수 : " + touch +"\n누적 터치 갯수 : " + touchCounts;
    }

    void multipleTouchCount()
    {
        int touch = Input.touchCount;
        
    }
    void touchCount()
    {
       
        if (Input.touchCount > 0)
        {
            if (multipleTouchAble == true)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        touchCounts++;
                    }
                }
            }
            else
            {
                if (Input.touchCount == 1)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        touchCounts++;
                    }
                }
               
            }
        }
        achivement.CheckAchivementMultiTouch(Input.touchCount);

    }



}

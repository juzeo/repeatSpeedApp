using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achivement : MonoBehaviour
{
    public void OnShowAchivement()
    {
        Social.ShowAchievementsUI();
    }
    public void CheckAchivement(float averTouch, bool multipleAble)
    {
        if (Social.localUser.authenticated == true)
        {
            if (multipleAble == false)
            {
                if (averTouch > 10)
                {
                    Social.ReportProgress(GPGSIds.achievement_10_touchs, 100f, (bool success) => { });
                }
                if (averTouch > 15)
                {
                    Social.ReportProgress(GPGSIds.achievement_15_touchs, 100f, (bool success) => { });
                }

            }
            else
            {
                if (averTouch > 45)
                {
                    Social.ReportProgress(GPGSIds.achievement_45_touchs, 100f, (bool success) => { });
                }   
            }
        }

    } 


    public void CheckAchivementMultiTouch(int touchCount)
    {
        if (Social.localUser.authenticated == true)
        {
            if (touchCount > 10)
            {
                Social.ReportProgress(GPGSIds.achievement, 100f, (bool success) => { });
            }
            

        }
    }
}

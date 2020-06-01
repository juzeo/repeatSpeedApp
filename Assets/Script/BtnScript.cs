using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnScript : MonoBehaviour
{
    public bool multipleTouch;
    public Text multipleTouchText;
    private void Start()
    {
        Road();
        if (multipleTouch == false)
        {

            multipleTouchText.text = "동시 터치 OFF";
        }
        else
        {

            multipleTouchText.text = "동시 터치 ON";
        }

    }
    void Road()
    {
        //multipleTouch = gameObject.GetComponent<RepeatSpeed>().multipleTouchAble;
        if (PlayerPrefs.HasKey("multipleTouch")==true)
        {
            Debug.Log("touch");
            if (PlayerPrefs.GetString("multipleTouch") == "true")
            {
                multipleTouch = true;
            }
            else
            {
                multipleTouch = false;
            }
        }
        else
        {
            
            multipleTouch = false;
        }
        multipleTouchTextUpdate();
    }
    public void btn10()
    {
      
        gameObject.GetComponent<StartAnim>().startAnim(10);
    }
    public void btn20()
    {
        gameObject.GetComponent<StartAnim>().startAnim(20);
    }
    public void btn30()
    {
        gameObject.GetComponent<StartAnim>().startAnim(30);
    }
    public void btn60()
    {
        gameObject.GetComponent<StartAnim>().startAnim(60);

    }
    public void btnTouch()
    {
        
        if(multipleTouch == false)
        {
            multipleTouch = true;
            
        }
       else
        {
            multipleTouch = false;
            
        }
        multipleTouchTextUpdate();
        gameObject.GetComponent<RepeatSpeed>().multipleTouchAble = multipleTouch;
    }
    public void multipleTouchTextUpdate()
    {
        if (multipleTouch == false)
        {
           
            multipleTouchText.text = "동시 터치 OFF";
        }
        else
        {
            
            multipleTouchText.text = "동시 터치 ON";
        }
    }
}

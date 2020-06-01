using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    public int ClickCount;
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(1440, 2960, true);

    }

    void Update()
    {
        /* press to start 
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneToLoad);
        }
        */

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            SaveData();
            
        }

    }
    void SaveData()
    {
        string multipletouch;
        if (gameObject.GetComponent<BtnScript>().multipleTouch == true)
        {
            multipletouch = "true";
        }
        else
        {
            multipletouch = "false";
        }
        PlayerPrefs.SetString("multipleTouch", multipletouch);
        
        PlayerPrefs.Save();
        Application.Quit();
    }
    void DoubleClick()
    {
        ClickCount = 0;
    }
}

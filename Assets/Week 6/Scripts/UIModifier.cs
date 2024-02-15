using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIModifier : MonoBehaviour
{
    public void sceenChangeWeek5()
    {
        SceneManager.LoadScene(2);
    }

    public void screen169()
    {
        
        Screen.SetResolution(745, 419, FullScreenMode.Windowed);
    }
    
    public void screenHD() 
    {
        Screen.SetResolution(1920,1080, FullScreenMode.Windowed);
    }
}

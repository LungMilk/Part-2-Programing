using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class KeyboardSceneChange : MonoBehaviour
{
    public SceneLoader sclder;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("the if statement");
            sclder.loadNextScene();
        }
    }

}

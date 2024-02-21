using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //PlayerScript = FootballPlayer
    public static PlayerScript CurrentSelection { get; private set; }

    public static void SetCurrentSelection(PlayerScript player)
    {
        if (CurrentSelection != null)
        {
            CurrentSelection.Selected(false);
        }

        CurrentSelection = player;
        CurrentSelection.Selected(true);
    }




}

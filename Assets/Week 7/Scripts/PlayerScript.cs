using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rbSprite;

    public Color defState;
    public Color highlighted;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rbSprite = GetComponent<SpriteRenderer>();

        //rbSprite.color = defState;
        Selected(false);
    }
    private void OnMouseDown()
    {
        Controller.SetCurrentSelection(this);
    }
    public void Selected(bool selected)
    {
        if (selected)
        {
            rbSprite.color = highlighted;
        }
        else
        {
            rbSprite.color = defState;
        }
    }
}

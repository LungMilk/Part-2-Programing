using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer rbSprite;
    public float speed = 100;
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
    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed,ForceMode2D.Impulse);
    }
}

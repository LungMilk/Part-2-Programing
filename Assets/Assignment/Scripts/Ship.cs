using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Ship : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;
    public float distThreshold = 0.5f;
    public List<Vector2> mousepts;

    Vector2 currentpt;
    Vector2 lastpt;


    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        speed = 3;
    }
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
        currentpt = transform.position;

        if(mousepts.Count > 0 )
        {    
            Vector2 direction = mousepts[mousepts.Count -1] - currentpt;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;
        }

        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            speedBoost();
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            speed = 3;
        }

        Vector2 updatedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        mousepts.Add(updatedPos);
        if (Vector2.Distance(lastpt,updatedPos) > distThreshold)
        {
            mousepts.Add(updatedPos);
            lastpt = updatedPos;
        }

    }
    
    void speedBoost()
    {
        speed = 5;
        Debug.Log("Wheee!");
    }
}

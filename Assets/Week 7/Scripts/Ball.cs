using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject kickoffSpot;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score();
    }
    public void score()
    {
        rb.velocity = Vector3.zero;
        Controller.score++;
        rb.MovePosition(kickoffSpot.transform.position);
    }
    //goal collision thatsends message to collision for score
}

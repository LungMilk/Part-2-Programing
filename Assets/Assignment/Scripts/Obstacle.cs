using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 rndmPos;

    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.rotation = Random.Range(-360, 360);
        Debug.Log(rb.rotation);
        rndmPos.x = Random.Range(-10,10);
        rndmPos.y = Random.Range(-10, 10);

        rb.position = rndmPos;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    // Update is called once per frame
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.SendMessage("takeDamage");
        Destroy(gameObject);
    }
}

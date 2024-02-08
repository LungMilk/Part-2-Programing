using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Vector2 direction;
    public float speed = 3;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction.x = -1;
        Destroy(gameObject,5);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * direction * Time.deltaTime);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        collision.SendMessage("TakeDamage", 2);
        Destroy(gameObject);
    }
    
}

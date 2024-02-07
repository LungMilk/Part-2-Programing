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
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * direction * Time.deltaTime);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        SendMessage("TakeDamage", 2);
        Destroy(gameObject, 5);
    }
}

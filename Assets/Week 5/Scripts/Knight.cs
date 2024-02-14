using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    PlayerPrefs savedHealth;

    public float speed = 3f;
    bool clickSelf = false;
    bool dead = false;
    public float health;
    public float maxHealth = 5;

    Vector2 destination;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    private void FixedUpdate()
    {
        if (dead) return;
        movement = destination - (Vector2)transform.position;
        if(movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) return;
        if (Input.GetMouseButtonDown(0) && !clickSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(1) && !clickSelf)
        {
            animator.SetTrigger("Attacking");
        }
        animator.SetFloat("Movement", movement.magnitude);
        
    }
    private void OnMouseDown()
    {
        if (dead) return;
        clickSelf = true;
        SendMessage("TakeDamage", 1);
    }
    private void OnMouseUp()
    {
        clickSelf = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0)
        {
            dead = true;
            animator.SetTrigger("Death");
        }
        else
        {
            dead = false;
            animator.SetTrigger("TakeDamage");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float playerScore;
    public List<Vector2> points;
    public List<Sprite> sprites;

    bool landingState = false;
    public float newPointThreshold = 0.2f;
    public float speed;
    int spriteIndex;

    Vector2 randomizedPos;

    Vector2 lastPosition;


    Rigidbody2D rigidBody;
    LineRenderer lineRenderer;
    SpriteRenderer spriteRenderer;

    Vector2 currentPosition;

    public AnimationCurve landing;
    float landingTimer;

    //planes have to randomise its position once it is spawned
    //the planes will spawn each other depending on its value with its position also randomized
    

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();


        spriteIndex = Random.Range(0, sprites.Count);
        spriteRenderer.sprite = sprites[spriteIndex];

        speed = Random.Range(1,3);

        randomizedPos.x = Random.Range(-8, +8);
        randomizedPos.y = Random.Range(-8, +8);
        //change its start position to the random vector

        gameObject.transform.position = randomizedPos;
        rigidBody.rotation = Random.Range(-360, 360);
        transform.localScale = new Vector3(4, 4, 4);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,transform.position);
    }
    void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidBody.rotation = -angle;
        }
        rigidBody.MovePosition(rigidBody.position + (Vector2)transform.up * speed * Time.deltaTime);
        
    }

    void Update()
    {

        if(landingState)
        {
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if(transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero,interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if(points.Count > 0 ) {

            if (Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
            //if (lineRenderer.positionCount != 0) lineRenderer.positionCount--;
        }
    }

    void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPosition, newPosition) > newPointThreshold) 
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Plane OnCollisionEnter2D");
        if (collision.collider.OverlapPoint(rigidBody.position))
        {
            landingState = true;
            Debug.Log("landing");
            playerScore++;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        float dangerZone = 1;
        float warningZone = 2;
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("player collision working");
            Rigidbody2D rb1 = collision.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log(Vector3.Distance(rigidBody.position, rb1.position));

            if (Vector3.Distance(rigidBody.position, rb1.position) <= dangerZone)
            {
                Destroy(gameObject);
                Debug.Log("plane destroyed");
            }
            else if (Vector3.Distance(rigidBody.position, rb1.position) <= warningZone)
            {
                spriteRenderer.color = Color.red;
            }

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}

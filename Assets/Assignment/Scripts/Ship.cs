using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public TextMeshProUGUI playerScore;
    public Slider SpeedGauge;
    public AnimationCurve SpeedCurve;

    float health;
    float maxhealth = 5;

    int score;

    bool death;

    public Rigidbody2D rb;
    Animator animator;

    public Vector2 speedV;
    public float distThreshold = 0.5f;
    public float interpolation;
    float timer;
    int delayTimer;

    public List<Vector2> mousepts;

    Vector2 currentpt;
    Vector2 lastpt;


    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        score = 0;

        health = maxhealth;
        speedV.x = 3;
        death = false;
    }
    void FixedUpdate()
    {
        if (death) { delayTimer++; gameOver(); }
        SpeedGauge.value = speedV.x;

        currentpt = transform.position;

        if(mousepts.Count > 0 )
        {    
            Vector2 direction = mousepts[mousepts.Count -1] - currentpt;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;
        }

        rb.MovePosition(rb.position + (Vector2)transform.up * speedV.x * Time.deltaTime);
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
            speedV.x = 3;
        }
        

        Vector2 updatedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        mousepts.Add(updatedPos);
        if (Vector2.Distance(lastpt,updatedPos) > distThreshold)
        {
            mousepts.Add(updatedPos);
            lastpt = updatedPos;
        }
        timer = timer + Time.deltaTime;
        speedV.y = timer;
    }
    
    void speedBoost()
    {
        interpolation = SpeedCurve.Evaluate(timer);
        speedV = speedV + Vector2.Lerp(currentpt, speedV, interpolation);
    }

    public void takeDamage()
    {
        health--;
        Debug.Log(health);
        if (health >= 0 )
        {
            death = false;
            animator.SetTrigger("IsHurt");
        }
        else
        {
            
            death = true;
            animator.SetTrigger("IsDead");
        }
        
    }
    void gameOver()
    {
        if (delayTimer>=60) 
        {
            Debug.Log("gameover");
            SceneManager.LoadScene(6);
        }
    }
    void increaseScore()
    {
        score++;
        PlayerPrefs.SetInt("Score",score);
        playerScore.text = "Score: " + score.ToString();
    }
}

using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject spawnManager;

    Vector2 rndmPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rndmPos.x = Random.Range(-4, 4);
        rndmPos.y = Random.Range(-4, 4);
        rb.position = rndmPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("coin is picked up");
        Destroy(gameObject);
        collision.SendMessage("SpawnCoin");
        collision.SendMessage("increaseScore");
    }
}

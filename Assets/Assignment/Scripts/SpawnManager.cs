using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject coin;

    int spawnTimer;
    public int spawnThreshold = 20;

    private void Start()
    {
        SpawnCoin();
    }
    private void FixedUpdate()
    {
        spawnTimer++;
        if (spawnTimer > spawnThreshold)
        {
            SpawnObstacle();
            spawnTimer = 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            SpawnCoin();
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            SpawnObstacle();
        }



    }
    public void SpawnObstacle()
    {
        Instantiate(obstacle);
    }

    public void SpawnCoin()
    {
        Instantiate(coin);
    }

}

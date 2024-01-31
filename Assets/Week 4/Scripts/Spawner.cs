using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject planeobject;
    Vector2 randomizedPos;

    float spawnInterval;
    float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = Random.Range(0, 20);
        randomizedPos.x = Random.Range(-8,+8);
        randomizedPos.y = Random.Range(-8, +8);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += 1f * Time.deltaTime;

        if (spawnTimer > spawnInterval)
        {
            Instantiate(planeobject, randomizedPos, Quaternion.Euler(0, 0, 0));
            spawnTimer = 0;

            spawnInterval = Random.Range(0, 20);
            randomizedPos.x = Random.Range(-10, +10);
            randomizedPos.y = Random.Range(-10, +10);
        }
    }
}

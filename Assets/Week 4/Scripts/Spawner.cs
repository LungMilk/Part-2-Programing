using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject planeobject;
    
    float spawnInterval;
    float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += 1f * Time.deltaTime;

        if (spawnTimer > spawnInterval)
        {
            Instantiate(planeobject);
            spawnTimer = 0;

            spawnInterval = Random.Range(0, 20);
        }
    }
}

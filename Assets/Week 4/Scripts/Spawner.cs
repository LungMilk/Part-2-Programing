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
        spawnInterval = Random.Range(0, 20);
        Debug.Log(spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += 1f * Time.deltaTime;

        if (spawnTimer > spawnInterval)
        {
            Debug.Log(spawnTimer.ToString());
            Instantiate(planeobject, Vector3.zero, Quaternion.Euler(0, 0, 0));
            spawnTimer = 0;

        }
    }
}

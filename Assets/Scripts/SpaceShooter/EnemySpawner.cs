using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float spawnInterval = 0.2f;    
    private float spawnTimer = 2;
    private float increasingTimer = 10;
    public GameObject asteriod;

    void IncreaseDifficulty()
    {
        increasingTimer = increasingTimer - Time.deltaTime;

        if (increasingTimer <= 0)
        {
            spawnInterval = spawnInterval / 1.5f;
            increasingTimer = 5;
        }
    }
    bool SpawnTimerFinished()
    {
        spawnTimer = spawnTimer - Time.deltaTime;

        if (spawnTimer <= 0)
        {
            spawnTimer = spawnInterval;
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnTimerFinished())
        {
            Spawn();
        }
        IncreaseDifficulty();

        // reset if game over
        if (GameManagerSpaceShooter.instance.gameOver)
        {
                spawnInterval = 0.2f;
                spawnTimer = 2;
        }
    }


    void Spawn()
    {
        Vector3 spawnPosition = Vector3.zero;
        int randomEdge = UnityEngine.Random.Range(0, 4); // 0: top, 1: bottom, 2: left, 3: right

        switch (randomEdge)
        {
            case 0: // Top
                spawnPosition = new Vector3(UnityEngine.Random.Range(-15, 15), 15, 0);
                break;
            case 1: // Bottom
                spawnPosition = new Vector3(UnityEngine.Random.Range(-15, 15), -15, 0);
                break;
            case 2: // Left
                spawnPosition = new Vector3(-15, UnityEngine.Random.Range(-15, 15), 0);
                break;
            case 3: // Right
                spawnPosition = new Vector3(15, UnityEngine.Random.Range(-15, 15), 0);
                break;
        }

        Instantiate(asteriod, spawnPosition, asteriod.transform.rotation);
    }
}

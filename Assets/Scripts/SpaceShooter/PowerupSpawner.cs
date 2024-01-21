using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

    public float spawnInterval = 2;
    private float spawnTimer = 2;

    public GameObject multiattackPowerup;
    public GameObject attackspeedPowerup;
    public GameObject nukePet;
    public GameObject shieldPowerup;


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

        float randomValue = UnityEngine.Random.Range(0f, 1f);

        if (randomValue <= 0.3f)
        {
            // 1/3 chance to spawn multiattackPowerup
            Instantiate(multiattackPowerup, spawnPosition, multiattackPowerup.transform.rotation);
        }
        else if (randomValue <= 0.6f)
        {
            // 1/3 chance to spawn attackSpeedPowerup
            Instantiate(attackspeedPowerup, spawnPosition, attackspeedPowerup.transform.rotation);
        }
        else if (randomValue <= 0.9f)
        {
            // 1/3 chance to spawn attackSpeedPowerup
            Instantiate(shieldPowerup, spawnPosition, shieldPowerup.transform.rotation);
        }
        else
        {
            // 1/3 chance to spawn nukePet
            Instantiate(nukePet, spawnPosition, nukePet.transform.rotation);
        }

    }
}

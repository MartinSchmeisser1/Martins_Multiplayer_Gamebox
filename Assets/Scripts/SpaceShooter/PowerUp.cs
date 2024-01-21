using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PowerUp : FlyingObject
{
    public float speed;

    private float flightDirectionX;
    private float flightDirectionY;


    private void Start()
    {
        flightDirectionX = (UnityEngine.Random.Range(0, 2) * 2) - 1;
        flightDirectionY = (UnityEngine.Random.Range(0, 2) * 2) - 1;
    }

    void Update()
    {
        if (gameObject.tag == "Nuke_Pet")
        {
            // Nuke pet is 2D and is therefore rotated differently
            transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(180, 180, 0) * Time.deltaTime);
        }

        transform.Translate(new Vector3(flightDirectionX, flightDirectionY, 0) * speed * Time.deltaTime, Space.World);
        CheckIfOutOfBoundsAndDestroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < GameManagerSpaceShooter.instance.spaceships.Length; i++)
        {
            if (other.gameObject.tag == $"Spaceship{i + 1}")
            {
                Destroy(gameObject);

                switch (gameObject.tag)
                {
                    case "Powerup_Multiattack":
                        GameManagerSpaceShooter.instance.multiattackPowerupStatus[i] += 1;
                        break;
                    case "Powerup_Attackspeed":
                        if (GameManagerSpaceShooter.instance.attackspeedPowerupStatus[i] > 0)
                        {
                            GameManagerSpaceShooter.instance.attackspeedPowerupStatus[i] -= 0.1f;
                        }
                        break;
                    case "Powerup_Shield":
                        GameManagerSpaceShooter.instance.shieldPowerupStatus[i] = true;
                        break;
                    case "Nuke_Pet":
                        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Enemy");

                        foreach (GameObject obj in objectsWithTag)
                        {
                            //Check if in screen
                            float xKoord = obj.transform.position.x;
                            float yKoord = obj.transform.position.y;

                            if (xKoord > -10 && xKoord < 10 && yKoord > -6 && yKoord < 6)
                            {
                                Destroy(obj);
                                GameManagerSpaceShooter.instance.score += 1;
                            }
                        }
                        break;
                }
            }
        }
    }
}

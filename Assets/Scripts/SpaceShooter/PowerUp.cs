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
        transform.Rotate(new Vector3(180, 180, 0) * Time.deltaTime);
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
                        Debug.Log("Powerup Collected");
                        GameManagerSpaceShooter.instance.attackspeedPowerupStatus[i] /= 2;
                        break;
                }
            }
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{

    //    if (other.gameObject.tag == "Spaceship1")
    //    {
    //        Destroy(gameObject);

    //        switch(gameObject.tag)
    //        {
    //            case "Powerup_Multiattack":
    //                GameManagerSpaceShooter.instance.multiattackPowerupStatus[0] += 1;
    //                break;
    //            case "Powerup_Attackspeed":
    //                Debug.Log("Powerup Collected");
    //                GameManagerSpaceShooter.instance.attackspeedPowerupStatus[0] = GameManagerSpaceShooter.instance.attackspeedPowerupStatus[0] / 2;
    //                break;
    //        }
    //    }

    //    if (other.gameObject.tag == "Spaceship2")
    //    {
    //        Destroy(gameObject);

    //        switch (gameObject.tag)
    //        {
    //            case "Powerup_Multiattack":
    //                GameManagerSpaceShooter.instance.multiattackPowerupStatus[1] += 1;
    //                break;
    //            case "Powerup_Attackspeed":
    //                Debug.Log("Powerup Collected");
    //                GameManagerSpaceShooter.instance.attackspeedPowerupStatus[1] = GameManagerSpaceShooter.instance.attackspeedPowerupStatus[1] / 2;
    //                break;
    //        }
    //    }
    //}

}

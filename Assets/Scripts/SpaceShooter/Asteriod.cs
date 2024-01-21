using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Asteriod : FlyingObject
{
    public float speed;

    private float flightDirectionX;
    private float flightDirectionY;

    Boolean alreadyHit;


    private void Start()
    {
        alreadyHit = false;
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
        // check if the meteroid has really been hit in the screen
        Boolean checkIfInScreen = false;

        float xKoord = this.transform.position.x;
        float yKoord = this.transform.position.y;

        if ( xKoord > -10 && xKoord < 10 && yKoord > -6 && yKoord < 6)
        {
            checkIfInScreen = true;
        }

        if (other.gameObject.tag == "Laser" && checkIfInScreen && !alreadyHit)
        {
            alreadyHit = true;
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameManagerSpaceShooter.instance.score += 1;
        }
    }

}

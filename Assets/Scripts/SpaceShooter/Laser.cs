using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : FlyingObject
{
    public float speed;

    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        CheckIfOutOfBoundsAndDestroy();
    }


}

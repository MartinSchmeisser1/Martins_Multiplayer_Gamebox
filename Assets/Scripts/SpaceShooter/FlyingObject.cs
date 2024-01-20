using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{

    // Flying objects are destroyed when out of bound
    protected void CheckIfOutOfBoundsAndDestroy()
    {
        if(transform.position.x < -15 || transform.position.x > 15 || transform.position.y < -15 || transform.position.y > 15)
        {
            Destroy(gameObject);
        }
    }
}

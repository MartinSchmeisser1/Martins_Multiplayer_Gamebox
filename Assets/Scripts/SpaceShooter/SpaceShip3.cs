using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip3 : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public GameObject laserObject;
    private float shotTimer = 0f;
    private float timeBetweenShots;

    void Update()
    {
        Movement();

        // Shooting logic
        timeBetweenShots = GameManagerSpaceShooter.instance.attackspeedPowerupStatus[1];
        shotTimer += Time.deltaTime;
        if ((Input.GetAxis("Fire1_Trigger_Controller3") > 0.8) && shotTimer >= timeBetweenShots)
        {
            // Fire a shot
            Shooting();

            // Reset the timer
            shotTimer = 0f;
        }
    }

    void Movement()
    {
        // actual movement
        float horizontalInput = Input.GetAxis("Horizontal_Controller3");
        float verticalInput = Input.GetAxis("Vertical_Controller3");
        float rotationInput = Input.GetAxis("Rotation_Controller3");

        // Convert input to world space
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);


        // rotation
        float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0,0,1), rotationAmount);

        // clamping the position
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -9, 9);
        position.y = Mathf.Clamp(position.y, -4.5f, 4.5f);
        transform.position = position;
    }


    void Shooting()
    {
        int numberOfLasers = GameManagerSpaceShooter.instance.multiattackPowerupStatus[1] + 1;

        for (int i = 0; i < numberOfLasers; i++)
        {
            float offset = (i - (numberOfLasers - 1) * 0.5f) * 0.1f;
            Vector3 laserPosition = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);

            Instantiate(laserObject, laserPosition, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (GameManagerSpaceShooter.instance.shieldPowerupStatus[2])
            {
                GameManagerSpaceShooter.instance.shieldPowerupStatus[2] = false;
            }
            else
            {
                Destroy(gameObject);
                string[] tagsToDestroy = { "Spaceship1", "Spaceship2", "Spaceship3", "Spaceship4" };
                foreach (string tag in tagsToDestroy)
                {
                    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

                    foreach (GameObject obj in objectsWithTag)
                    {
                        Destroy(obj);
                    }
                }
                GameManagerSpaceShooter.instance.gameOver = true;
            }
        }
    }

}

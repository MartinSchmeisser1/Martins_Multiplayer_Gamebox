using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerSpaceShooter : MonoBehaviour
{
    
    public static GameManagerSpaceShooter instance;

    public int score;
    public bool gameOver;
    public int numberOfPlayers;

    public GameObject[] spaceships;
    public int[] multiattackPowerupStatus;
    public float[] attackspeedPowerupStatus;
    public bool[] shieldPowerupStatus;


    private void Awake() 
    { 
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Reset()
    {
        score = 0;
        gameOver = false;

        string[] tagsToDestroy = { "Enemy", "Powerup_Multiattack", "Powerup_Attackspeed", "Nuke_Pet"};

        foreach (string tag in tagsToDestroy)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
        }
        
        multiattackPowerupStatus = new int[numberOfPlayers];
        attackspeedPowerupStatus = new float[numberOfPlayers];
        shieldPowerupStatus = new bool[numberOfPlayers];

        // Assign spaceships to the array elements
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Instantiate(spaceships[i]);
            multiattackPowerupStatus[i] = 0; // Initial value for multiattack powerup
            attackspeedPowerupStatus[i] = 0.5f; // Initial value for attackspeed powerup
            shieldPowerupStatus[i] = false;
        }

    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && gameOver)
        {
            Reset();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public TMP_Dropdown dropdown;
    private int selectedNumberOfPlayers;


    public void StartSpaceShooter()
    {
        // Load the SpaceShooterScene asynchronously
        StartCoroutine(LoadSpaceShooter());
    }

    IEnumerator LoadSpaceShooter()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SpaceShooter");

        // Subscribe to the completed event
        asyncLoad.completed += OnSceneLoaded;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    // This method will be called when the scene is loaded
    void OnSceneLoaded(AsyncOperation operation)
    {
        // Get the GameManager instance
        GameManagerSpaceShooter gameManagerSpaceShooter = GameManagerSpaceShooter.instance;

        // Set the number of players in the GameManager
        gameManagerSpaceShooter.numberOfPlayers = selectedNumberOfPlayers + 1;

        gameManagerSpaceShooter.Reset();
    }


    public void NumberOfPlayerSelection()
    {
        selectedNumberOfPlayers = dropdown.value;
    }

}

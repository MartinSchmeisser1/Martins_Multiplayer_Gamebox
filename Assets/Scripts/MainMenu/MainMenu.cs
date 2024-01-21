using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button numberOfPlayersDisplay;
    private int selectedNumberOfPlayers;

    private void Start()
    {
        selectedNumberOfPlayers = 1;
    }

    private void Update()
    {
        TextMeshProUGUI buttonText = numberOfPlayersDisplay.GetComponentInChildren<TextMeshProUGUI>();
        
        if (selectedNumberOfPlayers == 1)
        {
            buttonText.text = "1 Player";
        }
        else
        {
            buttonText.text = selectedNumberOfPlayers.ToString() + " Players";
        }


        // Crappy Controller Menu Controls
        if (Input.GetButtonDown("Xb_RB"))
        {
            AddPlayer();
        }
        if (Input.GetButtonDown("Xb_LB"))
        {
            RemovePlayer();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            StartSpaceShooter();
        }

    }

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
        gameManagerSpaceShooter.numberOfPlayers = selectedNumberOfPlayers;

        gameManagerSpaceShooter.Reset();
    }


    public void AddPlayer()
    {
        if(selectedNumberOfPlayers < 4)
        {
            selectedNumberOfPlayers += 1;
        }
    }

    public void RemovePlayer()
    {
        if (selectedNumberOfPlayers > 1)
        {
            selectedNumberOfPlayers -= 1;
        }
    }

    public void QuitApplication()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOVerScript : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerSpaceShooter.instance.gameOver == true && textMeshProUGUI.enabled == false)
        {
            textMeshProUGUI.enabled = true;
        }

        if (GameManagerSpaceShooter.instance.gameOver == false && textMeshProUGUI.enabled == true)
        {
            textMeshProUGUI.enabled = false;
        }
    }
}

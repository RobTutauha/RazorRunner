using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Displays Menu UI and pauses game when escape key pressed AND when win condition is met 
/// </summary>
public class ToggleMenu : MonoBehaviour {

    public Transform canvas;

    private void Awake()
    {
        // Make sure Menu is not active at start
        canvas.gameObject.SetActive(false);
    }

    void Start()
    {
        // Make doubly sure Menu is not active at start (WTH is it active at start???)
        canvas.gameObject.SetActive(false);
    }


    void Update () {

        // Display menu and stop time if the game is not running
        if (GameManager.Instance.gameRunning == false)
        {
            canvas.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }

        // Detect pause button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

    }

    // Stop/Start Game if escape key is pressed
    public void Pause()
    {
        if (GameManager.Instance.gameRunning == false)
        {
            GameManager.Instance.GameOn();
        }
        else
        {
            GameManager.Instance.GameOff();
        }

    }

    /// <summary>
    /// Closes the menu
    /// </summary>
    public void CloseMenu()
    {
        canvas.gameObject.SetActive(false);
    }

}

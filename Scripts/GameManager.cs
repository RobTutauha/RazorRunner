using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// These variables will be very important in later stages of development
    /// razorGauge: Total Player "Power Level" achievable
    /// razorLevel: Current Player "Power Level"
    /// </summary>
    [SerializeField] public float razorGauge = 10f;
    [SerializeField] public float razorLevel = 1f;

    private float _timePassed;
    private int _numCoins;

    /// <summary>
    /// Time elapsed (for matching against time limit)
    /// </summary>
    public float timePassed
    {
        get { return _timePassed; }
        set { _timePassed = value; }
    }

    /// <summary>
    /// gameRunning: used for pause/unpause purposes
    /// timeUp: used for lose condition
    /// </summary>
    public bool gameRunning = false;
    public bool timeUp = false;

    /// <summary>
    /// used for win conditiona
    /// </summary>
    public int NumCoins
    {
        get { return _numCoins; }
        set { _numCoins = value; }
    }

    /// <summary>
    /// maximum time limit (used to reset game)
    /// </summary>
    public float maxTimeSeconds = 3* 60; // In seconds.



    /// <summary>
    /// initialize values
    /// </summary>
    void Start()
    {
        Restart();

    }

    void Update()
    {
        /// pause game if win condition met
        if (NumCoins > 0)
        {
            GameOff();
        }

        /// while game running count time as passing
        if (gameRunning == true)
        {
            timePassed += Time.deltaTime;

        }

        /// if time elapsed reached limit set lose condition and pause game
        if (timePassed >= maxTimeSeconds)
        {
            timeUp = true;
            GameOff();
        }

    }

    /// <summary>
    /// Resets game variables for fresh start of level
    /// </summary>
    public void Restart()
    {
        timePassed = 0;
        NumCoins = 0;
        timeUp = false;
        razorLevel = 0;
        GameOn();
    }

    /// <summary>
    /// Unpauses game
    /// </summary>
    public void GameOn()
    {
        gameRunning = true;
        Time.timeScale = 1;
    }

    /// <summary>
    /// Pauses game
    /// </summary>
    public void GameOff()
    {
        gameRunning = false;
        Time.timeScale = 0;
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Implements the in-game UI
/// </summary>
public class InGameUI : MonoBehaviour
{
    /// <summary>
    ///  timerLabel: displays the time elapsed in-game
    /// </summary>
    [SerializeField]
    private Text timerLabel;


    /// <summary>
    /// Set timer label text to nothing so it does not display until time is actually running
    /// </summary>
    private void Start()
    {
        timerLabel.text = "";
    }

    /// <summary>
    /// Updates timerLabel every frame
    /// </summary>
    void Update()
    {
        if (GameManager.Instance.gameRunning == false)
        {
            timerLabel.text = "";
        }
        else
        {
            timerLabel.text = FormatTime(GameManager.Instance.timePassed);
        }

    }


    /// <summary>
    /// Formats the time to seconds
    /// </summary>
    /// <param name="timeInSeconds">the time in seconds</param>
    /// <returns>formatted time string</returns>
    private string FormatTime(float timeInSeconds)
    {
        return string.Format("{0}:{1:00}", Mathf.FloorToInt(timeInSeconds / 60), Mathf.FloorToInt(timeInSeconds % 60));
    }

}

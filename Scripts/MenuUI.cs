using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Implements the menu UI
/// </summary>
public class MenuUI : MonoBehaviour
{
    /// <summary>
    ///  timerLabel: displays the time elapsed in-game
    ///  finishLabel: displays the level completed text
    ///  timeLeft: holds the countdown time remaining
    ///  countdownLabel: displays the countdown time remaining
    ///  won: run once flag to prevent rerunning coroutine
    /// </summary>
    [SerializeField] private Text timerLabel;
    [SerializeField] private Text FinishLabel;
    [SerializeField] private int timeLeft;
    [SerializeField] private Text countdownLabel;
    private bool won;

    /// <summary>
    /// Set label text to nothing so it does not display until win condition is met
    /// Set won bool to false for the same reason
    /// </summary>
    private void Start()
    {
        FinishLabel.text = "";
        timerLabel.text = "";
        countdownLabel.text = "";
        won = false;
    }

    /// <summary>
    /// Updates timerLabel every frame and updates finishLabel when win condition is satisfied
    /// </summary>
    void Update()
    {

        /// Starts countdown if win condition is met
        if (GameManager.Instance.NumCoins > 0)
        {
            FinishLabel.text = "level complete";
            timerLabel.text = ("Total Time " + FormatTime(GameManager.Instance.timePassed));

            if (won == false)  // Start the CountDown coroutine only once
            {
                won = true;
                StartCoroutine("CountDown");
            }
            

        }
        /// Displays if losing condition is met
        else if (GameManager.Instance.timeUp == true)
        {
            FinishLabel.text = "Fugitive escaped - You lose";
        }

        /// displaying the countdown once the countdown has begun
        if (won == true)
        {
            countdownLabel.text = "" + (timeLeft);
        }

        /// When the countdown has run out reset values and load next scene
        if ((won == true) && (0 >= timeLeft))
        {
            won = false;
            timeLeft = 0;
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<ChangeScene>().LoadScene("Next");
        }

    }

    /// <summary>
    /// Starts a countdown that plays a sound every second
    /// </summary>
    /// <returns></returns>
    IEnumerator CountDown()
    {
        while (0 < timeLeft)
        {
            yield return new WaitForSecondsRealtime(1);
            timeLeft--;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSounds>().TimeTick();
            yield return null; // Eveeryone online seems to be using this so I included it to be safe
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

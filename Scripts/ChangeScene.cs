using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    /// <summary>
    /// Changes the scene based on which button is clicked in the menu (or the string passed)
    /// </summary>
    /// <param name="scene"> the keyword attached to menu button that determines what action to be taken</param>
	public void LoadScene(string scene) {

        // Wipes the game data (start levels clean)
        GameManager.Instance.Restart();

        if (scene == "Replay")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // gets current scene index and reloads it

        }
        else if (scene == "Next")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // gets current scene index + 1 then loads that
        }
        else if (scene == "Previous")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // gets current scene index - 1 then loads that
        }
        else if (scene == "Scene 1")
        {
            SceneManager.LoadScene(0); // gets scene 1
        }
        else if (scene == "Scene 2")
        {
            SceneManager.LoadScene(1); // gets scene 1
        }

        else
        {
            SceneManager.LoadScene(0); // just loads something because something something looks stupid otherwise
        }

	}
}

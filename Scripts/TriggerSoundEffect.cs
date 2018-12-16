using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundEffect : MonoBehaviour {

    /// <summary>
    /// variable to store the audiosource of whatever game object this script is attached to
    /// </summary>
    public AudioSource source;

    public void Awake()
    {
        //get the audiosource and put it in the variable
        source = GetComponent<AudioSource>();
    }

    /// <summary>
    ///  Plays whatever clip is stored in the audiosource when the collider collides with another collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        source.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays sound when triggered by collision
/// Superseded by TriggerSoundEffect script
/// </summary>
public class Speedup : MonoBehaviour {

    [SerializeField]
    public AudioClip speedup;

    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpeedUp();
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void SpeedUp()
    {
        audioSource.PlayOneShot(speedup);
    }

}

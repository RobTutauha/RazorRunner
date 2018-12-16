using UnityEngine;

/// <summary>
/// Plays player specific audio clips
/// </summary>
public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] stepClips; // array of audio clips
    public AudioClip jump; // jump sound
    public AudioClip speedUp; // speed up sound
    public AudioClip slowDown; // speed up sound
    public AudioClip warper; // warp sound
    public AudioClip warpee; // other warp sound winner
    public AudioClip winner; // win sound
    public AudioClip loser; // lose sound 
    public AudioClip timeTick; // timeTick sound 

    private bool played;  // used to prevent repeated playing
    private AudioSource audioSource;

    private void Start()
    {
        played = false;
    }

    /// <summary>
    /// detects spacebar press and calls jump method
    /// </summary>
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.JoystickButton3)))
        {
            Jump();
        }

        if (GameManager.Instance.timeUp == true)
        {
            Loser();
        }
    }

    /// <summary>
    /// play timeTick sound
    /// </summary>
    public void TimeTick()
    {
        audioSource.PlayOneShot(timeTick);
    }

    /// <summary>
    /// play loser sound
    /// </summary>
    public void Loser()
    {
        if (played == false)
        {
            audioSource.PlayOneShot(loser);
            played = true;
        }
    }

    /// <summary>
    /// Gets audiosource component from whatever gameobject this script is attached to and put it into variable
    /// </summary>
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Play sounds when player collides with tagged objects
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Speed1")
        {
            audioSource.PlayOneShot(speedUp);
        }

        if (other.gameObject.tag == "Slow1")
        {
            audioSource.PlayOneShot(slowDown);
        }

        if (other.gameObject.tag == "Warp1")
        {
            audioSource.PlayOneShot(warper);
        }

        if (other.gameObject.tag == "Warp2")
        {
            audioSource.PlayOneShot(warpee);
        }

        if (other.gameObject.tag == "Win")
        {
            audioSource.PlayOneShot(winner);
        }

    }

    /// <summary>
    /// Plays jump sound
    /// </summary>
    private void Jump()
    {
        audioSource.PlayOneShot(jump);
    }

    /// <summary>
    /// Method triggered by marked points in run animation
    /// Calls method to select random clip from the list and plays it
    /// </summary>
    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    /// <summary>
    /// Returns random clip from the stepClips list
    /// </summary>
    /// <returns></returns>
    private AudioClip GetRandomClip()
    {
        return stepClips[UnityEngine.Random.Range(0, stepClips.Length)]; //picks a clip at random

    }
}
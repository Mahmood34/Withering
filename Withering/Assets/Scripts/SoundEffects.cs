using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for handling the sound effects of the Player.
/// </summary>
public class SoundEffects : MonoBehaviour
{
    /// Reference to the audio source.
    public AudioSource audioSource;
    /// Reference to the step audio clip.
    public AudioClip stepClip;
    /// Reference to the slash audio clip.
    public AudioClip slashClip;

    /// <summary>
    /// Gets the audio source component.
    /// </summary>
    void Awake ()
    {
        audioSource = GetComponent<AudioSource> ();
    }

    /// <summary>
    /// Method that is called using a step event set in the animation.
    /// </summary>
    void Step ()
    {
        audioSource.PlayOneShot (stepClip);
    }

    /// <summary>
    /// Method that is called using a sword attack event set in the animation.
    /// </summary>
    void Slash ()
    {
        audioSource.PlayOneShot (slashClip);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for game objects that allow for the camera to pan out for a different view.
/// </summary>
public class CameraPanOut : MonoBehaviour
{

    /// Offset for the camera to move.
    public Vector3 offset;

    /// <summary>
    /// Detects when the Player enters the collider.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter (Collider other)
    {
        FindObjectOfType<Camera> ().GetComponent<FollowPlayer> ().offset = offset;
        PlayerManager.instance.DisableMonsterEncounters ();
    }

    /// <summary>
    /// Reset the camera offset. 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit (Collider other)
    {
        FindObjectOfType<Camera> ().GetComponent<FollowPlayer> ().offset = new Vector3 (0, 20, -10);
        PlayerManager.instance.EnableMonsterEncounters ();
    }
}
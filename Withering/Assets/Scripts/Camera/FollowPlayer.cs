using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for camera to follow the players location with specific offset and angle for top-down perspective.
/// Contains methods for locating the player and updating position to match player position.
/// </summary>
public class FollowPlayer : MonoBehaviour
{

    /// Player position.
    public Transform player;
    /// Offset for the camera to be shifted.
    public Vector3 offset;

    /// <summary>
    /// Finds the players position and sets the position to it along with offset.
    /// </summary>
    void Start ()
    {
        player = FindObjectOfType<PlayerController> ().gameObject.transform;
        offset = new Vector3 (0, 20, -10);
        transform.position = player.position;
    }

    /// <summary>
    /// Updates the cameras position to follow the Player.
    /// </summary>
    void Update ()
    {
        Vector3 newPos = player.position + offset;
        transform.position = Vector3.Slerp (transform.position, newPos, 0.1f);
        transform.LookAt (player.transform);
    }
}
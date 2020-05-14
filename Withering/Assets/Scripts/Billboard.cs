using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to handle the view of the Enemy healthbar to face the screen.
/// </summary>
public class Billboard : MonoBehaviour
{
    /// Reference to the camera object.
    public Transform cam;

    void Start ()
    {
        cam = FindObjectOfType<Camera> ().transform;
    }

    void LateUpdate ()
    {
        transform.LookAt (transform.position + cam.forward);
    }
}
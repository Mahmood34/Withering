using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for load the game.
/// </summary>
public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start ()
    {
        GameManager.instance.LoadPlayer ();
    }

}
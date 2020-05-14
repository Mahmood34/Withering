using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for handling the initiation of the game.
/// </summary>
public class InitiateGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            GameManager.BeginNewGameFromForest ();
        }
    }

    public void StatCutscenes ()
    {

    }

    /// <summary>
    /// Load the new game.
    /// </summary>
    public void loadNewGame ()
    {
        GameManager.BeginNewGameFromForest ();
    }
}
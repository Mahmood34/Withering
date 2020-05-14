using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class for handling functionality of the main menu.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// Name of the scene to load.
    public string loadName;
    /// Name of the scene to unload.
    public string unloadName;
    /// Reference to load button.
    public Button loadButton;

    private void Awake() {
        if(SaveSystem.checkIfSaveExists())
        {
            loadButton.interactable = true;
        }
    }

    /// <summary>
    /// Method for when the "New Game" button is pressed and a new game starts.
    /// </summary>
    public void newGame ()
    {
        SceneManager.LoadScene ("CutsceneEscape");
    }

    /// <summary>
    /// Method for when the "Load Game" button is pressed and the the player is loaded and warped to the last saved location.
    /// </summary>
    public void ClickLoadGame ()
    {
        if (loadName != "")
            SceneManager.LoadScene ("Overworld");
        if (unloadName != "")
            StartCoroutine ("UnloadScene");

        SceneManager.LoadScene ("PreLoad");
        // GameManager.instance.LoadPlayer ();

        // GameManager gameManager = new GameManager();
        // gameManager.LoadPlayer();
    }

    /// <summary>
    /// IEnumerator for unloading the scene.
    /// </summary>
    IEnumerator UnloadScene ()
    {
        yield return new WaitForSeconds (.10f);
        Unload (unloadName);
    }

    /// <summary>
    /// Load in the next scene using the <paramref name="sceneName"/>.
    /// </summary>
    /// <param name="sceneName">The name of the scene to load.</param>
    public void Load (string sceneName)
    {
        if (!SceneManager.GetSceneByName (sceneName).isLoaded)
            SceneManager.LoadScene (sceneName, LoadSceneMode.Additive);
    }

    /// <summary>
    /// Unload the current scene.
    /// </summary>
    /// <param name="sceneName">The name of the scene to unload.</param>
    public void Unload (string sceneName)
    {
        if (!SceneManager.GetSceneByName (sceneName).isLoaded)
            SceneManager.UnloadSceneAsync (sceneName);
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame ()
    {
        Application.Quit ();
    }
}
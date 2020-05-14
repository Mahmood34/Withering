using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for handling screen transition with a fade effect.
/// </summary>
/// <inheritdoc/>
public class SceneChange : Interactable
{
    /// Animator that contains the transiton animation.
    public Animator transition;
    /// Durantion of the animation effect.
    float transitionTime = 1.0f;
    /// Index of the current scene.
    int currentSceneIndex;
    /// Index of the next scene to be loaded.
    public string nextScene;
    /// Target SpawnPoint for the player to be warped to.
    public GameObject SpawnPoint;
    /// Check for if it is a flag.
    public bool isFlag;
    /// Associated flag.
    public string flag;

    void Start ()
    {
        currentSceneIndex = SceneManager.GetActiveScene ().buildIndex;
    }

    /// <summary>
    /// Interact with the SceneChange collider.
    /// </summary>
    /// <inheritdoc/>
    public override void Interact ()
    {
        if (isFlag)
        {
            FlagManager.instance.RemoveFlag (flag);
        }
        PlayerManager.instance.StopPlayerMovement ();
        StartCoroutine (ScreenTransition ());
    }

    /// <summary>
    /// IEnumerator for transitioning to another scene with fade effect.
    /// </summary>
    IEnumerator ScreenTransition ()
    {
        transition.SetTrigger ("Start");
        yield return new WaitForSeconds (transitionTime);
        GameManager.ChangeScenes (nextScene, SpawnPoint.transform.position);
        PlayerManager.instance.StartPlayerMovement ();

    }

}
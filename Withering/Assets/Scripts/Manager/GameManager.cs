using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for managing the game.
/// Contains methods for saving and load the game and changing scenes.
/// </summary>
public class GameManager : MonoBehaviour
{

    /// Singleton instance of the GameManager.
    public static GameManager instance;
    /// Check for if the player is in game (excluding title menu and cutscenes).
    public bool inGame = false;
    /// Stores the last location of the Player.
    public static Vector3 lastSavedSpawnPoint;
    /// List of all areas that do not contain monsters.
    public static List<string> nonMonsterAreas = new List<string> ();

    private void Awake ()
    {
        if (instance != null)
        {
            Destroy (this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad (this.gameObject);
        nonMonsterAreas.Add ("Emeran");
        nonMonsterAreas.Add ("Rubo");
        nonMonsterAreas.Add ("Sapphor");
        nonMonsterAreas.Add ("Peara");
        nonMonsterAreas.Add ("Topa");
        nonMonsterAreas.Add ("Diamar");
    }

    /// <summary>
    /// Initiate the new game.
    /// </summary>
    public static void BeginNewGameFromForest ()
    {
        SceneManager.LoadScene ("Forest");
        Vector3 firstPoint = new Vector3 (7, 0, 80);
        lastSavedSpawnPoint = firstPoint;
    }

    /// <summary>
    /// Gets the build index of the current scene the player is currently in.
    /// </summary>
    /// <returns>The current scene index.</returns>
    public static int GetCurrentSceneIndex ()
    {
        return SceneManager.GetActiveScene ().buildIndex;
    }

    /// <summary>
    /// Changes the scene, warps the player to the <paramref name="spawnPoint"/> and sets the cameras location accordingly.
    /// Battle arena changes depeding on what the <paramref name="nextScene"/> is.
    /// </summary>
    /// <param name="nextScene">The name of the next scene to load.</param>
    /// <param name="spawnPoint">The Location for the player to spawn at.</param>
    public static void ChangeScenes (string nextScene, Vector3 spawnPoint)
    {
        lastSavedSpawnPoint = spawnPoint;
        Debug.Log (spawnPoint);
        SceneManager.LoadScene (nextScene);
        if (nonMonsterAreas.Contains (nextScene))
        {
            PlayerManager.instance.DisableMonsterEncounters ();
        }
        else
        {
            PlayerManager.instance.EnableMonsterEncounters ();
        }
        Debug.Log (SceneManager.GetActiveScene ().name);

        PlayerManager.instance.WarpPlayer (spawnPoint);
        FindObjectOfType<Camera> ().transform.position = PlayerManager.instance.player.transform.position;
    }

    /// <summary>
    /// Instructs the SaveSystem to save the player.
    /// </summary>
    public void SavePlayer ()
    {
        SaveSystem.SavePlayer (PlayerManager.instance.player);
        Debug.Log ("Saved");
    }

    /// <summary>
    /// Load the player information into the player object.
    /// </summary>
    public void LoadPlayer ()
    {
        PlayerData data = SaveSystem.LoadPlayer ();
        inGame = true;
        SceneManager.LoadScene (data.sceneIndex);
        Vector3 newPosition = new Vector3 (data.position[0], data.position[1], data.position[2]);


        object[] items = Resources.LoadAll ("Items", typeof (Item));
        Inventory.instance.RemoveAll ();
        foreach (string dataItem in data.inventory)
        {
            foreach (Item item in items)
            {
                if (item.name.Equals (dataItem))
                {
                    Inventory.instance.Add (item);
                }
            }
        }

        object[] equipment = Resources.LoadAll ("Items", typeof (Equipment));
        foreach (string dataItem in data.equipment)
        {
            foreach (Equipment equipmentItem in equipment)
            {
                if (equipmentItem.name.Equals (dataItem))
                {
                    EquipmentManager.instance.Equip (equipmentItem);
                }
            }
        }

        FlagManager.instance.setFlags (data.flags);
        Time.timeScale = 1;

        PlayerManager.instance.StartPlayerMovement ();
        PlayerManager.instance.WarpPlayer (newPosition);
    }

    /// <summary>
    /// Destroys this Game object.
    /// </summary>
    public void DestroyThis ()
    {
        Destroy (this.gameObject);
    }

    /// <summary>
    /// Begins a different cutscene depending on the level.
    /// </summary>
    public void EndGame ()
    {
        if (PlayerStats.trustLevel > 500)
        {
            SceneManager.LoadScene ("GoodEnding");
        }
        else
        {
            SceneManager.LoadScene ("BadEnding");
        }
    }

    /// <summary>
    /// Quit the game.
    /// </summary>
    public void ReturnToTitleScreen ()
    {
        SceneManager.LoadScene ("TitleMenu");
        Destroy (this.gameObject);
        Time.timeScale = 1;
    }

}
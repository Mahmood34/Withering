using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manage the load and exit of battles.
/// </summary>
public class BattleManager : MonoBehaviour
{
    /// Singleton instance of the BattleManger.
    public static BattleManager instance;
    /// The index of the scene before entering a battle.
    public static int currentSceneIndex;
    /// The last save position of the Player before a battle.
    public static Vector3 lastSavedPosition;
    /// Check if the battle is a boss battle.
    public static bool isBossBattle = false;
    /// Name of the Boss to be loaded in using the MonsterSpawner.
    public static string bossName;
    /// Scene name of combat arenas, this can be change to different themed arenas.
    static string combatArena = "ForestCombat";

    public bool inBattle;

    private void Awake ()
    {
        if (instance != null)
        {
            Destroy (this);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad (this);
    }

    /// <summary>
    /// Method for loading a battle.
    /// </summary>
    /// <param name="lastSavedPosition">The location of the player before initiating a battle.</param>
    public void LoadBattle (Vector3 lastSavedPosition)
    {
        switch (SceneManager.GetActiveScene ().name)
        {
            case "Forest":
            case "Emeran":
                SetCombatArena ("ForestCombat");
                break;
            case "VolcanoCave":
                SetCombatArena ("VolcanoCombat");
                break;
            case "Cave":
                SetCombatArena ("CaveCombat");
                break;
            case "SnowForest":
                SetCombatArena ("SnowCombat");
                break;
            case "Desert":
                SetCombatArena ("DesertCombat");
                break;
            case "Overworld":
                SetCombatArena ("ForestCombat");
                break;
        }

        currentSceneIndex = SceneManager.GetActiveScene ().buildIndex;
        BattleManager.lastSavedPosition = lastSavedPosition;
        PlayerManager.instance.DisableMonsterEncounters ();
        PlayerManager.instance.PlayerIsInBattle ();
        inBattle = true;
        SceneManager.LoadScene (combatArena);
        FindObjectOfType<Camera> ().transform.position = PlayerManager.instance.player.transform.position;
        PlayerManager.instance.StartPlayerMovement ();
    }

    /// <summary>
    /// Method for exiting a battle.
    /// </summary>
    public void ExitBattle ()
    {
        PlayerManager.instance.WarpPlayer (lastSavedPosition);
        FindObjectOfType<Camera> ().transform.position = PlayerManager.instance.player.transform.position;
        if (bossName == "CrystaBoss")
        {
            SceneManager.LoadScene ("Overworld");
        }
        else
        {
            SceneManager.LoadScene (currentSceneIndex);
        }
        PlayerManager.instance.EnableMonsterEncounters ();
        PlayerManager.instance.PlayerIsNotInBattle ();
        inBattle = false;
        bossName = null;
        isBossBattle = false;
    }

    /// <summary>
    /// Method for setting the combat arena depending on where the Player.
    /// </summary>
    /// <param name="newCombatArena">The name of the new combat arena to be loaded when entering a battle.</param>
    public void SetCombatArena (string newCombatArena)
    {
        combatArena = newCombatArena;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="finalBossName">The name of the final boss.</param>
    public void StartFinalBoss (string finalBossName, Vector3 positionToSave)
    {
        lastSavedPosition = positionToSave;
        SceneManager.LoadScene ("FinalBossCutscene");

    }

    /// <summary>
    /// Starts the final boss battle.
    /// </summary>
    /// <param name="finalBossName">The name of the final boss.</param>
    public void StartFinalBossBattle (string finalBossName)
    {
        isBossBattle = true;
        bossName = finalBossName;
        SetCombatArena ("CaveCombat");
        LoadBattle (new Vector3(0,10,-30));
        PlayerManager.instance.StartPlayerMovement ();
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Class for managing states of a Player.
/// </summary>
public class PlayerManager : MonoBehaviour
{
    /// Singleton instance of the PlayerManager.
    public static PlayerManager instance;
    /// Reference to the Player in the game.
    public Player player;
    /// Reference to PlayerStats.
    public PlayerStats playerStats;
    public PartnerController partner;

    void Start ()
    {
        if (instance != null)
        {
            {
                Destroy (this);
                return;
            }
        }
        instance = this;
        GameObject.DontDestroyOnLoad (this);
    }

    /// <summary>
    /// Get the position of the Player.
    /// </summary>
    public Vector3 getPlayerPosition ()
    {
        return player.GetComponent<PlayerController> ().transform.position;
    }

    /// <summary>
    /// Notify PlayerController that Player cannot move.
    /// </summary>
    public void StopPlayerMovement ()
    {
        player.GetComponent<PlayerController> ().canMove = false;
    }

    /// <summary>
    /// Notify PlayerController that Player can move. 
    /// </summary>
    public void StartPlayerMovement ()
    {
        player.GetComponent<PlayerController> ().canMove = true;
    }

    /// <summary>
    /// Warp the player to a specific <paramref name="targetWarp"/>.
    /// </summary>
    /// <param name="targetWarp">The location for the player to warp to.</param>
    public void WarpPlayer (Vector3 targetWarp)
    {
        player.GetComponent<NavMeshAgent> ().Warp (targetWarp);
        partner.GetComponent<NavMeshAgent> ().Warp (targetWarp);
    }

    /// <summary>
    /// Notify PlayerController that Player can encounter monsters. 
    /// </summary>
    public void EnableMonsterEncounters ()
    {
        player.GetComponent<PlayerController> ().canEncounterMonsters = true;
    }

    /// <summary>
    /// Notify PlayerController that Player can not encounter monsters.
    /// </summary>
    public void DisableMonsterEncounters ()
    {
        player.GetComponent<PlayerController> ().canEncounterMonsters = false;
    }

    /// <summary>
    /// Notify PlayerController that Player is in battle. 
    /// </summary>
    public void PlayerIsInBattle ()
    {
        player.GetComponent<PlayerController> ().inBattle = true;
    }

    /// <summary>
    /// Notify PlayerController that Player is not in battle.
    /// </summary>
    public void PlayerIsNotInBattle ()
    {
        player.GetComponent<PlayerController> ().inBattle = false;
    }

    /// <summary>
    /// Health the player by a certain <paramref name="amount">.
    /// </summary>
    /// <param name="amount">The amount to heal the player by.</param>
    public bool Heal (int amount)
    {
        if (playerStats.currentHealth == playerStats.maxHealth)
        {
            playerStats.currentHealth = playerStats.maxHealth;
            return false;
        }
        else
        {
            playerStats.currentHealth += amount;
            return true;
        }
    }

}
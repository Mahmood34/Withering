using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class containing Enemy details.
/// </summary>
[RequireComponent (typeof (EnemyStats))]
public class Enemy : MonoBehaviour
{

    /// The stats of the enemy.
    public CharacterStats myStats;
    /// CharacterCombat of the Player.
    public CharacterCombat playerCombat;
    /// 
    public Rigidbody playerRigidbody;
    /// Direction for the Enemy to move in.
    public Vector3 moveDirection;

    void Start ()
    {
        myStats = GetComponent<CharacterStats> ();
        playerRigidbody = GetComponent<Rigidbody> ();
    }

    /// <summary>
    /// Handles when the Enemy has been hit by the Player Weapon.
    /// </summary>
    public void Hit ()
    {
        playerCombat = PlayerManager.instance.player.GetComponent<CharacterCombat> ();
        if (playerCombat != null)
        {
            playerCombat.Attack (myStats);
        }
        moveDirection = playerRigidbody.transform.position - PlayerManager.instance.player.transform.position;
        playerRigidbody.AddForce (moveDirection.normalized * -500f);
    }
}
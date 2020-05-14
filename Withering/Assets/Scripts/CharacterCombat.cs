using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for handling Combat for any class that implements CharacterCombat.
/// </summary>
[RequireComponent (typeof (CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    /// Speed of the attack.
    public float attackSpeed;
    /// Delay between attacks.
    private float attackCooldown = 0f;
    /// Stats of the character.
    CharacterStats myStats;

    void Start ()
    {
        myStats = GetComponent<CharacterStats> ();
    }

    void Update ()
    {
        attackCooldown -= Time.deltaTime;
    }

    /// <summary>
    /// Attack the Player or Enemy and adjust their <paramref name="targetStats"/>.
    /// </summary>
    /// <param name="targetStats">The Stats of the target.</param>
    public void Attack (CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            targetStats.TakeDamage (myStats.Attack.GetValue ());
            attackCooldown = 0.5f / attackSpeed;
        }

    }
}
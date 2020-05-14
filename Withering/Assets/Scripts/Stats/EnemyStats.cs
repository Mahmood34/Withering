using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for handling the EnemyStats.
/// </summary>
/// <inheritdoc/>
public class EnemyStats : CharacterStats
{
    /// Check if Enemy is a boss.
    public bool isBoss;
    /// Flag for if Enemy is a boss.
    public List<string> flags;
    /// Amount of trust to give to the Player after the Enemy has been defeated.
    public int trustToGive;

    /// <summary>
    /// Override method for when the Enemy dies.
    /// If the Enemy is a boss, call the FlagManager.
    /// </summary>
    /// <inheritdoc/>
    public override void Die ()
    {
        base.Die ();
        if (isBoss)
        {
            foreach (string flag in flags)
            {
                FlagManager.instance.RemoveFlag (flag);
            }
            if (BattleManager.bossName == "CrystaBoss")
            {
                GameManager.instance.EndGame();
                GameManager.instance.DestroyThis();
            }
        }
        GetComponent<EnemyController> ().canMove = false;
        GetComponent<EnemyController> ().animator.SetTrigger ("Die");

        GetComponent<Collider> ().enabled = false;
        Destroy (gameObject, 2);
        PlayerManager.instance.player.myStats.TrustUp (trustToGive);
    }
}
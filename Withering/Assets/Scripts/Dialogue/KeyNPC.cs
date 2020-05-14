using System.Collections;
using System.Collections.Generic;
using Fluent;
using UnityEngine;

/// <summary>
/// Base abstract class for any key NPCs that require these functions to affect the game.
/// </summary>
public abstract class KeyNPC : MyFluentDialogue
{
    /// Counter for how many flags have been checked. This is used to track progression.
    public int flagsChecked;
    /// List of flags associated with the specific NPC.
    public List<string> flags;
    /// The flag to be removed.
    public string flagToRemove;

    /// <summary>
    /// Calls the TrustUp function in the PlayerStats class.
    /// </summary>
    protected void TrustUp ()
    {
        PlayerManager.instance.playerStats.TrustUp (50);
    }

    /// <summary>
    /// Calls the TrustDown function in the PlayerStats class.
    /// </summary>
    protected void TrustDown ()
    {
        PlayerManager.instance.playerStats.TrustDown (50);
    }

    /// <summary>
    /// Calls the CheckFlags check how much progression has been made.
    /// </summary>
    /// <param name="flagsToCheck">A list of flags to check.</param>
    protected void CheckFlags (List<string> flagsToCheck)
    {
        flagsChecked = 0;

        foreach (string flag in flagsToCheck)
        {
            if (!FlagManager.instance.Checkflag (flag))
            {
                flagsChecked += 1;
            }
        }
    }

    /// <summary>
    /// Calls the RemoveFlag function in the FlagManager.
    /// </summary>
    /// <param name="flag">The flag to be removed.</param>
    protected void RemoveFlag (string flag)
    {
        FlagManager.instance.RemoveFlag (flag);

    }
}
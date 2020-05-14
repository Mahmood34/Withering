using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage the flags of the game to check which key events have happenned.
/// </summary>
public class FlagManager : MonoBehaviour
{
    /// Singleton instance of the FlagManager.
    public static FlagManager instance;
    /// List containing the flags of events yet to happen.
    public List<string> flags = new List<string> ();

    private void Awake ()
    {
        if (instance != null)
        {
            Destroy (this);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad (this);
        LoadFlags ();
    }

    /// <summary>
    /// Check if the list of flags contain a particular <paramref name="flag"/> and responds if true or false.
    /// </summary>
    /// <returns>If flag is in collection or not.</returns>
    /// <param name="flag">The flag to be checked.</param>
    public bool Checkflag (string flag)
    {
        if (flags.Contains (flag))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Sets the flags of the game if the player chooses to load a previous game.
    /// </summary>
    /// <param name="savedFlags">The flags loaded from a save file.</param>
    public void setFlags (string[] savedFlags)
    {
        flags = new List<string> (savedFlags);
    }

    /// <summary>
    /// Loads a default list of flags.
    /// </summary>
    void LoadFlags ()
    {
        flags.Add ("escapingFromCrysta");
        flags.Add ("sleptInCabin");
        flags.Add ("talkedToLittleSister");
        flags.Add ("talkedToOlderSister");
        flags.Add ("saveLittleSister");
        flags.Add ("EmeranBossDefeated");
        flags.Add ("TalkedToRuboLeader");
        flags.Add ("TalkedToSapphorLeader");
        flags.Add ("TalkedToRuboLeaderAgain");
        flags.Add ("RuboBossDefeated");
        flags.Add ("TalkedToSapphorLeaderAgain");
        flags.Add ("TalkedToPrince");
        flags.Add ("TalkedToGirl");
        flags.Add ("TalkedToPrince");
        flags.Add ("talkedToScientist");
    }

    /// <summary>
    /// Remove a <paramref name="flag"/> from the list of flags.
    /// </summary>
    /// <param name="flag">The flag to be removed</param>
    public bool RemoveFlag (string flag)
    {
        if (flags.Contains (flag))
        {
            flags.Remove (flag);
            Debug.Log ("Flag deleted");
            return true;
        }
        return false;
    }
}
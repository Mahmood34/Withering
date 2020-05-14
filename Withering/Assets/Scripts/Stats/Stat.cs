using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// <summary>
/// Class for managing a single Stat.
/// </summary>
public class Stat
{
    /// Base value of a Stat.
    [SerializeField]
    public int baseValue;
    /// List of all the modifiers.
    private List<int> modifiers = new List<int> ();

    /// <summary>
    /// Returns the Stat value with all the modifiers applied to it.
    /// </summary>
    /// <returns>
    /// Stat value with modifiers applied to it.
    /// <returns>
    public int GetValue ()
    {
        if (baseValue < 10)
        {
            baseValue = 10;
        }
        int finalValue = baseValue;
        modifiers.ForEach (x => finalValue += x);
        return finalValue;
    }

    /// <summary>
    /// Adds a <paramref name="modifier"/> to the modifiers list.
    /// </summary>
    /// <param name="modifier">An integer that modifies the stat.</param>
    public void AddModifier (int modifier)
    {
        if (modifier != 0)
            modifiers.Add (modifier);
    }

    /// <summary>
    /// Removes a <paramref name="modifier"/> from the modifiers list.
    /// </summary>
    /// <param name="modifier">An integer that modifies the stat.</param>
    public void RemoveModifier (int modifier)
    {
        if (modifier != 0)
            modifiers.Remove (modifier);
    }

}
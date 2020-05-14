using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to hand the removal of a flag.
/// </summary>
public class RemoveFlag : Interactable
{
    /// Flag to be removed.
    public string flag;

    public override void Interact ()
    {
        FlagManager.instance.RemoveFlag (flag);
    }
}
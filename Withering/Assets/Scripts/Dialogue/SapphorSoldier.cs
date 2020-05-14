using System.Collections;
using System.Collections.Generic;
using Fluent;
using UnityEngine;

/// <summary>
/// The Dialogue for an NPC.
/// </summary>
public class SapphorSoldier : MyFluentDialogue
{

    public override FluentNode Create ()
    {
        return
        Show () *
        Options(
            Write ("HALT! You cannot proceed any further.") *
            Option ("What's going on?") *
            Write ("Someone from the Rubo Kingdom has stole literature from our Library.") *
            Write ("Our commander has ordered us to lock down this bridge.") *
            Hide () *
            End ()
        );

    }

}
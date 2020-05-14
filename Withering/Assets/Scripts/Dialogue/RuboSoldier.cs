using System.Collections;
using System.Collections.Generic;
using Fluent;
using UnityEngine;

/// <summary>
/// The Dialogue for an NPC.
/// </summary>
public class RuboSoldier : MyFluentDialogue
{

    public override FluentNode Create ()
    {
        return
        Show () *
        Options(
            Write ("Our Leader has ordered us to defend our kingdom. You may not enter at this point in time.") *
            Option ("What's going to happen?") *
            Write ("Nothing will happen unless Sapphor raise their weapons.") *
            Write ("If that happens, we have been instructed to fight.") *
            Hide () *
            End ()
        );

    }

}
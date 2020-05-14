using System.Collections;
using System.Collections.Generic;
using Fluent;
using UnityEngine;

/// <summary>
/// The Dialogue for an NPC.
/// </summary>
public class EmeranLittleSister : KeyNPC
{
    public override FluentNode Create ()
    {
        return
        Show () *
            Options (
                Write ("...") *
                Option ("What are you doing?") *
                Write ("I'm going to fight that monster that everyone is scared of.") *
                Pause (1) *
                Options (
                    Option ("Don't go, it's too dangerous.") *
                    Do (() => TrustUp ()) *
                    Do (() => RemoveFlag (flagToRemove)) *
                    Write ("You can't stop me, im going to prove to everyone that I'm not just the <color=#0000ffff>Commanding Knight's little sister.") *
                    Hide () *
                    End () *

                    Option ("Good Luck!") *
                    Do (() => TrustDown ()) *
                    Do (() => RemoveFlag (flagToRemove)) *
                    Write ("Thanks!") *
                    Hide () *
                    End ()
                )
            );

    }

}
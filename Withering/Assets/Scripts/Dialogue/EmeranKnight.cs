using System.Collections;
using System.Collections.Generic;
using Fluent;
using UnityEngine;

/// <summary>
/// The Dialogue for an NPC.
/// </summary>
public class EmeranKnight : KeyNPC
{

    public override FluentNode Create ()
    {
        return
        Show () *
            Do (() => CheckFlags (flags)) *

            If (() => flagsChecked < 2,
                Options (
                    Write ("Hello, welcome to Emeran, I am the Commanding knight of this Kingdom.") *
                    Option ("Have you heard the situation in Crysta?") *
                    Write ("No, I am not aware of anything going on there.") *
                    Pause (1) *
                    Hide () *
                    End () *

                    Option ("Your sister has gone fight that weird monster.").VisibleIf (() => flagsChecked == 1) *
                    Write ("What! No... can you please go an save her?") *
                    Pause (1) *

                    Options (
                        Option ("Yes") *
                        Do (() => TrustUp ()) *
                        Do (() => RemoveFlag (flagToRemove)) *
                        Hide () *
                        End () *

                        Option ("No") *
                        Do (() => TrustDown ()) *
                        Do (() => RemoveFlag (flagToRemove)) *
                        Hide () *
                        End ()
                    )

                )
            ) *

            If (() => flagsChecked == 2,
                Write ("I have nothing more to speak to you about.") *
                Pause (1) *
                Hide () *
                End ()

            ) *

            If (() => flagsChecked == 3,
                Write ("Thank you for saving my sister.") *
                Pause (1) *
                Hide () *
                End ()

            );

    }

}
using System.Collections;
using System.Collections.Generic;
using Fluent;
using UnityEngine;

/// <summary>
/// The Dialogue for an NPC.
/// </summary>
public class SapphorLeader : KeyNPC
{

    public override FluentNode Create ()
    {
        return
        Show () *
            Do (() => CheckFlags (flags)) *

            If (() => flagsChecked == 0,
                Options (
                    Write ("Welcome to Sapphor.") *
                    Option ("Do you know what happenned with crysta?") *
                    Write ("I'm afraid we do not have that sort of knowledge to guide you.") *
                    Options (
                        Option ("I've been told by the Rubo leader that there is a misunderstanding with the literature incident.") *
                        Write ("Regarding that matter, we have witnesses here at Sapphor who have seen a masked man heading towards Rubo.") *
                        Write ("That seems to be good enough proof to me.") *
                        Pause (1) *

                        Options (
                            Option ("I don't think its a person from Rubo. I think it's someone else.") *
                            Write ("If you can find any proof, I will believe you.") *
                            Do (() => TrustUp ()) *
                            Do (() => RemoveFlag (flagToRemove)) *
                            Hide () *
                            End () *

                            Option ("You might be right.") *
                            Write ("Indeed.") *
                            Do (() => TrustDown ()) *
                            Do (() => RemoveFlag (flagToRemove)) *
                            Hide () *
                            End ()
                        )

                    )

                )
            ) *

            If (() => flagsChecked == 1,
                Write ("I thought Rubo was a pround kingdom, what could lead to this happenning?") *
                Pause (1) *
                Hide () *
                End ()

            ) *

            If (() => flagsChecked == 2,
                Write ("The literature!, it was found. How?") *
                Write ("") *
                Option ("A weird monster had it.") *
                Write ("A weird monster you say. Well, it does not matter anymore. The literature has been found.") * 
                Do (() => RemoveFlag ("TalkedToSapphorLeaderAgain")) *
                Pause (1) *
                Hide () *
                End ()

            ) *

            If (() => flagsChecked >= 3,
                Write ("There is no more to take about.") *
                Pause (1) *
                Hide () *
                End ()

            );

    }

}
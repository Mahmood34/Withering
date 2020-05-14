using System.Collections;
using System.Collections.Generic;
using Fluent;
using UnityEngine;

/// <summary>
/// The Dialogue for an NPC.
/// </summary>
public class RuboLeader : KeyNPC
{

    public override FluentNode Create ()
    {
        return
        Show () *
            Do (() => CheckFlags (flags)) *

            If (() => flagsChecked == 0,
                Options (
                    Write ("What business do you have here in Rubo.") *
                    Option ("Do you know what happenned with crysta?") *
                    Write ("No, I am far to busy with other pressing matters.") *
                    Options (
                        Option ("What do you mean?") *
                        Write ("Sapphor are accusion us of stealing their literature from their library.") *
                        Write ("We are a pround kingdom, we would not commit such a shameful crime.") *
                        Write ("I do not want any of my people going to Sapphor to reason with them. Can you go instead?") *

                        Options (
                            Option ("Yes, I can go and investigate for you.") *
                            Write ("Excellent, I will be waiting for good news.") *
                            Do (() => TrustUp ()) *
                            Do (() => RemoveFlag (flagToRemove)) *
                            Hide () *
                            End () *

                            Option ("This is not any of my business") *
                            Write ("Fine, I will dispatch one of my men to go instead.") *
                            Do (() => TrustDown ()) *
                            Do (() => RemoveFlag (flagToRemove)) *
                            Hide () *
                            End ()
                        )

                    )

                )
            ) *

            // Talked to Rubo Leader
            If (() => flagsChecked == 1,
                Write ("Sapphor must understand that we did not commit any crimes.") *
                Pause (1) *
                Hide () *
                End ()

            ) *

            // Talked to Sapphor Leader
            If (() => flagsChecked == 2,
                Write ("I see, so a masked man was seen stealing the literature.") *
                Write ("One of my soldiers did see a masked man head to the volcano.") *
                Write ("Go there and investigate.") *
                Options (
                    Option ("Okay.") *
                    Write ("Good, may Luminance give you strength.") *
                    Do (() => TrustUp ()) *
                    Do (() => RemoveFlag ("TalkedToRuboLeaderAgain")) *
                    Hide () *
                    End () *

                    Option ("This is too dangerous for us.") *
                    Write ("Fine, I will go there myself.") *
                    Do (() => TrustDown ()) *
                    Do (() => RemoveFlag ("RuboBossDefeated")) *
                    Hide () *
                    End ()
                )

            ) *

            If (() => flagsChecked >= 3,
                Write ("Our business here is done.") *
                Pause (1) *
                Hide () *
                End ()

            );

    }

}
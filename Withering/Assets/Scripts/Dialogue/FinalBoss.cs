using System.Collections;
using System.Collections.Generic;
using Fluent;
using UnityEngine;

/// <summary>
/// Dialogue between the two main characters before entering the final boss.
/// </summary>
public class FinalBoss : KeyNPC
{

    public override FluentNode Create ()
    {
        return
        Show () *
            If (() => flagsChecked == 0,
                Options (
                    Write ("Mika, This it...") *
                    Write ("Are you ready?") *
                    Options (
                        Option ("Yes!") *
                        Do (() => InitiateFinalBoss ("CrystaBoss")) *
                        Hide () *
                        End () *

                        Option ("No, not yet.") *
                        Write ("Do not take too long, we do not know what might happen.") *
                        Hide () *
                        End ()
                    )
                )
            );

    }

    private void InitiateFinalBoss (string bossName)
    {
        FluentManager.Instance.RemoveScript(GetComponent<FluentScript>());
        PlayerManager.instance.StopPlayerMovement();
        BattleManager.instance.StartFinalBoss(bossName, PlayerManager.instance.player.transform.position);
    }

}
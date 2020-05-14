using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for Initiating the final boss.
/// </summary>
public class InitiateFinalBoss : MonoBehaviour
{
    public void triggerFinalBoss ()
    {
        BattleManager.instance.StartFinalBossBattle ("CrystaBoss");
    }
}
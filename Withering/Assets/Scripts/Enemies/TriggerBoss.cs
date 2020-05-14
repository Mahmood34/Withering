using UnityEngine;

/// <summary>
/// Class for triggering a boss battle.
/// </summary>
public class TriggerBoss : MonoBehaviour
{
    /// Name of the boss.
    public string bossName;
    /// Flag that is associated with the boss.
    public string flag;
    /// SpawnPoint for wher the player should be spawned at after the boss battle.
    public Vector3 spawnPoint;

    /// <summary>
    /// Method for detecting if the player enters the area.
    /// </summary>
    /// <param name="other">The player object that collides with this object.</param>
    private void OnTriggerEnter (Collider other)
    {
        if (FlagManager.instance.Checkflag (flag))
        {
            BattleManager.isBossBattle = true;
            BattleManager.bossName = bossName;
            BattleManager.instance.LoadBattle (spawnPoint);
        };
    }
}
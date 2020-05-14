using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for handling the PlayerStats.
/// </summary>
/// <inheritdoc/>
public class PlayerStats : CharacterStats
{
    /// Trust level of the charcter. Acts as a mulitplier for all other stats.
    public static int trustLevel;

    void Start ()
    {
        EquipmentManager.instance.onEquipmentChanged += onEquipmentChanged;
    }

    /// <summary>
    /// Increase the trust level by <paramref name="trustValue"/>.
    /// </summary>
    /// <param name="trustValue">The trust value to increase the trust level by.</param>
    public void TrustUp (int trustValue)
    {
        trustLevel += trustValue;
        Attack.baseValue += trustValue;
        Defence.baseValue += trustValue;
        MagicAttack.baseValue += trustValue;
        MagicDefence.baseValue += trustValue;
        Agility.baseValue += trustValue;
    }

    /// <summary>
    /// Decrease the trust level by <paramref name="trustValue"/>.
    /// </summary>
    /// <param name="trustValue">The trust value to decrese the trust level by.</param>
    public void TrustDown (int trustValue)
    {
        trustLevel -= trustValue;
        Attack.baseValue -= trustValue;
        Defence.baseValue -= trustValue;
        MagicAttack.baseValue -= trustValue;
        MagicDefence.baseValue -= trustValue;
        Agility.baseValue -= trustValue;
    }

    /// <summary>
    /// Change the Stats of the Player when an Equipment is changed.
    /// </summary>
    /// <param name="newItem">The new item to be equipped.</param>
    /// <param name="oldItem">The old item to be unequipped.</param>
    void onEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            Defence.AddModifier (newItem.AttackModifier);
            Attack.AddModifier (newItem.DefenceModifier);
            MagicAttack.AddModifier (newItem.MagicAttackModifier);
            MagicDefence.AddModifier (newItem.MagicDefenceModifier);
            Agility.AddModifier (newItem.AgilityModifier);
        }

        if (oldItem != null)
        {
            Defence.RemoveModifier (oldItem.AttackModifier);
            Attack.RemoveModifier (oldItem.DefenceModifier);
            MagicAttack.RemoveModifier (oldItem.MagicAttackModifier);
            MagicDefence.RemoveModifier (oldItem.MagicDefenceModifier);
            Agility.RemoveModifier (oldItem.AgilityModifier);
        }
    }

    /// <summary>
    /// Override method to exit the battle, decrease the trust level and reset Player health.
    /// </summary>
    public override void Die ()
    {
        base.Die ();
        BattleManager.instance.ExitBattle ();
        PlayerManager.instance.player.myStats.TrustDown (10);
        currentHealth = maxHealth;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
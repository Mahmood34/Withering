using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Equipment", menuName = "Inventory/Equipment")]
/// <summary>
/// Equipment class that can create scriptable object.
/// </summary>
/// <inheritdoc/>
public class Equipment : Item
{

    /// 
    public EquipmentSlot equipmentSlot;
    /// Attack modifier to be applied to PlayerStat.
    public int AttackModifier;
    /// Defence modifier to be applied to PlayerStat.
    public int DefenceModifier;
    /// Magic Attack modifier to be applied to PlayerStat.
    public int MagicAttackModifier;
    /// Magic Defence modifier to be applied to PlayerStat.
    public int MagicDefenceModifier;
    /// Agility modifier to be applied to PlayerStat.
    public int AgilityModifier;

    /// <summary>
    /// Override method to equip the Equipment.
    /// </summary>
    public override void Use ()
    {
        base.Use ();
        EquipmentManager.instance.Equip (this);
        RemoveFromInventory ();
    }
}

/// Enum of possible Equipment slots.
public enum EquipmentSlot { Body, Weapon, Shield, Class }
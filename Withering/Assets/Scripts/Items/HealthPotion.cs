using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New HealthPotion", menuName = "Inventory/HealthPotion")]
/// <summary>
/// Health potion class to hold basic attributes.
/// </summary>
/// <inheritdoc/>
public class HealthPotion : Item
{
    public int healAmount;
    /// <summary>
    /// Increase the health of the Player.
    /// </summary>
    public override void Use ()
    {
        base.Use ();
        if (PlayerManager.instance.Heal(healAmount))
        {
            RemoveFromInventory ();
        }
    }
}
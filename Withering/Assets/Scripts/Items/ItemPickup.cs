using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for when the Player picks up an Item.
/// </summary>
/// <inheritdoc/>
public class ItemPickup : Interactable
{
    /// Reference to specific scriptable object Item.
    public Item item;

    private void Start() {
        if(Inventory.instance.isInInventory(item))
        {
            Destroy (this.gameObject);

        };
    }

    /// <summary>
    /// Override method for interacting with the Interactable.
    /// </summary>
    public override void Interact ()
    {
        base.Interact ();
        PickUp ();
    }

    /// <summary>
    /// Method for picking up an Item and adding it the Inventory.
    /// </summary>
    void PickUp ()
    {
        bool wasPickedUp = Inventory.instance.Add (item);
        if (wasPickedUp)
        {
            Debug.Log ("Pickup up " + item.name);
            Destroy (this.gameObject);
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for handling an individual Item slot.
/// </summary>
public class InventorySlot : MonoBehaviour
{
    /// Item icon.
    public Image icon;
    /// Botton for removing the Item.
    public Button removeButton;
    /// The Item.
    Item item;

    /// <summary>
    /// The Item is added to a slot in the Inventory UI.
    /// </summary>
    /// <param name="newItem">The item to be added to the inventory slot.</param>
    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }

    /// <summary>
    /// Clear the Item from a specific slot in the Inventory UI.
    /// </summary>
    public void ClearSlot ()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    /// <summary>
    /// Remove the Item from the Inventory UI.
    /// </summary>
    public void OnRemoveButton ()
    {
        Inventory.instance.Remove (item);
    }

    /// <summary>
    /// Use the Item.
    /// </summary>
    public void UseItem ()
    {
        if (item != null)
        {
            item.Use ();
        }

    }
}
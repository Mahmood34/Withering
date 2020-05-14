using UnityEngine;

/// <summary>
/// Base class for an Item.
/// </summary>
[CreateAssetMenu (fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    /// Placeholder name of Item when create in editor menu.
    new public string name = "New Item";
    /// Item icon.
    public Sprite icon = null;
    /// Check if Item is default.
    public bool isDefualtItem = false;

    /// <summary>
    /// Virual method to be overridden.
    /// </summary>
    public virtual void Use ()
    {
        Debug.Log ("Using " + name);
    }

    /// <summary>
    /// Method to remove this particular Item from Inventory.
    /// </summary>
    public void RemoveFromInventory ()
    {
        Inventory.instance.Remove (this);
    }
}
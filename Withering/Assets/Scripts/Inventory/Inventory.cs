using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for handling each Item in the Inventory.
/// Contains methods for adding and removing Items.
/// </summary>
public class Inventory : MonoBehaviour
{
    /// Singleton instance of Inventory.
    public static Inventory instance;
    /// Delegate for when the Item is switched in or out.
    public delegate void onItemChanged ();
    /// 
    public onItemChanged onItemChangedCallBack;
    /// Inventory space.
    public int space = 30;
    /// List of each Item in Inventory.
    public List<Item> items = new List<Item> ();

    /// <summary>
    /// 
    /// </summary>
    void Awake ()
    {
        if (instance != null)
        {
            {
                Destroy (this);
                return;
            }
        }
        instance = this;
        GameObject.DontDestroyOnLoad (this);
    }

    /// <summary>
    /// Add an Item to the Inventory.
    /// </summary>
    /// <param name="item">The item to be added to the inventory.</param>
    public bool Add (Item item)
    {
        if (!item.isDefualtItem)
        {
            if (items.Count >= space)
            {
                Debug.Log ("Not enough room.");
                return false;
            }
            items.Add (item);
            if (onItemChangedCallBack != null)
            {
                onItemChangedCallBack.Invoke ();
            }
        }
        return true;
    }

    /// <summary>
    /// Remove a specific Item in the Inventory.
    /// </summary>
    /// <param name="item">The item to be removed from the inventory.</param>
    public void Remove (Item item)
    {
        items.Remove (item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke ();
        }
    }

    /// <summary>
    /// Remove all items in the Inventory.
    /// </summary>
    public void RemoveAll ()
    {
        items.Clear ();
    }

    /// <summary>
    /// Checks the Inventory if the paramref name="itemToCheck" is there or not.
    /// </summary>
    /// <param name="itemToCheck">The Item to check.</param> 
    public bool isInInventory (Item itemToCheck)
    {
        if (items.Contains (itemToCheck))
        {
            return true;
        }

        return false;

    }
}
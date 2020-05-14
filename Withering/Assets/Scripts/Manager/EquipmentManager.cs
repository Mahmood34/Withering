using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for managing the Equipment of the characters.
/// </summary>
public class EquipmentManager : MonoBehaviour
{
    /// Singleton instance of the EquipmentManager.
    public static EquipmentManager instance;
    /// UI of the Inventory.
    public InventoryUI inventoryUI;
    /// Delegate void for changing equipment.
    public delegate void OnEquipmentChanged (Equipment newItem, Equipment oldItem);
    /// Instance of delegate OnEquipmentChanged.
    public OnEquipmentChanged onEquipmentChanged;
    /// Array of Equipment currently equipped by the Player.
    public Equipment[] currentEquipment;

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

    void Start ()
    {
        int numSlots = System.Enum.GetNames (typeof (EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    /// <summary>
    /// Equip the <paramref name="newItem"/> and remove any current Equipment.
    /// </summary>
    /// <param name="newItem">The new item to be equipped.</param>
    public void Equip (Equipment newItem)
    {
        int slotIndex = (int) newItem.equipmentSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            Inventory.instance.Add (oldItem);
        }
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke (newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        inventoryUI.UpdateStats ();
    }

    /// <summary>
    /// Unequip the Equipment located at the <paramref name="slotIndex"/>.
    /// </summary>
    /// </param name="slotIndex">The index pointing to the equipment slot.</param>
    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            Inventory.instance.Add (oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke (null, oldItem);
            }
        }
        inventoryUI.UpdateStats ();
    }

    /// <summary>
    /// Unequip All Equipment currently equipped.
    /// </summary>
    public void UnequipAll ()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip (i);
        }
        inventoryUI.UpdateStats ();
    }

    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.U))
        {
            UnequipAll ();
        }
        inventoryUI.UpdateStats ();
    }

}
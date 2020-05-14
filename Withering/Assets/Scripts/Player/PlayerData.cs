using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// <summary>
/// Class for handling PlayerData for saving.
/// </summary>
public class PlayerData
{
    /// Trust level of Player to be saved.
    public int trustLevel;
    /// Max health of Player to be saved.
    public float maxHealth;
    /// Health of Player to be saved.
    public float health;
    /// Array of strings with the name of all currently equipped Equipment to be saved.
    public string[] equipment;
    /// Array of strings with the name of all items in the inventory to be saved.
    public string[] inventory;
    /// Index of the current scene to be saved.
    public int sceneIndex;
    /// Position of Player to be saved;
    public float[] position;
    /// Array of flags to be saved.
    public string[] flags;

    /// <summary>
    /// Constructor that takes a <paramref name="player"/> and its details and converts it into a form that can be save using the SaveSystem.
    /// </summary>
    /// <param name="player">The player.</param>
    public PlayerData (Player player)
    {
        position = new float[3];
        flags = FlagManager.instance.flags.ToArray ();
        sceneIndex = GameManager.GetCurrentSceneIndex ();
        trustLevel = PlayerStats.trustLevel;
        maxHealth = player.myStats.maxHealth;
        health = player.myStats.currentHealth;
        position[0] = GameManager.lastSavedSpawnPoint.x;
        position[1] = GameManager.lastSavedSpawnPoint.y;
        position[2] = GameManager.lastSavedSpawnPoint.z;

        List<Item> items = Inventory.instance.items;
        inventory = new string[items.Count];

        for (int i = 0; i < items.Count; i++)
        {
            inventory[i] = items[i].name;
        }

        equipment = new string[4];
        for (int i = 0; i < 4; i++)
        {
            if (EquipmentManager.instance.currentEquipment[i] != null)
                equipment[i] = EquipmentManager.instance.currentEquipment[i].name;
        }

    }

}
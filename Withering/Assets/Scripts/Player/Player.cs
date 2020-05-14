using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for handling the Player.
/// </summary>
[RequireComponent (typeof (PlayerStats))]
public class Player : MonoBehaviour
{
    /// Reference to the PlayerStats attached to the game object.
    public PlayerStats myStats;
    /// Reference to the PlayerController attached to the game object.
    public PlayerController playerController;
    /// Reference to the Inventory.
    public Inventory inventory;
    /// Reference to the EquipmentManager.
    public EquipmentManager equipment;

    /// <summary>
    /// Assigns all components to the Player parent object.
    /// </summary>
    void Start ()
    {
        myStats = GetComponent<PlayerStats> ();
        playerController = GetComponent<PlayerController> ();
        inventory = Inventory.instance;
        equipment = EquipmentManager.instance;
    }

}
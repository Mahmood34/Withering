using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Class for handling the UI of the Inventory.
/// </summary>
public class InventoryUI : MonoBehaviour
{
    /// Reference to container of all the Item slots.
    public Transform itemParent;
    /// Reference to Inventory UI.
    public GameObject inventoryUI;
    /// Reference to the first item slot button.
    public GameObject FirstButton;
    /// Reference to Inventory.
    Inventory inventory;
    /// Reference to UI text that displays the trust level.
    public TextMeshProUGUI trust;
    /// Reference to UI text that displays each Stat.
    public TextMeshProUGUI stats;
    /// Array list of Inventory slots.
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start ()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
        slots = itemParent.GetComponentsInChildren<InventorySlot> ();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.I) && GameManager.instance.inGame && PlayerManager.instance.player.playerController.canMove)
        {
            inventoryUI.SetActive (!inventoryUI.activeSelf);
            if (inventoryUI.activeSelf)
            {
                Time.timeScale = 0;
                trust.SetText ("Trust \t" + PlayerStats.trustLevel);
                UpdateStats ();
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    /// <summary>
    /// Update the stats on the Inventory UI.
    /// </summary>
    public void UpdateStats ()
    {
        stats.SetText ("Attack \t\t" + PlayerManager.instance.player.myStats.Attack.GetValue () +
            "\nDefence \t\t" + PlayerManager.instance.player.myStats.Defence.GetValue () +
            "\nMagic Attack \t" + PlayerManager.instance.player.myStats.MagicAttack.GetValue () +
            "\nMagic Attack \t" + PlayerManager.instance.player.myStats.MagicDefence.GetValue () +
            "\nAgility \t\t" + PlayerManager.instance.player.myStats.Agility.GetValue ()
        );
    }

    /// <summary>
    /// Update the UI when an item changes.
    /// </summary>
    void UpdateUI ()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem (inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot ();
            }
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class containing and managing different Stats.
/// </summary>
public class CharacterStats : MonoBehaviour
{
    /// Maximum health of the character.
    public float maxHealth = 100;
    /// Current health.
    public float currentHealth;
    /// Magical Points.
    public float MP;
    /// Attack Stat.
    public Stat Attack;
    /// Attack Stat.
    public Stat Defence;
    /// Magic attack Stat.
    public Stat MagicAttack;
    /// Magic defence Stat.
    public Stat MagicDefence;
    /// Agility Stat.
    public Stat Agility;
    /// Healthbar.
    public Image healthBar;

    void Awake ()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// The health of the character decreases by <paramref name="attackDamage"/>.
    /// </summary>
    /// <param name="attackDamage">The damage to be removed from the character.</param>
    public void TakeDamage (int attackDamage)
    {
        attackDamage -= Defence.GetValue ();
        attackDamage = Mathf.Clamp (attackDamage, 0, int.MaxValue);
        if (attackDamage < 5)
        {
            attackDamage = 5;
        }
        currentHealth -= attackDamage;
        Debug.Log (transform.name + " takes " + attackDamage + " damage.");
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die ();
        }
    }

    /// <summary>
    /// Base method for when a character dies.
    /// </summary>
    public virtual void Die ()
    {
        Debug.Log (transform.name + " died.");
    }

}
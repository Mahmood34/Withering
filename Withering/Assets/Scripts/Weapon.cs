using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for handling collision detection of weapon and enemy.
/// </summary>
public class Weapon : MonoBehaviour
{
    /// Animator containing animations for the Weapon.
    Animator animator;

    void Start ()
    {
        animator = GetComponent<Animator> ();
    }

    /// <summary>
    /// Method for triggering the animation for attacking.
    /// </summary>
    public void PerformAttack ()
    {
        animator.SetTrigger ("CloseAttack");
    }

    /// <summary>
    /// Method for detecting collision between the Weapon and an Enemy.
    /// </summary>
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy> ().Hit ();
        }
    }
}
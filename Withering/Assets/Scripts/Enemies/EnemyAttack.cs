using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for Handling the Enemy attack.
/// </summary>
public class EnemyAttack : MonoBehaviour
{

    /// <summary>
    /// Detect collision between EnemyAttach and the <paramref name="other"/> object.
    /// </summary>
    /// <param name="other">Object that is detected.</param>
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player> ();
            // player.TakeDamage(2);
            this.GetComponent<Collider> ().enabled = false;
        }

        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy> ().Hit ();
        }

    }

    void OnDrawGizmos ()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color (1, 0, 0, 0.5f);
        Gizmos.DrawCube (transform.position, new Vector3 (1, 1, 1));
    }
}
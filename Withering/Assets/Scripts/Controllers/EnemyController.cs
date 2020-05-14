using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for controlling the enemies movement.
/// Contains methods for updating location and setting destination.
/// </summary>
public class EnemyController : MonoBehaviour
{
    /// Reference to Animator that contains animation for running and attacking.
    public Animator animator;
    /// Stopping distance.
    public float stoppingDistance = 2.0f;
    /// Check for if the Enemy can move.
    public bool canMove;
    /// Target for the Enemy to move towards and attack.
    Transform target;
    /// Reference to CharacterCombat.
    CharacterCombat combat;

    /// <summary>
    /// Sets the Player as the target, gets the combat component and enables movement of the Enemy.
    /// </summary>
    void Start ()
    {
        target = PlayerManager.instance.player.transform;
        combat = GetComponent<CharacterCombat> ();
        canMove = true;
    }

    /// <summary>
    /// Updates the location of the Enemy to follow the Player, stop and attack.
    /// </summary>
    void Update ()
    {
        if (target != null)
        {
            if (!canMove) { return; }

            float distance = Vector3.Distance (target.position, transform.position);
            FaceTarget ();

            if (Vector3.Distance (transform.position, target.transform.position) > stoppingDistance)
            {
                if (transform.position != target.position)
                {
                    transform.position = Vector3.MoveTowards (transform.position, target.position, 4.0f * Time.deltaTime);
                    animator.SetTrigger ("Running");
                }
            }
            else
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats> ();
                if (targetStats != null)
                {
                    combat.Attack (targetStats);
                    animator.SetTrigger ("Attack");
                }
            }
        }
    }

    /// <summary>
    /// Faces the target player.
    /// </summary>
    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
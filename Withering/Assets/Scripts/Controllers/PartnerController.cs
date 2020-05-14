using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This class is responsible for controlling the enemies movement.
/// Contains methods for updating location and setting destination.
/// </summary>
public class PartnerController : MonoBehaviour
{
    /// Reference to Animator that contains animation for running and attacking.
    public Animator animator;
    /// Stopping distance.
    public float stoppingDistance = 2.0f;
    /// Check for if the Enemy can move.
    public bool canMove;
    /// Target for the Enemy to move towards and attack.
    public Transform target;
    /// Agent for navigating around the nav mesh.
    public NavMeshAgent agent;


    // Start is called before the first frame update
    void Start ()
    {
        canMove = true;
        agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Update the partners location and rotation.
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
                    agent.SetDestination(target.position);
                    animator.SetFloat ("Blend", 1.0f , 0.1f, Time.deltaTime);
                }
            }
            else
            {
                animator.SetFloat ("Blend", 0.0f , 0.1f, Time.deltaTime);
            }

        }
    }

    /// <summary>
    /// Face the player.
    /// </summary>
    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

}
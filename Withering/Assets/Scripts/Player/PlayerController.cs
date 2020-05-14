using System.Collections;
using System.Collections.Generic;
using Fluent;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Class for handling Player movement and actions.
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// Reference to NavMeshAgent that controls where the Player can move.
    public NavMeshAgent agent;
    /// Check for if the Player can move.
    public bool canMove;
    /// Interactable the Player is focused on.
    public Interactable focus;
    /// Velocity of the Player.
    public float velocity;
    /// Turnspeed of the Player.
    public float turnSpeed;
    /// Angle of rotation for the Player.
    float angle;
    /// Rotation for the Player to rotate to.
    Quaternion targetRotation;
    /// Ray used for interacting with an Interactable.
    Ray ray;
    /// The duration the Player can dash for.
    float dashtime;
    /// Check for if the Player is dashing.
    bool isDashing;
    /// Check for if dashing is cooling down.
    bool dashIsCooling;
    /// Cooldown time for after dashing.
    float dashCoolDownTime;
    /// Check for if the attack is cooling down.
    bool attackIsCooling;
    /// Cooldown time for after attacking.
    float attackCooldown;
    /// Animator that handles the movement and attack animations.
    public Animator movement;
    /// Reference to Weapon.
    public Weapon sword;
    /// Check for if the Player can encounter monsters.
    public bool canEncounterMonsters;
    /// Check for if the Player is in Battle.
    public bool inBattle;
    /// Check for if the shooting is cooling down.
    bool shootIsCoolingDown;
    /// Spawn point for where the Projectile will shoot from.
    public GameObject projectileSpawnPoint;
    /// Wait time between each Projectile being shot.
    float waitTime;
    /// Reference to Projectile.
    public GameObject projectile;

    /// <summary>
    /// Assigns initial values to PlayerController.
    /// </summary>
    void Start ()
    {
        agent = GetComponent<NavMeshAgent> ();
        velocity = 5.0f;
        turnSpeed = 10.0f;
        dashtime = 0.0f;
        isDashing = false;
        dashCoolDownTime = 0.0f;
        attackIsCooling = false;
        attackCooldown = 0.0f;
        dashIsCooling = false;
        canEncounterMonsters = false;
        inBattle = false;

    }

    /// <summary>
    /// Handles Player movement, attacking and dashing.
    /// </summary>
    void Update ()
    {
        if (!canMove) { return; }
        ray = new Ray (transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawLine (ray.origin, ray.origin + ray.direction * 2, Color.green);
        if (Physics.Raycast (ray, out hit, 2))
        {
            if (Input.GetKeyDown (KeyCode.E))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable> ();
                if (interactable != null)
                {
                    SetFocus (interactable);
                }
            }
        }
        else
        {
            RemoveFocus ();
        }

        if (inBattle)
        {
            if (Input.GetKeyDown (KeyCode.O) && attackIsCooling == false)
            {
                sword.PerformAttack ();
                movement.SetTrigger ("Attack");
                attackIsCooling = true;

            }

            if (attackIsCooling)
            {
                attackCooldown++;
            }

            if (attackCooldown > 30.0f)
            {
                attackIsCooling = false;
                attackCooldown = 0;

            }

            //Dashing
            if (Input.GetKeyDown (KeyCode.Space) && dashIsCooling == false)
            {
                velocity = 20.0f;
                isDashing = true;
            }
            if (isDashing)
            {
                dashtime++;
            }
            if (dashtime > 10.0f)
            {
                isDashing = false;
                velocity = 5.0f;
                dashtime = 0.0f;
                dashIsCooling = true;
            }
            if (dashIsCooling)
            {
                dashCoolDownTime++;
            }
            if (dashCoolDownTime > 20.0f)
            {
                dashIsCooling = false;
                dashCoolDownTime = 0.0f;
            }

            //Shoooting
            if (Input.GetKeyDown (KeyCode.P) && shootIsCoolingDown == false)
            {
                Shoot ();
                shootIsCoolingDown = true;
            }
            if (shootIsCoolingDown)
            {
                waitTime++;
            }
            if (waitTime > 20.0f)
            {
                waitTime = 0;
                shootIsCoolingDown = false;
            }
        }

        if (Input.GetKeyDown (KeyCode.E))
        {
            movement.SetFloat ("Blend", 0.0f);

            FluentManager.Instance.ExecuteClosestAction (gameObject);
        }

        movement.SetFloat ("Blend", Mathf.Abs (Input.GetAxisRaw ("Horizontal")) + Mathf.Abs (Input.GetAxisRaw ("Vertical")), 0.1f, Time.deltaTime);

        if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) < 1.0f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) < 1.0f) return;
        CalculateDirection ();
        Rotate ();
        Move ();
    }

    /// <summary>
    /// Shoot a Projectile in the direction the Player is facing.
    /// </summary>
    void Shoot ()
    {
        Instantiate (projectile.transform, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);
    }

    /// <summary>
    /// Set focus on an Interactable.
    /// </summary>
    /// <param name="newFocus">Interactable to set focus on.</param>
    void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.onDeFocused ();
            }
            focus = newFocus;
        }
        newFocus.OnFocused ();
    }

    /// <summary>
    /// Remove focus of an Interactable.
    /// </summary>
    void RemoveFocus ()
    {
        if (focus != null)
        {
            focus.onDeFocused ();
        }
        focus = null;
    }

    /// <summary>
    /// Calculate the direction using the angle.
    /// </summary>
    void CalculateDirection ()
    {
        angle = Mathf.Atan2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
        angle = Mathf.Rad2Deg * angle;
    }

    /// <summary>
    /// Rotate the Player.
    /// </summary>
    void Rotate ()
    {
        targetRotation = Quaternion.Euler (0, angle, 0);
        transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Move the Player.
    /// </summary>
    void Move ()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
        if (canEncounterMonsters)
        {
            RandomEncounter ();
        }
    }

    /// <summary>
    /// Handles random encounters of enemies.
    /// </summary>
    void RandomEncounter ()
    {
        if (Random.Range (0, 500) < 1)
        {
            canEncounterMonsters = false;
            canMove = false;
            BattleManager.instance.LoadBattle (transform.position);
        }
    }

}
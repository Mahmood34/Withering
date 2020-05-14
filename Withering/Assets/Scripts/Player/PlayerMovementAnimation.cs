using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for hanlding the Player animations.
/// </summary>
public class PlayerMovementAnimation : MonoBehaviour
{
    public Animator animator;
    float inputX;
    float inputZ;

    // Start is called before the first frame update
    void Start ()
    {
        animator = this.gameObject.GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update ()
    {
        inputZ = Input.GetAxisRaw ("Vertical");
        inputX = Input.GetAxisRaw ("Horizontal");
        animator.SetTrigger ("Running");
    }
}
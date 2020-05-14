using UnityEngine;

/*
    Class to handle multiple interactable objects
    Contains methods for focusing and defocusing on objects
*/
/// <summary>
/// Class to handle multiple interactable objects.
/// Contains methods for focusing and defocusing on objects.
/// </summary>
public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    /// Check if Interactable object is being focused by the Player.
    bool isFocus = false;
    /// Reference to the Player.
    Transform player;
    /// Check for it the Player has interacted with the Interactable.
    bool hasInteracted = false;

    /// <summary>
    /// Virtual method for interacting.
    /// This class is meant to be overriden.
    /// </summary>
    public virtual void Interact ()
    {
        Debug.Log ("Interacting with " + transform.name);
    }

    void Update ()
    {
        if (isFocus && !hasInteracted)
        {
            Interact ();
            hasInteracted = true;
        }
    }

    /// <summary>
    /// Method for setting the focus to an object.
    /// </summary>
    public void OnFocused ()
    {
        isFocus = true;
        hasInteracted = false;

    }

    /// <summary>
    /// Method for remove the focus to an object.
    /// </summary>
    public void onDeFocused ()
    {
        isFocus = false;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere (transform.position, radius);
    }

}
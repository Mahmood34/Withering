using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for checking if a particular flag is present in the list of flags in the FlagManager.
/// </summary>
public class FlagCheck : MonoBehaviour
{

    /// Flag associated with the game object.
    public string flag;

    void Start ()
    {
        if (!FlagManager.instance.Checkflag (flag))
        {
            Destroy (gameObject);
            Debug.Log ("Flag checked");
        };
    }

}
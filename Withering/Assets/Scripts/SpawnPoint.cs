using UnityEngine;

/// <summary>
/// SpawnPoint for the player to be warped to.
/// </summary>
public class SpawnPoint : MonoBehaviour
{

    void Start ()
    {
        PlayerManager.instance.WarpPlayer (transform.position);
    }
}
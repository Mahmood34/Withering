using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for projectile behavior.
/// </summary>
public class Projectile : MonoBehaviour
{
    /// Speed of the Projectile
    public float speed;
    /// Distance for when the Projectile should be destroyed.
    public float maxDistance;

    void Update ()
    {
        transform.Translate (Vector3.forward * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 5)
            Destroy (this.gameObject);
    }

    /// <summary>
    /// Method for detecting collision between Projectile and Enemy.
    /// </summary>
    /// <param name="other">Enemy to be attacked.</param>
    public void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy> ().Hit ();
            Destroy (this.gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject playerExplosion;
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        // Don't destroy the boundary
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player") { 
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        // Destroy the object who touch de asteroid
        Destroy(other.gameObject);
        // Destroy the asteroid
        Destroy(gameObject);
    }
}

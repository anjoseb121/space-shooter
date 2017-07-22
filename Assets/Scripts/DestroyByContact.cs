using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        // Destroy the object who touch de asteroid
        Destroy(other.gameObject);
        // Destroy the asteroid
        Destroy(gameObject);
    }
}

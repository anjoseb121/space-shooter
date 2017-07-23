using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject playerExplosion;
    public GameObject explosion;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

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
        gameController.AddScore(scoreValue);
        // Destroy the object who touch de asteroid
        Destroy(other.gameObject);
        // Destroy the asteroid
        Destroy(gameObject);
    }
}

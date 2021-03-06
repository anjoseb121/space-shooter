﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject clone = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate ()
	{
        // Move
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
        Rigidbody rigibody = GetComponent<Rigidbody>();

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigibody.velocity = movement * speed;

        // Clamp the object in screen
        rigibody.position = new Vector3 
        (
            Mathf.Clamp(rigibody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigibody.position.z, boundary.zMin, boundary.zMax)
        );

        // rotate on side move
        rigibody.rotation = Quaternion.Euler(0.0f, 0.0f, rigibody.velocity.x * -tilt);
	}
}

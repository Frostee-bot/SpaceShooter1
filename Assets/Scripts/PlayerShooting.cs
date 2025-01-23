using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject boltPrefab; // Reference to the Bolt prefab
    public Transform firePoint;   // The point where the bolt spawns
    public float fireRate = 0.2f; // Time between shots

    private float nextFireTime = 0f; // Keeps track of the next allowed fire time

    void Update()
    {
        // Check for Space key press and if enough time has passed to fire again
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        {
            Fire();
        }
    }

    void Fire()
    {
        // Set the next fire time
        nextFireTime = Time.time + fireRate;

        // Instantiate the bolt at the fire point's position and rotation
        Instantiate(boltPrefab, firePoint.position, firePoint.rotation);
    }
}

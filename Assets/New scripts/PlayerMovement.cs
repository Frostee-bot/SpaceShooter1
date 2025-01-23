using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary1
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Boundary1 boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    private float originalSpeed;
    private float originalFireRate;

    void Start()
    {
        originalSpeed = speed; //containers
        originalFireRate = fireRate; //containers

    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );
    }

    public void ActivatePowerUp(float duration)
    {
        StartCoroutine(PowerUpRoutine(duration));
    }

    private IEnumerator PowerUpRoutine(float duration)
    {
       
        speed *= 2; 
        fireRate /= 2; 

        yield return new WaitForSeconds(duration);

     
        speed = originalSpeed;
        fireRate = originalFireRate;
    }
}

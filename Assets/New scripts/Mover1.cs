using UnityEngine;

public class Mover1 : MonoBehaviour
{
    public float speed;

    void Start()
    {
        if (CompareTag("Bolt"))
        {
            //Debug.Log("Mover1: Bolt movement initialized.");
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
        else if (CompareTag("Asteroid"))
        {
            //Debug.Log("Mover1: Asteroid movement initialized.");
            GetComponent<Rigidbody>().velocity = Vector3.back * speed;
        }
        else if (CompareTag("PowerUp")) 
        {
            //Debug.Log("Mover1: PowerUp movement initialized.");
            GetComponent<Rigidbody>().velocity = Vector3.back * (speed * 1.5f); 
        }
        else if (CompareTag("EBolt"))
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
    }

    void Update()
    {
        if(CompareTag("EBolt"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.Log($"Ebolt Raycast hit: {hit.collider.tag}");
            }
        }
    }
}


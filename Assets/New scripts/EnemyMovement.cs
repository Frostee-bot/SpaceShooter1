using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;              
    public GameObject eBoltPrefab;        
    public Transform shotSpawn;
    public float fireRate = 2f;

    private AudioSource audioSource;

    private float nextFire; 

    void Start()
    {
        nextFire = Time.time + fireRate;


        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component missing on Enemy prefab.");
        }
    }

    void Update()
    {
        MoveDown();
        FireEBolt();
    }

    void MoveDown()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void FireEBolt()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;


            Instantiate(eBoltPrefab, shotSpawn.position, shotSpawn.rotation);


            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}

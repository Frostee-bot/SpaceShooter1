using UnityEngine;

public class RRotator1 : MonoBehaviour
{
    public float tumble = 1.0f; 

    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            
            rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
        }
        
    }
}

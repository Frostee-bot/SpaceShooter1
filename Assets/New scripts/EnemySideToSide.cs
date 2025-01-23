using UnityEngine;

public class EnemySideToSide : MonoBehaviour
{
    public float dodge = 5f;          
    public float smoothing = 2f;     
    public Vector2 maneuverWait = new Vector2(1f, 2f); 
    public Vector2 boundaryX = new Vector2(-6.8f, 6.8f); 

    private float targetManeuver;    
    private Rigidbody rb;

    void Start()
    {
        
        if (GetComponent<Rigidbody>() == null)
        {
            Debug.LogError("Rigidbody not found on Enemy prefab!");
        }
        StartCoroutine(SideToSideMovement());
    }

    void FixedUpdate()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x, targetManeuver, Time.deltaTime * smoothing);
            GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, GetComponent<Rigidbody>().velocity.z);

            GetComponent<Rigidbody>().position = new Vector3(
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, -6.62f, 6.62f), 
                GetComponent<Rigidbody>().position.y,
                GetComponent<Rigidbody>().position.z
            );
        }
    }

    System.Collections.IEnumerator SideToSideMovement()
    {
        while (true)
        {
            targetManeuver = Random.Range(-dodge, dodge);
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
            targetManeuver = 0; 
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }
}

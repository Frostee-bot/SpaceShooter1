using UnityEngine;

public class DestroyByBoundary1 : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return; 
        }

        
        //Debug.Log(other.gameObject.name + " exited boundary and was destroyed.");

        
        Destroy(other.gameObject);
    }
}

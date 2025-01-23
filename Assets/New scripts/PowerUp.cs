using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float powerUpDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("PowerUp collided with: " + other.gameObject.name);

        if (other.CompareTag("Player")) 
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.ActivatePowerUp(powerUpDuration); 
            }
            Destroy(gameObject); 
        }
    }
}

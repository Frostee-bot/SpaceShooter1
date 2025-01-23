using UnityEngine;

public class DestroyByContact1 : MonoBehaviour
{
    public GameObject explosion;
    public int scoreValue;
    private GameController1 gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController1>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"Collision Detected: {gameObject.tag} hit {other.tag}");

 
        if (other.CompareTag("Boundary1") || other.CompareTag("PowerUp") || other.CompareTag("Enemy") || other.CompareTag("EBolt"))
            return;


        if (other.CompareTag("Bolt"))
        {
            if (gameObject.CompareTag("Asteroid") || gameObject.CompareTag("Enemy"))
            {
                //Debug.Log($"{gameObject.tag} hit by Player Bolt!");


                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                }


                if (gameController != null)
                {
                    gameController.AddScore(scoreValue);
                }


                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }


        if (other.CompareTag("Player"))
        {
            //Debug.Log($"{gameObject.tag} hit Player!");


            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }


            if (gameController != null)
            {
                gameController.GameOver();
            }


            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

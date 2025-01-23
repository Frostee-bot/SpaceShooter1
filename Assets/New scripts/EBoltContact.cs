using UnityEngine;

public class EBoltContact : MonoBehaviour
{
    public GameObject PlyrExplosion;
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
        Debug.Log($"Ebolt collided with: {other.tag}");
        if (other.CompareTag("Player"))
        {
            Debug.Log("EBolt hit Player!");


            if (PlyrExplosion != null)
            {
                Instantiate(PlyrExplosion, other.transform.position, other.transform.rotation);
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

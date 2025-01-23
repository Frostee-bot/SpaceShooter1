using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class HazardSection
{
    public GameObject asteroidPrefab;
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab; 
}

public class GameController1 : MonoBehaviour
{
    public HazardSection hazards;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public float spawnInterval = 2f; 
    public float xValue = 6.5f;
    public float yValue = 0.0f;
    public float zValue = 20.0f;

    private int score;
    private bool isGameOver = false;
    private int asteroidCount = 0; 

    void Start()
    {
        score = 0;
        UpdateScore();
        gameOverText.text = "";
        StartCoroutine(SpawnHazards());
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key detected. Reloading scene.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private IEnumerator SpawnHazards()
    {
        while (!isGameOver)
        {
            
            asteroidCount++;

            
            if (Random.Range(0, 100) < 10) 
            {
                SpawnHazard(hazards.powerUpPrefab);
            }
            else
            {
                
                SpawnHazard(hazards.asteroidPrefab);
            }

            
            if (asteroidCount % Random.Range(5, 8) == 0) 
            {
                SpawnHazard(hazards.enemyPrefab);
            }

            
            if (score % 50 == 0 && score > 0) 
            {
                spawnInterval = Mathf.Max(0.1f, spawnInterval - 0.0002f); 
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnHazard(GameObject hazardPrefab)
    {
        float randomX = Random.Range(-xValue, xValue);
        float randomZ = Random.Range(zValue - 1.0f, zValue + 1.0f);
        Vector3 spawnPosition = new Vector3(randomX, yValue, randomZ);

        Quaternion spawnRotation;

        if (hazardPrefab == hazards.enemyPrefab)
        {
            spawnRotation = Quaternion.Euler(0, 180, 0); 
        }
        else
        {
            spawnRotation = Quaternion.identity; 
        }

        Instantiate(hazardPrefab, spawnPosition, spawnRotation);
    }

    public void AddScore(int scoreValue)
    {
        if (!isGameOver)
        {
            score += scoreValue;
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.text = "Game Over\nPress R to Restart";
        Debug.Log("GameOver triggered.");
        StopAllCoroutines();
    }
}

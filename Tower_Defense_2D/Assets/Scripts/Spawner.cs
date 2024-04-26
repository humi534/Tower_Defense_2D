using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn
    public Vector3[] spawnPoints; // Array of spawn points where enemies can spawn
    public float spawnInterval = 2f; // Interval between enemy spawns
    public int maxEnemies = 5; // Maximum number of enemies that can be spawned

    private int currentEnemies = 0; // Current number of enemies spawned
    private float lastSpawnTime; // Time when the last enemy was spawned

    void Update()
    {
        // Check if we can spawn more enemies
        if (currentEnemies < maxEnemies && Time.time - lastSpawnTime > spawnInterval)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Randomly select a spawn point index
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        
        // Get the position of the selected spawn point
        Vector3 spawnPosition = transform.position + spawnPoints[spawnIndex]; // Adjust for spawner's position

        // Instantiate the enemy at the spawn position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Update spawn variables
        currentEnemies++;
        lastSpawnTime = Time.time;
    }
}

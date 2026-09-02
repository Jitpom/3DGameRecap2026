using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints; // Array of spawn point GameObjects to choose from
    public GameObject enemyPrefab; // Prefab of the enemy to spawn
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start the enemy spawning coroutine
        StartCoroutine(SpawnEnemy());        
    }

    IEnumerator SpawnEnemy()
    {
        int spawnID = Random.Range(0, spawnPoints.Length); // Randomly select a spawn point index
        Debug.Log("Spawning enemy at spawn point: " + spawnID);
        
        yield return new WaitForSeconds(2f); // Wait for 2 seconds before spawning the enemy        
        StartCoroutine(SpawnEnemy()); // Recursively call SpawnEnemy to continue spawning enemies
    }
}

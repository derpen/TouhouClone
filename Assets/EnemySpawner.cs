using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    private float spawnInterval = 9f;
    private float cameraHeight;
    private float cameraWidth;
    private float randomX;

    // Start is called before the first frame update
    void Start()
    {
        // Get the camera dimensions
        cameraHeight = 2f * Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;

        // Remember to stop the coroutine when you no longer need to spawn enemies, for example in the OnDisable or OnDestroy function.
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnEnemy()
    {
        // yield return new WaitForSeconds(spawnInterval);
        while (true)
        {
            // Choose a random X position within the screen bounds
            randomX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);

            // Set a random x position for the enemy to spawn at
            Vector2 spawnPosition = new Vector2(randomX, cameraHeight / 2f);

            // Instantiate the enemy prefab at the spawn position
            Instantiate(enemy, spawnPosition, Quaternion.identity);

            // Wait for the specified interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

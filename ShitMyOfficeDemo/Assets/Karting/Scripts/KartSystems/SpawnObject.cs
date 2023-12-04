using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    public GameObject SpawnPrefab; // Assign your apple Prefab in the Inspector
    public string playerTag = "Player";
    public int numberOfApples = 20;
    public Transform spawnPoint;

    private bool hasSpawnedApples = false;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Player"
        if (collision.gameObject.CompareTag(playerTag) && !hasSpawnedApples)
        {
            // Spawn apples
            SpawnApples();
            hasSpawnedApples = true; // To avoid spawning apples continuously
        }
    }

    void SpawnApples()
    {
        if (spawnPoint != null)
        {
            for (int i = 0; i < numberOfApples; i++)
            {
                // Use the assigned spawn point's position for spawning apples
                Vector3 spawnPosition = spawnPoint.position;
                Instantiate(SpawnPrefab, spawnPosition, Quaternion.identity);
            }
        }
        else
        {
            Debug.LogError("Spawn point not assigned!");
        }
    }
}

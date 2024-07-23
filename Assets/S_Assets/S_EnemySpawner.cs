using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemySpawner : MonoBehaviour
{
    public float spawnRadius = 5;
    public float timeBetweenSpawn = 1;
    public float timeTilSpawn = 0;

    public GameObject enemyPrefab;

    void Update()
    {
        timeTilSpawn -= Time.deltaTime;

        if (timeTilSpawn <= 0)
        {
            // spawn
            Spawn();
            timeTilSpawn = timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        Vector2 randDir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = randDir * spawnRadius;
        Instantiate(enemyPrefab, gameObject.transform.position + (Vector3)spawnPos, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, spawnRadius);
    }
}

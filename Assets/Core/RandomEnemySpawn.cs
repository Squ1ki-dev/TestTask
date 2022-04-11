using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawn : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;

    private void Start() => SpawnEnemy();

    private void SpawnEnemy()
    {
        int countSpawned = 0;
        int randEnemy = Random.Range(0, enemies.Length);
        int randSpawnPos = Random.Range(0, spawnPoints.Length);

        for (int i = countSpawned; i < enemyManager.countEnemyes; i++)
        {
            Instantiate(enemies[randEnemy], spawnPoints[randSpawnPos].transform.position, Quaternion.identity);

            if(countSpawned >= enemyManager.countEnemyes)
                break;
            else
                continue;
        }
    }
}

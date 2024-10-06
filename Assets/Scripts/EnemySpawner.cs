using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField] 
    private GameObject largeEnemy;

    //Spawn Small Enemy Every Second & Large Enemy Every 10 Seconds
    [SerializeField]
    private float enemySpawnTime = 1.0f;
    [SerializeField]
    private float largeEnemySpawnTime = 10.0f;

    public int currentEnemies = 0;
    private int maxEnemies = 10;

    private void Update()
    {
        if(enemySpawnTime > 0)
        {
            enemySpawnTime -= Time.deltaTime * 1.0f;
        }
        else if(enemySpawnTime <= 0 && currentEnemies <= maxEnemies)
        {
            Instantiate(enemy, new Vector3(Random.Range(-10, 20), Random.Range(-20, 10), 0), Quaternion.identity);
            currentEnemies++;
            enemySpawnTime = 1.0f;
        }

        if (largeEnemySpawnTime > 0)
        {
            largeEnemySpawnTime -= Time.deltaTime * 1.0f;
        }
        else if (largeEnemySpawnTime <= 0 && currentEnemies <= maxEnemies)
        {
            Instantiate(largeEnemy, new Vector3(Random.Range(-10, 20), Random.Range(-20, 10), 0), Quaternion.identity);
            currentEnemies++;
            largeEnemySpawnTime = 10.0f;
        }

    }

}


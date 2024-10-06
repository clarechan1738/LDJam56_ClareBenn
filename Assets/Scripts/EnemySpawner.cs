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

    private void Start()
    {
        //Starts Spawning The Enemies
        StartCoroutine(spawnEnemies(enemySpawnTime, enemy));
        StartCoroutine(spawnEnemies(largeEnemySpawnTime, largeEnemy));
    }

    private IEnumerator spawnEnemies(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        //Instantiates An Enemy At A Pseudo Random Location
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10, 20), Random.Range(-20, 10), 0), Quaternion.identity);

        //Starts The Spawn Cycle Again
        StartCoroutine(spawnEnemies(enemySpawnTime, enemy));

    }

}


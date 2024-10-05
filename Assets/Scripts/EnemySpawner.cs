using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float enemySpawnTime = 1.0f;

    private int currEnemies = 0;
    private int maxEnemies = 10;

    private void Start()
    {
        StartCoroutine(spawnEnemies(enemySpawnTime, enemy));
    }

    private IEnumerator spawnEnemies(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if(currEnemies < maxEnemies)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10, 20), Random.Range(-20, 10), 0), Quaternion.identity);
            currEnemies++;
        }
        if(currEnemies >= 10)
        {
            maxEnemies = 10;
            currEnemies = 0;       
        }

        StartCoroutine(spawnEnemies(enemySpawnTime, enemy));

    }

}


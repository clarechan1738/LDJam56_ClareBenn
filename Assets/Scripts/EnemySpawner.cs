using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float enemySpawnTime = 1.0f;

    private void Start()
    {
        StartCoroutine(spawnEnemies(enemySpawnTime, enemy));
    }

    private IEnumerator spawnEnemies(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10, 20), Random.Range(-20, 10), 0), Quaternion.identity);
        StartCoroutine(spawnEnemies(enemySpawnTime, enemy));

    }

}


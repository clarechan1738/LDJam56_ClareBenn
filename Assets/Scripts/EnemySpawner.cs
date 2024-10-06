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
        //Starts Spawning The Enemies
        StartCoroutine(spawnEnemies(enemySpawnTime, enemy));
    }

    private IEnumerator spawnEnemies(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if(currEnemies < maxEnemies)
        {
            //Instantiates An Enemy At A Pseudo Random Location
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10, 20), Random.Range(-20, 10), 0), Quaternion.identity);
            currEnemies++;
        }
        //If There Is Less Than 10 Current Enemies Active, Resets The Maximum & Current Enemies To Allow More To Spawn
        if(currEnemies >= 10)
        {
            maxEnemies = 10;
            currEnemies = 0;       
        }

        //Starts The Spawn Cycle Again
        StartCoroutine(spawnEnemies(enemySpawnTime, enemy));

    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;

    public Vector3 spawnReferencePosition;
    public int amountEnemies;
    public float timeCadence;
    public float initialWaitTime;

    private void Start()
    {
        StartCoroutine(EnemySpawnerCoroutine());
    }

    private IEnumerator EnemySpawnerCoroutine()
    {
        yield return new WaitForSeconds(initialWaitTime);
        for (int i = 0; i < amountEnemies; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-spawnReferencePosition.x, spawnReferencePosition.x), spawnReferencePosition.y, spawnReferencePosition.z);
            SpawnEnemy(randomPosition);
            yield return new WaitForSeconds(timeCadence);
        }
    }

    public void SpawnEnemy(Vector3 enemyPosition)
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        Instantiate(enemyPrefabs[randomIndex], enemyPosition, Quaternion.identity);
    }
}
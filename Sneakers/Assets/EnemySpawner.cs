using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform spawnArea; 
    public float minSpawnTime = 1f; 
    public float maxSpawnTime = 20f; 
    public int maxEnemies = 4; //Most enemies that can be active at a time

    private int currentEnemies = 0; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (currentEnemies < maxEnemies)
            {
                float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                yield return new WaitForSeconds(spawnTime);

                if (currentEnemies < maxEnemies)
                {
                    SpawnEnemy();
                }
            }
            yield return null;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.GetComponent<enemy>().SetSpawner(this);
        currentEnemies++;
    }

    public void EnemyDied()
    {
        currentEnemies--;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector2 spawnSize = spawnArea.localScale;
        Vector2 spawnCenter = spawnArea.position;
        float spawnX = Random.Range(spawnCenter.x - spawnSize.x / 2f, spawnCenter.x + spawnSize.x / 2f);
        float spawnY = Random.Range(spawnCenter.y - spawnSize.y / 2f, spawnCenter.y + spawnSize.y / 2f);
        return new Vector3(spawnX, spawnY, spawnArea.position.z);
    }

    //please for the love of god just work i beg you
}

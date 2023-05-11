using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private EnemySpawner spawner; // Reference to the enemy spawner

    public void SetSpawner(EnemySpawner enemySpawner)
    {
        spawner = enemySpawner;
    }

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.EnemyDied();
        }
    }
}

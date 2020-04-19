using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemySystem : MonoBehaviour
{
    public EnemyData enemyData;

    public Transform enemySpawnPos;

    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        // Creates an instance of the prefab at the current spawn point.
        GameObject currentEnemy = Instantiate(enemyData.EnemyGO, enemySpawnPos.position, Quaternion.identity);

        // Sets the name of the instantiated entity to be the string defined in the ScriptableObject and then appends it with a unique number. 
        currentEnemy.name = enemyData.EnemyName;

        currentEnemy.AddComponent<EnemyUnit>();
    }
}


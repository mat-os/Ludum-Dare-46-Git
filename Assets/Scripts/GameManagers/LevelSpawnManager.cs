using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnManager : MonoBehaviour
{
    public LevelData[] levels;

    public SpawnEnemyOnStageSystem spawnEnemySys;
    
    private int levelNow;
    private int stageNow;
    private int stagesOverall;

    void Start()
    {
        stagesOverall = levels[0].StagesOnLevel;
    }

    public void SpawnEnemies()
    {
        InitLevel(levelNow);
    }
    
    private void InitLevel(int level)
    {
        stagesOverall = levels[level].StagesOnLevel;

        if (stageNow < stagesOverall)
        {
            spawnEnemySys.SpawnEnemy(levels[level].ShuffledStages[stageNow].EnemyType,
                levels[level].ShuffledStages[stageNow].EnemiesToSpawn);

            stageNow++;
        }
    }

    public bool isLevelEnd()
    {
        if (stageNow == stagesOverall)
        {
            levelNow++;
            stageNow = 0;

            Debug.Log("levelEND! " + levelNow);

            return true;
        }
        else
        {
            return false;
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnManager : MonoBehaviour
{
    public LevelData level1;
    public LevelData level2;
    public LevelData level3;
    public LevelData level4;
    public LevelData level5;

    public SpawnEnemyOnStageSystem spawnEnemySys;

    private int levelNow;
    private int stageNow = 0;
    private int stagesOverall;

    public void SpawnEnemies()
    {
        InitLevel(levelNow);

        Debug.Log("SSSPPPPWWWAAANN ENEMY");
    }
    
    private void InitLevel(int level)
    {
        stagesOverall = level1.StagesOnLevel.Length;

        Debug.Log(stagesOverall + " Stages on level");

        if (stageNow < stagesOverall)
        {
            Debug.Log(stageNow + " Stage Now");

            spawnEnemySys.SpawnEnemy(level1.StagesOnLevel[stageNow].EnemyType,
                level1.StagesOnLevel[stageNow].EnemiesToSpawn);

            Debug.Log(level1.StagesOnLevel[stageNow].EnemiesToSpawn + " Enemy To Spawn Now");

            stageNow++;
        }
    }
}

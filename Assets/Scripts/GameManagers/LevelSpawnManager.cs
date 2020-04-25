using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnManager : MonoBehaviour
{
    public LevelData[] levels;

    public SpawnEnemyOnStageSystem spawnEnemySys;

    public GameObject EndGameUI;

    private int levelNow;
    private int stageNow;
    private int stagesOverall;

    void Start()
    {
        stagesOverall = levels[1].StagesOnLevel.Length;
    }

    public void SpawnEnemies()
    {
        InitLevel(levelNow);
    }
    
    private void InitLevel(int level)
    {
        stagesOverall = levels[level].StagesOnLevel.Length;

        if (stageNow < stagesOverall)
        {
            spawnEnemySys.SpawnEnemy(levels[level].StagesOnLevel[stageNow].EnemyType,
                levels[level].StagesOnLevel[stageNow].EnemiesToSpawn);

            stageNow++;
        }
    }

    public bool isLevelEnd()
    {
        if (stageNow == stagesOverall)
        {
            levelNow++;
            stageNow = 0;

            if (levelNow == 2)
            {
                EndGameUI.SetActive(true);
            }
            Debug.Log("levelEND! " + levelNow);

            return true;
        }
        else
        {
            return false;
        }
    }
}

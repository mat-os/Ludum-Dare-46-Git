using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnManager : MonoBehaviour
{
    public LevelData[] levels;

    [SerializeField]
    private SpecialStageData AltarStage;

    public SpawnEnemyOnStageSystem spawnEnemySys;
    public SpawnSpecialRoom spawnSpecialRoom;

    private List<StageData> shuffledStages = new List<StageData>();

    private int levelNow;
    private int stageNow;
    private int stagesTotal = 3;

    private int specialRoomsTotal;
    private int specialRoomsNow;
    private bool isSpecialRoomsSpawn;

    private bool isNewRoomWithEnemy;
    public bool IsNewRoomWithEnemy()
    {
        return isNewRoomWithEnemy;
    }

    public void SpawnNewStage()
    {
        if (stageNow == 0)
        {
            StartNewLevel(levelNow);

            SpawnNewRoom();
        }
        else if(stageNow < stagesTotal)
        {
            SpawnNewRoom();
        }
    }
    
    private void StartNewLevel(int _levelNow)
    {
        //Перемешиваем уровни и убираем лишние
        stagesTotal = levels[_levelNow].StagesWithEnemyOnLevel;

        shuffledStages = levels[_levelNow].PossibleStages;

        RandomizeArray(shuffledStages);

        shuffledStages.RemoveRange(stagesTotal, shuffledStages.Count - stagesTotal);

        //TODO: Почему-то удаляются возможные этапы из списка уровня, а не только из перемешанного списка


        //Устанавливаем спец. уровни
        specialRoomsTotal = levels[levelNow].SpecialStagesOnLevel;
    }

    private void SpawnNewRoom()
    {
        if (specialRoomsNow != specialRoomsTotal)
        {
            if (stageNow > 1 && stageNow < stagesTotal - 1 && Random.value > 0)
            {
                spawnSpecialRoom.SpawnRoom(levels[levelNow].PossibleSpectialStages[0]);

                isNewRoomWithEnemy = false;
            }
            else
            {
                SpawnEnemyRoom();
            }
        }
        else
        {
            SpawnEnemyRoom();
        }
    }

    private void SpawnEnemyRoom()
    {
        spawnEnemySys.SpawnEnemy(shuffledStages[stageNow].EnemyType,
            shuffledStages[stageNow].EnemiesToSpawn);

        stageNow++;

        isNewRoomWithEnemy = true;
    }

    public bool isLevelEnd()
    {
        if (stageNow == stagesTotal)
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

    public static void RandomizeArray<T>(List<T> array)
    {
        int size = array.Count;
        for (int i = 0; i < size; i++)
        {
            int indexToSwap = Random.Range(i, size);
            T swapValue = array[i];
            array[i] = array[indexToSwap];
            array[indexToSwap] = swapValue;
        }
    }
}


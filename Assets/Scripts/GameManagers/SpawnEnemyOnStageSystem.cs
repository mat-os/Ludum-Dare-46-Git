using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyOnStageSystem : MonoBehaviour
{
    //Позиции, в которых спавнятся монстры
    public Transform enemySpawnPosCenter;

    public Transform enemySpawnPosMidleft;
    public Transform enemySpawnPosMidRight;

    public float distanceForUpAndDown;

    private List<Vector3>positionList = new List<Vector3>();

    public void SpawnEnemy(EnemyData enemyData, int howMuchToSpawn)
    {
        for (int i = 0; i < howMuchToSpawn; i++)
        {
            GameObject currentEnemy = Instantiate(enemyData.EnemyGO, ChooseSpawnPos(howMuchToSpawn)[i], Quaternion.identity);

            currentEnemy.name = enemyData.EnemyName;

            UnitInit(currentEnemy.GetComponent<Entity>(), enemyData.MinAttackDamage, enemyData.MaxAttackDamage, enemyData.AttackRate, enemyData.HPAmount);
            
            GameInstance.Instance.EntitiesControler.enemiesList.Add(currentEnemy); 
        }
    }

    private List<Vector3> ChooseSpawnPos(int howMuchToSpawn)
    {
        positionList.Clear();

        switch (howMuchToSpawn)
        {
            case 1:
                positionList.Add(enemySpawnPosCenter.position);
                break;

            case 2:
                positionList.Add(enemySpawnPosMidleft.position);
                positionList.Add(enemySpawnPosMidRight.position);

                break;

            case 4:
                positionList.Add( enemySpawnPosMidleft.position + Vector3.up * distanceForUpAndDown);
                positionList.Add(enemySpawnPosMidRight.position + Vector3.up * distanceForUpAndDown);
                positionList.Add(enemySpawnPosMidleft.position + Vector3.down * distanceForUpAndDown);
                positionList.Add(enemySpawnPosMidRight.position + Vector3.down * distanceForUpAndDown);

                break;
        }

        return positionList;
    }

    private void UnitInit(Entity entity, float minDmg, float maxDmg, float AR, float HP)
    {
        entity.SetDamageMin(minDmg);
        entity.SetDamageMax(maxDmg);
        entity.SetAttackRate(AR);
        entity.SetHPmax(HP);
    }
}


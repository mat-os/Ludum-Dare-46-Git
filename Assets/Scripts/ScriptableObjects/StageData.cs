using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StageData", menuName = "Stage Data", order = 51)]
public class StageData : ScriptableObject
{
    [SerializeField]
    private int enemiesToSpawn;
    [SerializeField]
    private EnemyData enemyType;

    public int EnemiesToSpawn
    {
        get
        {
            return enemiesToSpawn;
        }
    }

    public EnemyData EnemyType
    {
        get
        {
            return enemyType;
        }
    }
}

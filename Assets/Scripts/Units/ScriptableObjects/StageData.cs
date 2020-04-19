using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StageData", menuName = "Stage Data", order = 51)]
public class StageData : ScriptableObject
{
    [SerializeField]
    private int EnemyToSpawn;
    [SerializeField]
    private EnemyData EnemyType;
}

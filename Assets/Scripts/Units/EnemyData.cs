using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 51)]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private GameObject enemyGO;
    [SerializeField]
    private string enemyName;
    [SerializeField]
    private string description;
    [SerializeField]
    private int HP;
    [SerializeField]
    private int attackDamage;

    public GameObject EnemyGO
    {
        get
        {
            return enemyGO;
        }
    }
    public string EnemyName
    {
        get
        {
            return enemyName;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
    }

    public int HPAmount
    {
        get
        {
            return HP;
        }
    }

    public int AttackDamage
    {
        get
        {
            return attackDamage;
        }
    }
}

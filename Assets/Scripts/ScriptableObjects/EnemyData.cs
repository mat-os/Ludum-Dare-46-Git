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
    private float HP;
    [SerializeField]
    private float minAttackDamage;
    [SerializeField]
    private float maxAttackDamage;
    [SerializeField]
    private float attackRate;

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

    public float HPAmount
    {
        get
        {
            return HP;
        }
    }

    public float MinAttackDamage
    {
        get
        {
            return minAttackDamage;
        }
    }

    public float MaxAttackDamage
    {
        get
        {
            return maxAttackDamage;
        }
    }
    public float AttackRate
    {
        get
        {
            return attackRate;
        }
    }
}

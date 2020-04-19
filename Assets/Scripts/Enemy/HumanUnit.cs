using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanUnit : Unit
{
    private Unit thisUnit;

    private EnemyUnit TargetToHit;

    void Awake()
    {
        thisUnit = new Unit();

        //TargetToHit = FindObjectOfType<EnemyUnit>();
    }

    void Start()
    {

    }

    public Unit GetUnit()
    {
        return thisUnit;
    }
}

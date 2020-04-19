using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    private Unit TargetToHit;

    private Unit thisUnit;

    private bool isInitAttack;

    void Awake()
    {
        //thisUnit = gameObject.AddComponent<Unit>();
        thisUnit = new Unit();

    }

    //void Update()
    //{
    //    if(TargetToHit == null)
    //    {
    //        TargetToHit = FindObjectOfType<HumanUnit>().GetComponent<Unit>();

    //        Debug.Log("Target " + TargetToHit.name);
    //    }
    //    else
    //    {
    //        if (thisUnit.GetDMGSystem() == null)
    //        {
    //            Debug.Log("AAAAAAA");
    //        }

    //        else if(!isInitAttack)
    //        {
    //            Attack(TargetToHit);

    //            isInitAttack = true;
    //        }
    //    }
    //}
}

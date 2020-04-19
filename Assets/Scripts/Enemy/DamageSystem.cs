using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private float damage = 10;
    private float attackRate = 1;

    void Start()
    {
        Debug.Log("DamageSystemInit");
    }

    //public void DealDamage(Unit targetToAttack)
    //{
    //    StartCoroutine(AttackRoutine(targetToAttack, damage, attackRate));
    //}

    //IEnumerator AttackRoutine(Unit targetToAttack, float _damage, float _attackRate)
    //{
    //    if (targetToAttack == null)
    //    {
    //        Debug.Log("NO Unit");
    //    }
    //    else
    //    {
    //        while (targetToAttack.GetHPsystem().GetHPAmount() > 0)
    //        {
    //            yield return new WaitForSeconds(_attackRate);

    //            targetToAttack.GetDamage(_damage);
    //        }

    //        Debug.Log("Target killed!");
    //    }

    //}

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }
    public void SetAttackRate(float _attackRate)
    {
        attackRate = _attackRate;
    }
}

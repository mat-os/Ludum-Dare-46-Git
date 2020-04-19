using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private float damage;
    private float attackRate;

    void Start()
    {
        if (gameObject.GetComponent<Human>() != null)
        {

        }
        else if (gameObject.GetComponent<Enemy>() != null)
        {

        }

        Debug.Log("DamageSystemInit");
    }

    public void HitTarget(Human target)
    {
        StartCoroutine(AttackHuman(target, damage, attackRate));
    }

    public void HitTarget(Enemy target)
    {
        StartCoroutine(AttackEnemy(target, damage, attackRate));
    }

    IEnumerator AttackHuman(Human target, float _damage, float _attackRate)
    {
        while (target.GetComponent<HPSysytem>().GetHPAmount() > 0)
        {
            target.TakeDamage(_damage);

            Debug.Log("Attack!");

            yield return new WaitForSeconds(attackRate);
        }

        yield  return null;
    }

    IEnumerator AttackEnemy(Enemy target, float _damage, float _attackRate)
    {
        while (target.GetComponent<HPSysytem>().GetHPAmount() > 0)
        {
            target.TakeDamage(_damage);

            Debug.Log("Attack!");

            yield return new WaitForSeconds(attackRate);
        }

        yield return null;
    }

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }
    public void SetAttackRate(float _attackRate)
    {
        attackRate = _attackRate;
    }
}

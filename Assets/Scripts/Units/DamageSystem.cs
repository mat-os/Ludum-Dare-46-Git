using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private float damageMin;
    private float damageMax;
    private float attackRate;

    private AnimationController animationController;

    void Start()
    {
        if (gameObject.GetComponent<AnimationController>() != null)
        {
            animationController = GetComponent<AnimationController>();
        }
    }

    private float RandomizeDamage()
    {
        return Random.Range(damageMin, damageMax);
    }

    public void HitTarget(Human target)
    {
        StartCoroutine(AttackHuman(target, RandomizeDamage(), attackRate));
    }

    public void HitTarget(Enemy target)
    {
        StartCoroutine(AttackEnemy(target, RandomizeDamage(), attackRate));
    }

    IEnumerator AttackHuman(Human target, float _damage, float _attackRate)
    {
        while (target.GetComponent<HPSysytem>().GetHPAmount() > 0)
        {
            yield return new WaitForSeconds(attackRate);

            target.TakeDamage(_damage);
        }

        yield  return null;
    }

    IEnumerator AttackEnemy(Enemy target, float _damage, float _attackRate)
    {
        if (target.GetComponent<HPSysytem>().GetHPAmount() <= 0)
        {
            gameObject.GetComponent<Human>().KillEnemy(target);
            yield return null;
        }
        else
        {
            while (target.GetComponent<HPSysytem>().GetHPAmount() > 0)
            {
                target.TakeDamage(_damage);

                PlayAnimation();

                Debug.Log("AttacCKKCKCKCK");

                yield return new WaitForSeconds(attackRate);
            }
        }
    }

    public void SetDamage(float _minDamage, float _maxDamage)
    {
        damageMin = _minDamage;
        damageMax = _maxDamage;
    }
    public void SetAttackRate(float _attackRate)
    {
        attackRate = _attackRate;
    }

    private void PlayAnimation()
    {
        if (animationController != null)
        {
            animationController.AttackAnimation();
        }
    }

}

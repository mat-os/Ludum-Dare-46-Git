using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private float damageMin;
    private float damageMax;
    private float attackRate;

    private AnimationController animationController;
    private EnemyAnimController enemyAnimController;

    void Start()
    {
        if (gameObject.GetComponent<AnimationController>() != null)
        {
            animationController = GetComponent<AnimationController>();
        }

        if (gameObject.GetComponent<EnemyAnimController>() != null)
        {
            enemyAnimController = GetComponent<EnemyAnimController>();
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
        yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));

        while (target.GetComponent<HPSysytem>().GetHPAmount() > 0)
        {
            yield return new WaitForSeconds(_attackRate);

            target.TakeDamage(_damage);

            enemyAnimController.AttackAnimation();
        }

        yield  return null;
    }

    IEnumerator AttackEnemy(Enemy target, float _damage, float _attackRate)
    {
        while (target.isAlive == true)
        {
            target.TakeDamage(_damage);

            PlayAnimation();

            yield return new WaitForSeconds(_attackRate);
        }

        gameObject.GetComponent<Human>().KillEnemy(target);

        yield return null;
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

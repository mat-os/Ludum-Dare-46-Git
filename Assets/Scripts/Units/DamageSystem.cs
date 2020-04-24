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
    private void PlayAnimation()
    {
        if (animationController != null)
        {
            animationController.AttackAnimation();
        }
    }

    private float RandomizeDamage()
    {
        return Random.Range(damageMin, damageMax);
    }

    public void HitTarget(Entity target)
    {
        StartCoroutine(AttackEntity(target));
    }

    IEnumerator AttackEntity(Entity target)
    {
        if (target is Enemy)
        {
            while (target.GetIsAlive() == true)
            {
                yield return new WaitForSeconds(attackRate);

                target.TakeDamage(RandomizeDamage());

                PlayAnimation();
            }

            gameObject.GetComponent<Human>().KillEnemy(target.GetComponent<Enemy>());

            yield return null;
        }

        else if (target is Human)
        {
            Debug.Log("Hit Human");

            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

            while (target.GetIsAlive() == true)
            {
                yield return new WaitForSeconds(attackRate);

                target.TakeDamage(RandomizeDamage());

                enemyAnimController.AttackAnimation();
            }

            yield return null;
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



}

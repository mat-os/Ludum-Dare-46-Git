using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField]
    private StatusEffectData specialEffect;

    private AnimationController animationController;
    private EnemyAnimController enemyAnimController;

    private Entity thisEntity;
    
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

        thisEntity = gameObject.GetComponent<Entity>();
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
        return Random.Range(thisEntity.GetDamageMin(), thisEntity.GetDamageMax());
    }

    public void HitTarget(Entity target)
    {
        StopAllCoroutines();
        StartCoroutine(AttackEntity(target));
    }

    IEnumerator AttackEntity(Entity target)
    {
        if (target is Enemy)
        {
            while (target.GetIsAlive() == true)
            {
                yield return new WaitForSeconds(thisEntity.GetAttackRate());

                var dmg = RandomizeDamage();

                target.GetComponent<Enemy>().TakeDamage(dmg);

                PlayAnimation();

                UseSpecialAbility(target);

                TextPopup.CreateDamagePopup(target.transform.position, dmg);
            }

            gameObject.GetComponent<Human>().KillEnemy(target.GetComponent<Enemy>());

            yield return null;
        }

        else if (target is Human)
        {
            yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));

            while (target.GetIsAlive() == true)
            {
                yield return new WaitForSeconds(thisEntity.GetAttackRate());

                var dmg = RandomizeDamage();

                UseSpecialAbility(target);

                target.GetComponent<Human>().TakeDamage(dmg);

                enemyAnimController.AttackAnimation();

                //TextPopup.CreateDamagePopup(target.transform.position, dmg);
            }

            yield return null;
        }
    }

    void UseSpecialAbility(Entity target)
    {
        if (specialEffect != null)
        {
            if (specialEffect.ChanceOfEffect > Random.Range(0, 100))
            {
                target.GetComponent<StatusEffectsManager>().AddEffect(specialEffect, specialEffect.TimeOfEffect);
            }
        }
    }
}

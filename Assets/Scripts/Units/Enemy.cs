using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : Entity, IDamagable, IHittable
{
    private HPSysytem hpSysytem;
    private DamageSystem damageSystem;

    private EnemyAnimController enemyAnim;

    private List<Human> enemies = new List<Human>();

    IDamagable damageable;
    IHittable hittable;

    public override void Initialisation(float _minDamage, float _maxDamage, float _attackRate, float _HPMax)
    {
        hpSysytem = GetComponent<HPSysytem>();
        damageSystem = GetComponent<DamageSystem>();

        damageSystem.SetDamage(_minDamage, _maxDamage);
        damageSystem.SetAttackRate(_attackRate);

        hpSysytem.SetMaxHP(_HPMax);
    }

    void Start()
    {
        enemyAnim = gameObject.GetComponent<EnemyAnimController>();

        var ss = FindObjectsOfType<MonoBehaviour>().OfType<Human>();
        foreach (Human s in ss)
        {
            enemies.Add(s);
        }

        HitEntity();
    }

    public override void TakeDamage(float damageTaken)
    {
        hpSysytem.TakeDamage(damageTaken);

        if (hpSysytem.GetHPAmount() <= 0)
        {
            Dead();
        }
    }

    public void HitEntity()
    {
        damageSystem.HitTarget(enemies[Random.Range(0, enemies.Count)]);
    }

    public override void Dead()
    {
        enemyAnim.DeadAnim();

        SetIsAlive(false);

        //Destroy(this);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}

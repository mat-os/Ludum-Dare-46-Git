using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable, IHittable
{
    private HPSysytem hpSysytem;
    private DamageSystem damageSystem;

    private List<Human> enemies = new List<Human>();

    IDamagable damageable;
    IHittable hittable;

    public void Initialisation(float _minDamage, float _maxDamage, float _attackRate, float _HPMax)
    {
        hpSysytem = GetComponent<HPSysytem>();
        damageSystem = GetComponent<DamageSystem>();

        damageSystem.SetDamage(_minDamage, _maxDamage);
        damageSystem.SetAttackRate(_attackRate);

        hpSysytem.SetMaxHP(_HPMax);
    }

    void Start()
    {
        var ss = FindObjectsOfType<MonoBehaviour>().OfType<Human>();
        foreach (Human s in ss)
        {
            enemies.Add(s);
        }

        Hit();
    }

    public void TakeDamage(float damageTaken)
    {
        hpSysytem.TakeDamage(damageTaken);

        if (hpSysytem.GetHPAmount() <= 0)
        {
            EnemyDead();
        }
    }

    public void Hit()
    {
        damageSystem.HitTarget(enemies[Random.Range(0, enemies.Count)]);
    }

    private void EnemyDead()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}

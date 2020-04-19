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

    void Start()
    {
        hpSysytem = GetComponent<HPSysytem>();
        damageSystem = GetComponent<DamageSystem>();

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
    }

    public void Hit()
    {
        //damageSystem.StartFightWithHuman(enemies[0]);

        damageSystem.HitTarget(enemies[0]);
    }
}

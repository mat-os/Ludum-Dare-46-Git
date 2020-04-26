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

    void Start()
    {
        hpSysytem = gameObject.GetComponent<HPSysytem>();
        damageSystem = gameObject.GetComponent<DamageSystem>();

        enemyAnim = gameObject.GetComponent<EnemyAnimController>();

        var ss = FindObjectsOfType<MonoBehaviour>().OfType<Human>();
        foreach (Human s in ss)
        {
            enemies.Add(s);
        }

        DealDamage();
    }

    public void TakeDamage(float damageTaken)
    {
        hpSysytem.TakeDamage(damageTaken);

        if (GetHPAmount() <= 0)
        {
            Dead();
        }
    }

    public void DealDamage()
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

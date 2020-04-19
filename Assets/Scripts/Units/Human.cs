using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Human : MonoBehaviour, IDamagable, IHittable
{
    [SerializeField]private float damage;
    [SerializeField] private float attackRate;

    [SerializeField] private float HPmax;

    private HPSysytem hpSysytem;
    private DamageSystem damageSystem;

    private List<Enemy> enemies = new List<Enemy>();

    IDamagable damageable;
    IHittable hittable;

    private bool isFight;

    void Start()
    {
        #region Init
        if (gameObject.GetComponent<HPSysytem>() == null)
        {
            gameObject.AddComponent<HPSysytem>();
        }

        if (gameObject.GetComponent<DamageSystem>() == null)
        {
            gameObject.AddComponent<DamageSystem>();
        }

        if (hpSysytem == null)
        {
            hpSysytem = GetComponent<HPSysytem>();
        }

        if (damageSystem == null)
        {
            damageSystem = GetComponent<DamageSystem>();
        }
        #endregion

        Initialisation(damage, attackRate,HPmax);
    }


    public void Initialisation(float _damage, float _attackRate, float _HPMax)
    {
        damageSystem.SetDamage(_damage);
        damageSystem.SetAttackRate(_attackRate);

        hpSysytem.SetMaxHP(_HPMax);
    }

    void Update()
    {
        if (enemies.Count == 0)
        {
            var ss = FindObjectsOfType<MonoBehaviour>().OfType<Enemy>();
            foreach (Enemy s in ss)
            {
                enemies.Add(s);
            }
        }
        else if(enemies.Count > 0 && isFight == false)
        {
            Hit();

            isFight = true;
        }
    }

    public void TakeHeal(float healAmount)
    {
        hpSysytem.TakeHeal(healAmount);
    }

    public void TakeDamage(float damageTaken)
    {
        hpSysytem.TakeDamage(damageTaken);
    }

    public void Hit()
    {
        damageSystem.HitTarget(enemies[0]);
    }
}

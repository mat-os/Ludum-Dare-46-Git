using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using UnityEngine;

public class Human : MonoBehaviour, IDamagable, IHittable
{
    [SerializeField]private float damageMin;
    [SerializeField]private float damageMax;
    [SerializeField] private float attackRate;

    [SerializeField] private float HPmax;

    private HPSysytem hpSysytem;
    private DamageSystem damageSystem;

    public List<Enemy> enemies = new List<Enemy>();

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

        Initialisation(damageMin, damageMax, attackRate,HPmax);
    }


    public void Initialisation(float _minDamage, float _maxDamage, float _attackRate, float _HPMax)
    {
        damageSystem.SetDamage(_minDamage, _maxDamage);
        damageSystem.SetAttackRate(_attackRate);

        hpSysytem.SetMaxHP(_HPMax);
    }

    void Update()
    {
        if (GameInstance.Instance.gameStatus.gameState == GameStatus.GameState.Fight)
        {
            if (enemies.Count == 0 && isFight == false)
            {
                FindTarget();
            }

            else if (enemies.Count > 0 && isFight == false)
            {
                FightTarget();
            }

            else if (enemies.Count == 0 && isFight == false)
            {
                EndFight();
            }
        }
    }

    public void FindTarget()
    {
        var ss = FindObjectsOfType<MonoBehaviour>().OfType<Enemy>();

        foreach (Enemy s in ss)
        {
            if (s.isAlive)
            {
                Debug.Log("FIND ENEMY" + s.name);
                enemies.Add(s);
            }
        }
    }

    public void FightTarget()
    {
        Hit();

        isFight = true;
    }

    public void EndFight()
    {
        Debug.Log("FIGHT END");
        //GameInstance.Instance.game
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
        damageSystem.HitTarget(enemies[Random.Range(0, enemies.Count)]);
    }

    public void SetIsFight(bool _isFight)
    {
        isFight = _isFight;
    }

    public void KillEnemy(Enemy targetEnemy)
    {
        enemies = null;

        Debug.Log("KILL!!!!!!!!!!!!!!!!!!!");

        isFight = false;
    }
}

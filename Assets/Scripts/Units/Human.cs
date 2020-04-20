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

    //public List<Enemy> enemies = new List<Enemy>();

    public Enemy enemy;

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
            if (enemy == null && isFight == false)
            {
                FindTarget();

                if (enemy == null)
                {
                    EndFight();
                }
            }
        }
    }

    public void FindTarget()
    {
        var ss = FindObjectsOfType<MonoBehaviour>().OfType<Enemy>();

        if (ss.Count() > 0)
        {
            enemy = ss.First();

            Debug.Log(ss.Count());

            FightTarget();

            ss = null;
        }
        else
        {
            EndFight();
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

        GameInstance.Instance.gameplayController.Walk();
    }

    public void TakeHeal(float healAmount)
    {
        hpSysytem.TakeHeal(healAmount);
    }

    public void TakeDamage(float damageTaken)
    {
        hpSysytem.TakeDamage(damageTaken);

        if (hpSysytem.GetHPAmount() < 0)
        {
            GameInstance.Instance.gameplayController.GameFail();
        }
    }

    public void Hit()
    {
        damageSystem.HitTarget(enemy);
    }

    public void KillEnemy(Enemy targetEnemy)
    {
        Debug.Log("KILL!!!!!!!!!!!!!!!!!!!");

        enemy = null;

        isFight = false;
    }
}

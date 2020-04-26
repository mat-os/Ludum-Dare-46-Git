using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using UnityEngine;

public class Human : Entity, IDamagable, IHittable
{
    [SerializeField]private float damageMin;
    [SerializeField]private float damageMax;
    [SerializeField]private float attackRate;

    [SerializeField] private float armorAmount;

    [SerializeField]private float HPmax;

    private HPSysytem hpSysytem;
    private DamageSystem damageSystem;
    private EffectController effectController;

    public Entity enemyToFight;

    public List<Enemy> Enemies;

    IDamagable damageable;
    IHittable hittable;

    private bool isFight;

    public EffectController GetEffectController()
    {
        return effectController;
    }

    public float GetAttackRate()
    {
        return attackRate;
    }
    public void SetAttackRate(float newRate)
    {
        attackRate = newRate;
        damageSystem.SetAttackRate(newRate);
    }

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

        if (gameObject.GetComponent<EffectController>() == null)
        {
            gameObject.AddComponent<EffectController>();
        }

        if (hpSysytem == null)
        {
            hpSysytem = GetComponent<HPSysytem>();
        }

        if (damageSystem == null)
        {
            damageSystem = GetComponent<DamageSystem>();
        }

        if (effectController == null)
        {
            effectController = GetComponent<EffectController>();
        }
        #endregion

        Initialisation(damageMin, damageMax, attackRate,HPmax);
    }


    public override void Initialisation(float _minDamage, float _maxDamage, float _attackRate, float _HPMax)
    {
        damageSystem.SetDamage(_minDamage, _maxDamage);
        damageSystem.SetAttackRate(_attackRate);

        hpSysytem.SetMaxHP(_HPMax);
    }

    void Update()
    {
        if (GameInstance.Instance.gameStatus.gameState == GameStatus.GameState.Fight)
        {
            if (Enemies.Count() == 0 && isFight == false)
            {
                FindTarget();
            }

            else if(enemyToFight != null && isFight == false)
            {
                FightTarget();
            }
        }
    }

    public void FindTarget()
    {
        Debug.Log("FIND");

        Enemies = new List<Enemy>(FindObjectsOfType<Enemy>());

        if (Enemies.Count() == 0)
        {
            EndFight();
        }
        else
        {
            enemyToFight = Enemies[0];
        }
    }

    public void FightTarget()
    {
        HitEntity();

        isFight = true;
    }

    public void EndFight()
    {
        Debug.Log("FIGHT END");

        if (GameInstance.Instance.gameStatus.gameState != GameStatus.GameState.Walk)
        {
            GameInstance.Instance.gameplayController.Walk();
        }
    }

    public void TakeHeal(float healAmount)
    {
        hpSysytem.TakeHeal(healAmount);
    }

    public override void TakeDamage(float damageTaken)
    {
        hpSysytem.TakeDamage(damageTaken - ((damageTaken / 100) * armorAmount));

        if (hpSysytem.GetHPAmount() < 0)
        {
            Dead();
        }
    }

    public void HitEntity()
    {
        damageSystem.HitTarget(enemyToFight);
    }

    public void KillEnemy(Entity targetEnemy)
    {
        enemyToFight = null;

        Enemies.Clear();

        isFight = false;
    }
    
    public override void Dead()
    {
        GameInstance.Instance.gameplayController.GameFail();
    }

    public float GetArmorAmount()
    {
        return armorAmount;
    }

    public void SetArmorAmount(float _newArmor)
    {
        armorAmount = _newArmor;
    }
}

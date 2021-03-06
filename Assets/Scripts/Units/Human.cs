﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using UnityEngine;

public class Human : Entity
{
    private HPSysytem hpSysytem;
    private DamageSystem damageSystem;
    private EffectController effectController;
    private AgrSystem agrSystem;

    public Entity enemyToFight;
    public List<Enemy> Enemies;

    private bool isFight;

    public EffectController GetEffectController()
    {
        return effectController;
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

        if (gameObject.GetComponent<AgrSystem>() != null)
        {
            agrSystem = GetComponent<AgrSystem>();
        }
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
                DealDamage();
            }
        }
    }

    public void FindTarget()
    {
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

    public void EndFight()
    {
        Debug.Log("FIGHT END");

        if (GameInstance.Instance.gameStatus.gameState != GameStatus.GameState.Walk)
        {
            GameInstance.Instance.gameplayController.WalkAndSearch();
        }
    }

    public void KillEnemy(Entity targetEnemy)
    {
        enemyToFight = null;

        Enemies.Clear();

        isFight = false;
    }

    public void TakeHeal(float healAmount)
    {
        hpSysytem.TakeHeal(healAmount);
    }

    public override void TakeDamage(float damageTaken)
    {
        hpSysytem.TakeDamage(damageTaken - ((damageTaken / 100) * GetArmorAmount()));

        if (GetHPAmount() < 0)
        {
            Dead();
        }
    }

    public void DealDamage()
    {
        damageSystem.HitTarget(enemyToFight);

        if (agrSystem != null)
        {
            agrSystem.UseAgr();
        }

        isFight = true;
    }
    
    public override void Dead()
    {
        GameInstance.Instance.gameplayController.GameFail();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : Entity
{
    private HPSysytem hpSysytem;
    private DamageSystem damageSystem;

    private EnemyAnimController enemyAnim;

    public List<Human> enemies = new List<Human>();

    private bool isAgred;

    void Start()
    {
        hpSysytem = gameObject.GetComponent<HPSysytem>();
        damageSystem = gameObject.GetComponent<DamageSystem>();

        enemyAnim = gameObject.GetComponent<EnemyAnimController>();

        FindHumans();
    }

    private void FindHumans()
    {
        var ss = FindObjectsOfType<Human>();

        foreach (Human s in ss)
        {
            enemies.Add(s);
        }

        DealDamage(enemies[Random.Range(0, enemies.Count)]);
    }

    public override void TakeDamage(float damageTaken)
    {
        hpSysytem.TakeDamage(damageTaken);

        if (GetHPAmount() <= 0)
        {
            Dead();
        }
    }

    public void DealDamage(Human humanToAttack)
    {
        damageSystem.HitTarget(humanToAttack);
    }

    //получили агр от воина
    public void Agred(Human agrHuman, float agrTime)
    {
        StartCoroutine(AgrRoutine(agrHuman, agrTime));
    }

    public override void Dead()
    {
        enemyAnim.DeadAnim();

        SetIsAlive(false);

        //Destroy(this);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    //получили агр от воина
    IEnumerator AgrRoutine(Human agrHuman, float agrTime)
    {
        damageSystem.HitTarget(enemies.Find(human => agrHuman));

        yield return new WaitForSeconds(agrTime);

        DealDamage(enemies[Random.Range(0, enemies.Count)]);

    }
}

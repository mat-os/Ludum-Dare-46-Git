using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private float HPmax;
    private float HPAmount;

    [SerializeField] private float damageMin;
    [SerializeField] private float damageMax;
    [SerializeField] private float attackRate;

    [SerializeField] private float armorAmount;

    void Awake()
    {
        HPAmount = HPmax;
    }

    private bool isAlive = true;
    public abstract void Dead();

    public abstract void TakeDamage(float damageTaken);

    #region Get & Set
    public float GetHPmax()
    {
        return HPmax;
    }
    public void SetHPmax(float newHPmax)
    {
        HPmax = newHPmax;
        HPAmount = HPmax;
    }

    public float GetHPAmount()
    {
        return HPAmount;
    }
    public void SetHPAmount(float newHPAmount)
    {
        HPAmount = newHPAmount;
    }

    public float GetAttackRate()
    {
        return attackRate;
    }
    public void SetAttackRate(float newRate)
    {
        attackRate = newRate;
    }

    public float GetDamageMax()
    {
        return damageMax;
    }
    public void SetDamageMax(float newMaxDamage)
    {
        damageMax = newMaxDamage;
    }

    public float GetDamageMin()
    {
        return damageMin;
    }
    public void SetDamageMin(float newMinDamage)
    {
        damageMin = newMinDamage;
    }

    public float GetArmorAmount()
    {
        return armorAmount;
    }
    public void SetArmorAmount(float newArmorAmount)
    {
        armorAmount = newArmorAmount;
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }
    public void SetIsAlive(bool newBool)
    {
        isAlive = newBool;
    }
    

    #endregion
}

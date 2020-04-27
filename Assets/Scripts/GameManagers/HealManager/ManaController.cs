using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaController : MonoBehaviour
{
    [SerializeField]private float maxMana;
    [SerializeField]private float manaRegenAmount;

    [SerializeField] private ManaBar manaBar;

    void Start()
    {
        manaBar.InitManabar(maxMana, manaRegenAmount);
    }

    public void SpendMana(float manaToSpend)
    {
        manaBar.SpendMana(manaToSpend);
    }
    public float GetManaAmount()
    {
        return manaBar.GetManaAmount();
    }

    public float GetMaxMana()
    {
        return maxMana;
    }
    public void SetMaxMana(float newAmount)
    {
        maxMana = newAmount;

        manaBar.ChangeMaxMana(maxMana);
    }

    public float GetManaRegAmount()
    {
        return manaRegenAmount;
    }
    public void SetManaRegAmount(float newAmount)
    {
        manaRegenAmount = newAmount;

        manaBar.ChangeManaRegAmount(manaRegenAmount);
    }

    public void RestoreAllMana()
    {
        manaBar.RestorAllMana();
    }
}

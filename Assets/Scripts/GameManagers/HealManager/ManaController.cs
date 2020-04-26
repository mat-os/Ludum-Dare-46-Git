using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaController : MonoBehaviour
{
    [SerializeField]private int maxMana;
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

    public void RestoreAllMana()
    {
        manaBar.RestorAllMana();
    }
}

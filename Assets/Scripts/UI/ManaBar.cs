using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField]private TMP_Text manaText;

    private Mana mana;

    private Image barImage;

    public void InitManabar(float maxMana, float _manaRegenAmount)
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        mana = new Mana(maxMana, _manaRegenAmount);
    }
    
    public void SpendMana(float spendMana)
    {
        mana.SpendMana(spendMana);
    }

    public float GetManaAmount()
    {
        return mana.GetManaAmount();
    }

    public void RestorAllMana()
    {
        mana.RestoreMana(0);
    }

    private void FixedUpdate()
    {
        if (mana != null)
        {
            mana.Update(manaText);
            barImage.fillAmount = mana.GetManaNormalized();
        }
    }

    public void ChangeManaRegAmount(float newManaReg)
    {
        mana.manaRegenAmount = newManaReg;
    }

    public void ChangeMaxMana(float newMana)
    {
        mana.MANA_MAX = newMana;
    }
}


public class Mana
{
    public float MANA_MAX = 100;

    private float manaAmount;
    public float manaRegenAmount;

    //Set Variables
    public Mana(float maxMana, float _manaRegenAmount)
    {
        MANA_MAX = maxMana;

        manaAmount = MANA_MAX;

        manaRegenAmount = _manaRegenAmount;
    }

    //Add ManaRegen and Clamp it
    public void Update(TMP_Text textToUpdate)
    {
        manaAmount += manaRegenAmount * Time.deltaTime;

        manaAmount = Mathf.Clamp(manaAmount, 0, MANA_MAX);

        //Setup Text
        textToUpdate.text = manaAmount.ToString("F0") + "/" + MANA_MAX.ToString("F0");
    }

    //Method to spend mana
    public void SpendMana(float amount)
    {
        manaAmount -= amount;
    }
    //Method to restore mana
    public void RestoreMana(int amount)
    {
        manaAmount = amount;
    }

    public float GetManaNormalized()
    {
        return manaAmount / MANA_MAX;
    }

    public float GetManaAmount()
    {
        return manaAmount;
    }
} 

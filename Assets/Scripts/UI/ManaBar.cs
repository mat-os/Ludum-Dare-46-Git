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

    public void InitManabar(int maxMana, float _manaRegenAmount)
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        mana = new Mana(maxMana, _manaRegenAmount);
    }

    public void SpendMana(float spendMana)
    {
        mana.SpendMana(spendMana);
    }

    private void FixedUpdate()
    {
        if (mana != null)
        {
            mana.Update(manaText);
            barImage.fillAmount = mana.GetManaNormalized();
        }
    }
}

public class Mana
{
    public int MANA_MAX = 100;

    private float manaAmount;
    private float manaRegenAmount;

    //Set Variables
    public Mana(int maxMana, float _manaRegenAmount)
    {
        MANA_MAX = maxMana;

        manaAmount = MANA_MAX - 3;

        manaRegenAmount = _manaRegenAmount;
    }

    //Add ManaRegen and Clamp it
    public void Update(TMP_Text textToUpdate)
    {
        manaAmount += manaRegenAmount * Time.deltaTime;
        manaAmount = Mathf.Clamp(manaAmount, 0, MANA_MAX);

        //Setup Text
        textToUpdate.text = manaAmount.ToString("F1") + "/" +  MANA_MAX;
    }

    //Method to spend mana
    public void SpendMana(float amount)
    {
        if(manaAmount >= amount)
        {
            manaAmount -= amount;
        }
    }
    //Method to restore mana
    public void RestoreMana(int amount)
    {
        manaAmount += amount;
    }

    public float GetManaNormalized()
    {
        return manaAmount / MANA_MAX;
    }
} 

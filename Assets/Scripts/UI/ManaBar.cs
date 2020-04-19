using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    private Mana mana;
    private Image barImage;

    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        mana = new Mana();
    }

    private void Update()
    {
        mana.Update();
        barImage.fillAmount = mana.GetManaNormalized();

        /*
        if (Input.GetKeyDown("space"))
        {
            mana.SpendMana(10);
        }
        */
    }
}

public class Mana
{
    public const int MANA_MAX = 100;

    private float manaAmount;
    private float manaRegenAmount;

    //Set Variables
    public Mana()
    {
        manaAmount = 0;
        manaRegenAmount = 3f;
    }

    //Add ManaRegen and Clamp it
    public void Update()
    {
        manaAmount += manaRegenAmount * Time.deltaTime;
        manaAmount = Mathf.Clamp(manaAmount, 0, MANA_MAX);
    }

    //Method to spend mana
    public void SpendMana(int amount)
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

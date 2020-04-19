using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHeal : MonoBehaviour
{
    [SerializeField]private float healAmount;
    [SerializeField]private float manacost;
    [SerializeField]private float cooldownTime;

    public void SimpleHealSkill()
    {
        ChoseHealTarget.targetToHeal.TakeHeal(healAmount);

        GameInstance.Instance.manaController.SpendMana(manacost);
    }
}

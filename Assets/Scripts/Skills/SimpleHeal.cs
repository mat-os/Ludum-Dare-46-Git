using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHeal : Skill
{
    [SerializeField]private float healAmount;
    [SerializeField]private float manacost;
    [SerializeField]private float cooldownTime;

    public override void UseSkill()
    {
        ChoseHealTarget.targetToHeal.TakeHeal(healAmount);

        GameInstance.Instance.manaController.SpendMana(manacost);
    }
}

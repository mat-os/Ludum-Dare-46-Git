using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAOEHeal : Skill
{
    [SerializeField] private float healAmount;
    [SerializeField] private float manacost;
    [SerializeField] private float cooldownTime;

    public override void UseSkill()
    {
        if (GameInstance.Instance.manaController.GetManaAmount() > manacost)
        {
            for (int i = 0; i < ChoseHealTarget.bothHuman.Length; i++)
            {
                ChoseHealTarget.bothHuman[i].TakeHeal(healAmount);
            }

            GameInstance.Instance.manaController.SpendMana(manacost);
        }
    }
}

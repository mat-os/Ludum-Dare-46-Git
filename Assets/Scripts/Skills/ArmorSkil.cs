using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSkil : Skill
{
    [SerializeField] private float armorAmount;
    [SerializeField] private float timeOfArmorEffect;
    [SerializeField] private float manacost;
    [SerializeField] private float cooldownTime;

    public override void UseSkill()
    {
        if (GameInstance.Instance.manaController.GetManaAmount() > manacost)
        {
            ChoseHealTarget.targetToHeal.ChangeArmor(armorAmount, timeOfArmorEffect);

            GameInstance.Instance.manaController.SpendMana(manacost);
        }
    }
}

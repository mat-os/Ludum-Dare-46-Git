using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSkil : Skill
{
    [SerializeField] private float armorAmount;
    [SerializeField] private float timeOfArmorEffect;

    public override void UseSkill()
    {
        ChoseHealTarget.targetToHeal.GetEffectController().ChangeArmor(armorAmount, timeOfArmorEffect);
    }
}

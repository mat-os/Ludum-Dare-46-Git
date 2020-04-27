using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSkil : Skill
{
    [SerializeField] private float armorAmountInPercent;
    [SerializeField] private float timeOfArmorEffect;

    //  human.SetArmorAmount(startArmor + armor);

    public override void UseSkill()
    {
        ChoseHealTarget.targetToHeal.GetEffectController().ChangeArmor(armorAmountInPercent, timeOfArmorEffect);
    }
}

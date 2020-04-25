using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSkil : Skill
{
    [SerializeField] private float armorAmount;
    [SerializeField] private float timeOfArmorEffect;
    [SerializeField] private float cooldownTime;

    [SerializeField] private string skillName;
    [SerializeField] private string skillDescription;

    [SerializeField] private Sprite skillSprite;
    [SerializeField] private Sprite mouseOverSprite;
    [SerializeField] private Sprite isUsedSprite;

    public override void UseSkill()
    {
        ChoseHealTarget.targetToHeal.GetEffectController().ChangeArmor(armorAmount, timeOfArmorEffect);
    }

    public override Sprite getSprite()
    {
        return skillSprite;
    }

    public override string GetSkillName()
    {
        return skillName;
    }
    public override string GetSkillDescription()
    {
        return skillDescription;
    }
    public override float GetSkillCooldownTime()
    {
        return cooldownTime;
    }

    public override Sprite getMouseOverSprite()
    {
        return mouseOverSprite;
    }

    public override Sprite getIsUsedSprite()
    {
        return isUsedSprite;
    }
}

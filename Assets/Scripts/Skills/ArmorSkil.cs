using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSkil : Skill
{
    [SerializeField] private float armorAmount;
    [SerializeField] private float timeOfArmorEffect;
    [SerializeField] private float manacost;
    [SerializeField] private float cooldownTime;

    [SerializeField] private string skillName;
    [SerializeField] private string skillDescription;

    private bool isSkillReady = true;

    public Sprite skillSprite;

    public override void UseSkill()
    {
        if (GameInstance.Instance.manaController.GetManaAmount() > manacost && isSkillReady)
        {
            ChoseHealTarget.targetToHeal.GetEffectController().ChangeArmor(armorAmount, timeOfArmorEffect);

            GameInstance.Instance.manaController.SpendMana(manacost);

            StartCoroutine(countCooldownRoutine(cooldownTime));

            isSkillReady = false;
        }
    }

    IEnumerator countCooldownRoutine(float _cooldownTime)
    {
        yield return new WaitForSeconds(_cooldownTime);

        isSkillReady = true;
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
}

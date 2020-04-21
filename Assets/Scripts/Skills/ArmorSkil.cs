using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSkil : Skill
{
    [SerializeField] private float armorAmount;
    [SerializeField] private float timeOfArmorEffect;
    [SerializeField] private float manacost;
    [SerializeField] private float cooldownTime;

    private bool isSkillReady = true;

    public override void UseSkill()
    {
        if (GameInstance.Instance.manaController.GetManaAmount() > manacost && isSkillReady)
        {
            ChoseHealTarget.targetToHeal.ChangeArmor(armorAmount, timeOfArmorEffect);

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
}

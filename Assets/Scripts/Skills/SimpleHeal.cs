﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleHeal : Skill
{
    [SerializeField] private float levelOfSkill;

    [SerializeField]private float healAmount;
    [SerializeField]private float manacost;
    [SerializeField]private float cooldownTime;

    [SerializeField]private Sprite skillSprite;
    [SerializeField]private string skillName;
    [SerializeField]private string skillDescription;


    private bool isSkillReady = true;

    public override void UseSkill()
    {
        if (GameInstance.Instance.manaController.GetManaAmount() > manacost && isSkillReady)
        {
            ChoseHealTarget.targetToHeal.TakeHeal(healAmount);

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

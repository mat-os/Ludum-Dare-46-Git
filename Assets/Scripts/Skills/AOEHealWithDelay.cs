using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AOEHealWithDelay : Skill
{
    [SerializeField] private float healAmount;
    [SerializeField] private float healTime;

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
            StartCoroutine(HealWithDelayRoutine(healTime, healAmount));

            GameInstance.Instance.manaController.SpendMana(manacost);

            StartCoroutine(countCooldownRoutine(cooldownTime));

            isSkillReady = false;
        }
    }

    IEnumerator HealWithDelayRoutine(float HealTime, float healAmount)
    {
        float t = 0;

        while (t < HealTime)
        {
            yield return new WaitForFixedUpdate();

            foreach (var human in ChoseHealTarget.bothHuman)
            {
                human.TakeHeal(healAmount);
            }

            t += Time.fixedDeltaTime;
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

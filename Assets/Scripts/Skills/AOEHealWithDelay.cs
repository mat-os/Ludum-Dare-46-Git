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

    [SerializeField] private Sprite skillSprite;
    [SerializeField] private Sprite mouseOverSprite;
    [SerializeField] private Sprite isUsedSprite;

    public override void UseSkill()
    {
        if (GameInstance.Instance.manaController.GetManaAmount() > manacost && GetIsSkillReady())
        {
            StartCoroutine(HealWithDelayRoutine(healTime, healAmount));

            GameInstance.Instance.manaController.SpendMana(manacost);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleAOEHeal : Skill
{
    [SerializeField] private float healAmount;
    [SerializeField] private float manacost;
    [SerializeField] private float cooldownTime;

    private bool isSkillReady = true;

    public Button SkillButton;
    public Sprite cooldownSprite;

    public override void UseSkill()
    {
        if (GameInstance.Instance.manaController.GetManaAmount() > manacost && isSkillReady)
        {
            for (int i = 0; i < ChoseHealTarget.bothHuman.Length; i++)
            {
                ChoseHealTarget.bothHuman[i].TakeHeal(healAmount);
            }

            GameInstance.Instance.manaController.SpendMana(manacost);

            StartCoroutine(countCooldownRoutine(cooldownTime));

            SkillButton.image.sprite = cooldownSprite;
            SkillButton.image.color = Color.grey;

            isSkillReady = false;
        }
    }

    IEnumerator countCooldownRoutine(float _cooldownTime)
    {
        yield return new WaitForSeconds(_cooldownTime);

        SkillButton.image.sprite = cooldownSprite;
        SkillButton.image.color = Color.white;

        isSkillReady = true;
    }
}

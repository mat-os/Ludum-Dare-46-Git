using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRateSkill : Skill
{
    [SerializeField] private float AttackRateAmount;
    [SerializeField] private float timeOfEffect;

    public override void UseSkill()
    {
        ChoseHealTarget.targetToHeal.GetEffectController().ChangeAttackRate(AttackRateAmount, timeOfEffect);
    }
}

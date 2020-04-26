using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRateSkill : Skill
{
    [SerializeField] private float AttackRateMultiplier;
    [SerializeField] private float timeOfEffect;

    //  human.SetAttackRate(startRate * AttackRateMultiplier);


    public override void UseSkill()
    {
        ChoseHealTarget.targetToHeal.GetEffectController().ChangeAttackRate(AttackRateMultiplier, timeOfEffect);
    }
}

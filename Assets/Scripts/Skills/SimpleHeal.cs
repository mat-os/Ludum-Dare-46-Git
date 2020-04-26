using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleHeal : Skill
{
    [SerializeField] private float healAmount;

    public override void UseSkill()
    {
        ChoseHealTarget.targetToHeal.TakeHeal(healAmount);
    }
}

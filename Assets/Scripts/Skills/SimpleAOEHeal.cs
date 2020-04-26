using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleAOEHeal : Skill
{
    [SerializeField] private float healAmount;
    [SerializeField] private float manacost;
    
    public override void UseSkill()
    {
        for (int i = 0; i < ChoseHealTarget.bothHuman.Length; i++)
        {
            ChoseHealTarget.bothHuman[i].TakeHeal(healAmount);
        }
    }
}

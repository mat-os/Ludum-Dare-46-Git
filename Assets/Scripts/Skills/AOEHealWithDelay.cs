using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AOEHealWithDelay : Skill
{
    [SerializeField] private float healAmount;
    [SerializeField] private float healTime;

    public override void UseSkill()
    {
        StartCoroutine(HealWithDelayRoutine(healTime, healAmount));
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
}

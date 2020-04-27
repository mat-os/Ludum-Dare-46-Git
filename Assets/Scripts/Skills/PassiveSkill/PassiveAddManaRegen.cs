using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAddManaRegen : Skill
{
    [SerializeField] private float manaregToAdd;

    public override void UseSkill()
    {
        GameInstance.Instance.manaController.SetManaRegAmount(manaregToAdd + GameInstance.Instance.manaController.GetManaRegAmount());
    }
}

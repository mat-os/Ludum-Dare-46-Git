using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAddMaxMana : Skill
{
    [SerializeField] private float maxmanaToAdd;

    public override void UseSkill()
    {
        GameInstance.Instance.manaController.SetMaxMana(maxmanaToAdd + GameInstance.Instance.manaController.GetMaxMana());
    }
}

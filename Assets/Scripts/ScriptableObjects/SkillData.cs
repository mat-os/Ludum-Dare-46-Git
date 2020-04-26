using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkillData", menuName = "Skill Data", order = 52)]
public class SkillData : ScriptableObject
{
    [SerializeField]private int skillLevel;

    [SerializeField]private TargetAtributToChange targetAtribut;

    [SerializeField] private SkillType skillType;

    [SerializeField] private int cooldownTime;

    [SerializeField] private int manacost;


    public int SkillLevel
    {
        get
        {
            return skillLevel;
        }
    }
}

public enum TargetAtributToChange
{
    HP,
    Armor,
    AttackSpeed
}

public enum SkillType
{
    Burst,
    Delay
}

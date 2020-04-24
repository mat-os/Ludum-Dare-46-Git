using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public int skillLevel;

    public abstract void UseSkill();

    public abstract Sprite getSprite();

    public abstract string GetSkillName();

    public abstract string GetSkillDescription();
}

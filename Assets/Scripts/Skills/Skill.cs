using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public int skillLevel;

    [SerializeField]private int manacost;

    private bool isSkillReady;

    public abstract void UseSkill();

    public abstract Sprite getSprite();

    public abstract Sprite getMouseOverSprite();

    public abstract Sprite getIsUsedSprite();

    public abstract string GetSkillName();

    public abstract string GetSkillDescription();

    public abstract float GetSkillCooldownTime();

    public void SetIsSkillReady(bool _isSkillReady)
    {
        isSkillReady = _isSkillReady;
    }

    public bool GetIsSkillReady()
    {
        return isSkillReady;
    }

    public int GetManacost()
    {
        return manacost;
    }
}

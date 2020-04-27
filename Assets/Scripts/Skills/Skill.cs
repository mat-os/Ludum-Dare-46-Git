using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    //public int skillLevel;

    [SerializeField] private int manacost;
    [SerializeField] private float cooldownTime;
    [SerializeField] private bool isSkillPassive;

    [SerializeField] private string skillName;
    [TextArea]
    [SerializeField] private string skillDescription;

    [SerializeField] private Sprite skillSprite;
    [SerializeField] private Sprite mouseOverSprite;
    [SerializeField] private Sprite isUsedSprite;

    [TextArea]
    [SerializeField] private string skillLiteratureDescription;

    private bool isSkillReady;

    public abstract void UseSkill();

    public Sprite getSprite()
    {
        return skillSprite;
    }
    public Sprite getMouseOverSprite()
    {
        return mouseOverSprite;
    }
    public Sprite getIsUsedSprite()
    {
        return mouseOverSprite;
    }

    public string GetSkillName()
    {
        return skillName;
    }
    public string GetSkillDescription()
    {
        return skillDescription;
    }

    public float GetSkillCooldownTime()
    {
        return cooldownTime;
    }
    public int GetManacost()
    {
        return manacost;
    }

    public bool GetIsSkillPassive()
    {
        return isSkillPassive;
    }

    public void SetIsSkillReady(bool _isSkillReady)
    {
        isSkillReady = _isSkillReady;
    }
    public bool GetIsSkillReady()
    {
        return isSkillReady;
    }

    public string GetSkillLiteratureDescription()
    {
        return skillLiteratureDescription;
    }
}

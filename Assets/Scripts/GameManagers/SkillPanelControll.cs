using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelControll : MonoBehaviour
{
    public SkillSlot[] skillSlots;

    public void AddNewSkillToPanel(Skill skillToAdd)
    {
        for (int i = 0; i < skillSlots.Length; i++)
        {
            if (skillSlots[i].isHaveSpell == false)
            {
                skillSlots[i].Init(skillToAdd);

                break;
            }
        }
    }


    public void TurnOnSkill(int skillNumber)
    {
        skillSlots[skillNumber].TurnOnSkill();
    }

    public void TurnOffSkill(int skillNumber)
    {
        skillSlots[skillNumber].TurnOffSkill();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public SkillSystem skillSystem;
    public SkillPanelControll skillPanelControll;

    [SerializeField] private Skill skill1;
    [SerializeField] private Skill skill2;
    [SerializeField] private Skill skill3;
    [SerializeField] private Skill skill4;
    [SerializeField] private Skill skill5;

    private Skill skillToReturn;

    //Добавление и получение скилов идет с 1

    void Awake()
    {
        AddSkill(1, skillSystem.getStartSkills(0));
        AddSkill(2, skillSystem.getStartSkills(1));
    }

    public Skill GetSkill(int skillNumber)
    {
        switch (skillNumber)
        {
            case 1:
                if (skill1 != null)
                {
                    skillToReturn = skill1;
                }
                break;

            case 2:
                if (skill2 != null)
                {
                    skillToReturn = skill2;
                }
                break;

            case 3:
                if (skill3 != null)
                {
                    skillToReturn = skill3;
                }
                break;

            case 4:
                if (skill4 != null)
                {
                    skillToReturn = skill4;
                }
                break;
            case 5:
                if (skill5 != null)
                {
                    skillToReturn = skill5;
                }
                break;

            default:
                Debug.Log("NoSkillToReturn");
                return null;
        }

        return skillToReturn;
    }

    public void AddSkill(int skillNumber, Skill skill)
    {
        switch (skillNumber)
        {
            case 1:
                skill1 = skill;
                skillPanelControll.AddNewSkillToPanel(skill);

                break;

            case 2:
                skill2 = skill;
                skillPanelControll.AddNewSkillToPanel(skill);

                break;

            case 3:
                skill3 = skill;
                skillPanelControll.AddNewSkillToPanel(skill);

                break;

            case 4:
                skill4 = skill;
                skillPanelControll.AddNewSkillToPanel(skill);

                break;
            case 5:
                skill5 = skill;
                skillPanelControll.AddNewSkillToPanel(skill);

                break;
        }
    }
}

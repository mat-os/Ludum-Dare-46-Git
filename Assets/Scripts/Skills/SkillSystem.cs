using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public Skill skill1;
    public Skill skill2;
    public Skill skill3;
    public Skill passiveSkill;
    public Skill skill4;
    
    public void UseSkill(int skillNumber)
    {
        switch (skillNumber)
        {
            case 1:
                skill1.UseSkill();
                break;
            case 2:
                skill2.UseSkill();
                break;
            case 3:
                skill3.UseSkill();
                break;
            case 4:
                skill4.UseSkill();
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            skill1.UseSkill();
        }
    }
}

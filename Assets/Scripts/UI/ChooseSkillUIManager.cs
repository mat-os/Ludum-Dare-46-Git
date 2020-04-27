using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSkillUIManager : MonoBehaviour
{
    public SkillSystem skillSystem;
    public PlayerInventory playerInventory;
    public ChillManager chillManager;

    public UISkillChoose uiSkillChooseLeft;
    public UISkillChoose uiSkillChooseRight;

    private Skill skillLeft;
    private Skill skillRight;

    private int counter = 3;

    public void chooseSkillLeft()
    {
        playerInventory.AddSkill(counter, skillLeft);
        counter++;

        chillManager.ActivateSkill();
    }

    public void chooseSkillRight()
    {
        playerInventory.AddSkill(counter, skillRight);
        counter++;

        chillManager.ActivateSkill();
    }

    void Start()
    {
        skillLeft = skillSystem.GetRandomSkillOfLevel(1);
        skillRight = skillSystem.GetRandomSkillOfLevel(1);

        uiSkillChooseLeft.UISkillChooseInstance(skillLeft);

        uiSkillChooseRight.UISkillChooseInstance(skillRight);
    }
}

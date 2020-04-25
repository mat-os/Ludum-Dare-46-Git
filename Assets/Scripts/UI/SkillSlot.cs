using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    private Skill mySkill;

    private Image img;
    //private Text lvlText;

    private Color normalColor;
    public Color selectedColor;

    public bool isHaveSpell;

    public void Init(Skill _skill)
    {
        mySkill = _skill;

        img = GetComponentInChildren<Image>();

        img.enabled = true;

        normalColor = img.color;

        UpdateUI();

        isHaveSpell = true;

        TurnOnSkill();

    }


    public void UpdateUI()
    {
        img.sprite = mySkill.getSprite();

        ////lvlText.text = mySkill.requiredLevel.ToString();

        //if (player.playerLevel >= mySkill.requiredLevel && player.xp >= mySkill.requiredXp)//check if player has enough xp/levels for this skill
        //{
        //    if (mySkill.beenSelected)
        //    {
        //        img.color = selectedColor;//if it has already been selected, then set the img color to the selectedColor
        //    }
        //    else
        //    {
        //        img.color = normalColor;//if not then set it to the normal color
        //    }
        //}
        //else
        //{
        //    img.color = selectedColor;//if player doesn't have enought xp/levels for this skill, set the color to selected [disabled] color
        //}
    }

    public void TurnOffSkill()
    {
        mySkill.SetIsSkillReady(false);

        img.color = Color.grey;

        img.sprite = mySkill.getIsUsedSprite();
    }
    public void TurnOnSkill()
    {
        mySkill.SetIsSkillReady(true);

        img.color = Color.white;

        img.sprite = mySkill.getSprite();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.sprite = mySkill.getMouseOverSprite();

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.sprite = mySkill.getSprite();

    }
}

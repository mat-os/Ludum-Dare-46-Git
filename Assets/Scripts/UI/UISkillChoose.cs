using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkillChoose : MonoBehaviour
{
    public Image skillImage;
    public TMP_Text nameText;
    public TMP_Text descriptionText;

    public TMP_Text manacostText;
    public TMP_Text cooldownText;

    public TMP_Text literatureText;

    public Button acceptButton;

    public void UISkillChooseInstance(Skill _skill)
    {
        skillImage.sprite = _skill.getSprite();
        nameText.text = _skill.GetSkillName();

        manacostText.text = _skill.GetManacost().ToString();
        cooldownText.text = _skill.GetSkillCooldownTime().ToString();

        if (_skill.GetIsSkillPassive() == true)
        {
            descriptionText.text = "<color=#FF000088>Пассивный: </color>" + _skill.GetSkillDescription();
        }
        else
        {
            descriptionText.text = _skill.GetSkillDescription();
        }

        literatureText.text = _skill.GetSkillLiteratureDescription();
    }
}

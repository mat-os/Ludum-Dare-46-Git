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
    public TMP_Text literatureText;

    public Button acceptButton;

    public void UISkillChooseInstance(Sprite _skillImage, string _nameText, string _skillDescr)
    {
        skillImage.sprite = _skillImage;
        nameText.text = _nameText;
        descriptionText.text = _skillDescr;
    }
}

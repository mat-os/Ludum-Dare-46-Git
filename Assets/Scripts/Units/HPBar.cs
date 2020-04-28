using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField]private TMP_Text HPtext;

    [SerializeField] private Transform HPSliderImage;
    [SerializeField] private Transform FullHPSliderImage;

    [SerializeField] private SpriteRenderer[] sprites;

   private float HPNow;

    public void UpdateHPBar(float maxHP, float HPAmount)
    {
        HPNow = HPAmount / maxHP;

       SetFillBar(HPNow);

       HPtext.text = HPAmount.ToString("F0") + "/" + maxHP.ToString("F0");
    }

    void Start()
    {
        // Default to an empty bar
        var newScale = this.HPSliderImage.localScale;
        newScale.x = 0;
        this.HPSliderImage.localScale = newScale;
    }

    public void SetFillBar(float fillAmount)
    {
        // Make sure value is between 0 and 1
        fillAmount = Mathf.Clamp01(fillAmount);

        // Scale the fillImage accordingly
        var newScale = this.HPSliderImage.localScale;
        newScale.x = this.FullHPSliderImage.localScale.x * fillAmount;
        this.HPSliderImage.localScale = newScale;
    }

    public void ChangeSpritesActive(bool isActive, Color inactiveColor)
    {
        switch (isActive)
        {
            case false:
                for (int i = 0; i < sprites.Length; i++)
                {
                    sprites[i].color = inactiveColor;
                }
                break;
            case true:
                for (int i = 0; i < sprites.Length; i++)
                {
                    sprites[i].color = Color.white;
                }
                break;
        }
    }
}

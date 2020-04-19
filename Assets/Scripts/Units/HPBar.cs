using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField]private TMP_Text HPtext;

    [SerializeField] private Transform HPSliderImage;
    [SerializeField] private Transform FullHPSliderImage;

    private float HPNow;

    public void UpdateHPBar(float maxHP, float HPAmount)
    {
       HPtext.text = HPAmount + "/" +  maxHP;

       HPNow = HPAmount / maxHP;

       SetFillBar(HPNow);

       Debug.Log(HPNow + gameObject.name);
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
}
